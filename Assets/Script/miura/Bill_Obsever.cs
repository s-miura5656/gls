using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bill_Obsever : MonoBehaviour
{
    // プレイヤーのレベルを取得するためのオブジェクト取得
    [SerializeField] private GameObject game_manager = null;
    // プレイヤーのレベルのスクリプトの取得
    [SerializeField] private Player_Level_Manager player_level_script = null;
    // 破壊率を管理しているスクリプトを取得
    [SerializeField] private Destruction_Rate_Manager destruction_rate_script = null;
    // 経験値を管理しているスクリプトを取得
    [SerializeField] private Player_Exp_Get player_exp_script = null;
    // ゲームの時間を管理しているスクリプト
    [SerializeField] private Time_Manager time_script = null;
    // ビルについている破壊に関するスクリプトを取得
    [SerializeField] private Bill_Destroy[] bill_Destroise = null;

    // ビルの破片パーティクル
    [SerializeField] private GameObject[] crash;
    // ヒットエフェクト貫通のオブジェクト
    [SerializeField] private GameObject hit_effect = null;
    // ヒットエフェクト反射のオブジェクト
    [SerializeField] private GameObject hit_ref_effect = null;
    // コインエフェクトのオブジェクト
    [SerializeField] private GameObject[] hit_coin_obj = null;

    // 壊れるパーティクル
    private ParticleSystem[] crash_particle = { null };
    // ヒットエフェクト貫通
    private ParticleSystem[] hit_particle = { null };
    // ヒットエフェクト反射
    private ParticleSystem hit_ref_particle = null;
    // コインのパーティクル
    private ParticleSystem coin_particle = null;

    // ビルが壊れるエフェクトの大きさの基準
    private float default_crash_particle_scale = 0.0f;
    // ヒットエフェクト貫通の大きさの基準
    private float default_hit_particle_scale = 0.0f;
    // ヒットエフェクト反射の大きさの基準
    private float default_hit_ref_particle_scale = 0.0f;
    // コインエフェクトの大きさの基準
    private float default_coin_particle_scale = 0.0f;
    // コインの出る基準値
    private int coin_number = 1;
    // ビルのレベルの上限
    private int max_bill_level = 6;

    public Player_Level_Manager Player_Level_Manager
    {
        get { return player_level_script; }
        private set { player_level_script = value; }
    }

    public Player_Exp_Get Player_Exp_Get
    {
        get { return player_exp_script; }
        private set { player_exp_script = value; }
    }

    public Destruction_Rate_Manager Destruction_Rate_Manager
    {
        get { return destruction_rate_script; }
        private set { destruction_rate_script = value; }
    }

    public Time_Manager Time_Manager
    {
        get { return time_script; }
        private set { time_script = value; }
    }

    /// <summary>
    /// ビルの壊れるエフェクト
    /// </summary>
    /// <param name="billLevel">ビルのレベル</param>
    /// <param name="bill_pos">ビルの座標</param>
    /// <param name="playerLevel">プレイヤーレベル</param>
    /// <param name="coin">取得したコインの数</param>
    [System.Obsolete]
    public void PlayCrashEffect(int billLevel, Vector3 bill_pos, int playerLevel, int coin)
    {
        var crash_obj = Instantiate(crash[billLevel], bill_pos, transform.rotation);
        Destroy(crash_obj, 2f);

        var coin_obj = Instantiate(hit_coin_obj[billLevel], bill_pos, transform.rotation);
        Destroy(coin_obj, 2f);
    }

    /// <summary>
    /// ヒットエフェクト貫通
    /// </summary>
    /// <param name="playerLevel">プレイヤーのレベル</param>
    /// <param name="hit_pos">当たった座標</param>
    public void PlayHitEffect(int bill_level, Vector3 hit_pos)
    {
        for (int i = 0; i < hit_particle.Length; i++)
        {
            // プレイヤーと当たった場所にヒットエフェクトを移動
            hit_particle[i].transform.position = hit_pos;
            // ヒットエフェクトのパーティクルをプレイヤーのレベルに合わせて拡大
            var hit_scale = Vector3.one * default_hit_particle_scale * (bill_level + 1);
            hit_particle[i].transform.localScale = hit_scale;

            hit_particle[i].Play();
        }
    }

    /// <summary>
    /// ヒットエフェクト反射
    /// </summary>
    /// <param name="playerLevel">プレイヤーのレベル</param>
    /// <param name="hit_pos">当たった座標</param>
    public void PlayHitRefEffect(int playerLevel, Vector3 hit_pos)
    {
        // プレイヤーと当たった場所にヒットエフェクトを移動
        hit_ref_particle.transform.position = hit_pos;
        // ヒットエフェクトのパーティクルをプレイヤーのレベルに合わせて拡大
        var hit_ref_scale = Vector3.one * default_hit_ref_particle_scale * playerLevel;
        hit_ref_particle.transform.localScale = hit_ref_scale;

        hit_ref_particle.Play();
    }

    private void Start()
    {
        // 貫通用ヒットエフェクトの初期化
        var hit_effect_obj = Instantiate(hit_effect, gameObject.transform);
        hit_particle = hit_effect_obj.GetComponentsInChildren<ParticleSystem>();
        default_hit_particle_scale = hit_particle[0].transform.localScale.x;

        // 反射用ヒットエフェクトの初期化
        var hit_ref_effect_obj = Instantiate(hit_ref_effect, gameObject.transform);
        hit_ref_particle = hit_ref_effect_obj.GetComponent<ParticleSystem>();
        default_hit_ref_particle_scale = hit_ref_particle.transform.localScale.x;

        // ビルの破壊のスクリプトの初期化
        for (int i = 0; i < bill_Destroise.Length; i++)
        {
            bill_Destroise[i].Initialized(this);
        }
    }

    private void Reset()
    {
        bill_Destroise = GetComponentsInChildren<Bill_Destroy>();
       
        crash = new GameObject[max_bill_level];
        hit_coin_obj = new GameObject[max_bill_level];

        for (int i = 0; i < crash.Length; i++)
        {
            crash[i] = Resources.Load($"Prefabs/effects/BillScrap/Scrap/Bill_Scrap_{ i }a") as GameObject;
            hit_coin_obj[i] = Resources.Load($"Prefabs/effects/coin/Coin_{ i }") as GameObject;
        }

    }

    public void SetCoinNumber(int coin) 
    {
        coin_number = coin;
    }
}
