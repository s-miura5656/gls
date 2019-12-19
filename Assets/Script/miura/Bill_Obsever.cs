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
    // ビルにヒットした時の音を管理しているスクリプト
    [SerializeField] private Player_SE_Manager player_se_script = null;
    // ゲームの時間を管理しているスクリプト
    [SerializeField] private Time_Manager time_script = null;
    // ビルについている破壊に関するスクリプトを取得
    [SerializeField] private Bill_Destroy[] bill_Destroise = null;
    // ビルの破片パーティクル
    [SerializeField] private GameObject crash = null;
    // ヒットエフェクト貫通のオブジェクト
    [SerializeField] private GameObject hit_effect = null;
    // ヒットエフェクト反射のオブジェクト
    [SerializeField] private GameObject hit_ref_effect = null;
    // コインエフェクトのパーティクル
    [SerializeField] private GameObject coin_effect = null;
    // 壊れるパーティクル
    private ParticleSystem[] crash_particle;
    // ヒットエフェクト貫通
    private ParticleSystem[] hit_particle;
    // ヒットエフェクト反射
    private ParticleSystem hit_ref_particle = null;
    // コインのパーティクル
    private ParticleSystem coin_particle;
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

    public Player_SE_Manager Player_SE_Manager
    {
        get { return player_se_script; }
        private set { player_se_script = value; }
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
        // ビルの破片の処理
        for (int i = 0; i < crash_particle.Length; i++) 
        {
            // ビル破壊時の破片のパーティクルを出す
            crash_particle[i].transform.position = bill_pos;

            // 破片のパーティクルをビルのレベルに合わせて拡大
            var crash_scale = Vector3.one * default_crash_particle_scale * billLevel;
            crash_particle[i].transform.localScale = crash_scale;
            crash_particle[i].Play();
        }

        // コインエフェクトの処理
        coin_particle.transform.position = bill_pos;
        var coin_scale = Vector3.one * default_coin_particle_scale * playerLevel;
        coin_particle.transform.localScale = coin_scale;
        // 出るコインの数
        var burst = coin_particle.emission.GetBurst(0);
        burst.count = coin_number * billLevel;
        coin_particle.emission.SetBurst(0, burst);
        coin_particle.gravityModifier = 10 * playerLevel;

        coin_particle.Play();
    }

    /// <summary>
    /// ヒットエフェクト貫通
    /// </summary>
    /// <param name="playerLevel">プレイヤーのレベル</param>
    /// <param name="hit_pos">当たった座標</param>
    public void PlayHitEffect(int playerLevel, Vector3 hit_pos)
    {
        for (int i = 0; i < hit_particle.Length; i++)
        {
            // プレイヤーと当たった場所にヒットエフェクトを移動
            hit_particle[i].transform.position = hit_pos;
            // ヒットエフェクトのパーティクルをプレイヤーのレベルに合わせて拡大
            var hit_scale = Vector3.one * default_hit_particle_scale * playerLevel;
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
        // ビルの破片エフェクトの初期化
        var crash_obj = Instantiate(crash, gameObject.transform);
        crash_particle = crash_obj.GetComponentsInChildren<ParticleSystem>();
        default_crash_particle_scale = crash_particle[0].transform.localScale.x;

        // 貫通用ヒットエフェクトの初期化
        var hit_effect_obj = Instantiate(hit_effect, gameObject.transform);
        hit_particle = hit_effect_obj.GetComponentsInChildren<ParticleSystem>();
        default_hit_particle_scale = hit_particle[0].transform.localScale.x;

        // 反射用ヒットエフェクトの初期化
        var hit_ref_effect_obj = Instantiate(hit_ref_effect, gameObject.transform);
        hit_ref_particle = hit_ref_effect_obj.GetComponent<ParticleSystem>();
        default_hit_ref_particle_scale = hit_ref_particle.transform.localScale.x;

        // コインエフェクトの初期化
        var hit_coin_obj = Instantiate(coin_effect, gameObject.transform);
        coin_particle = hit_coin_obj.GetComponent<ParticleSystem>();
        default_coin_particle_scale = coin_particle.transform.localScale.x;

        // ビルの破壊のスクリプトの初期化
        for (int i = 0; i < bill_Destroise.Length; i++)
        {
            bill_Destroise[i].Initialized(this);
        }
    }

    private void Reset()
    {
        game_manager = GameObject.Find("GameManager");
        player_level_script = game_manager.GetComponent<Player_Level_Manager>();
        destruction_rate_script = game_manager.GetComponent<Destruction_Rate_Manager>();
        bill_Destroise = GetComponentsInChildren<Bill_Destroy>();
        player_exp_script = game_manager.GetComponent<Player_Exp_Get>();
        player_se_script = game_manager.GetComponent<Player_SE_Manager>();
        time_script = game_manager.GetComponent<Time_Manager>();
    }

    public void SetCoinNumber(int coin) 
    {
        coin_number = coin;
    }
}
