using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bill_Obsever : MonoBehaviour
{
    // プレイヤーのレベルを取得するためのオブジェクト取得
    [SerializeField] private GameObject game_manager = null;
    // データマネージャーの取得
    [SerializeField] private GameObject data_manager = null;
    // プレイヤーのレベルのスクリプトの取得
    [SerializeField] private Player_Level_Manager player_level_script = null;
    // ヒットストップのスクリプトを取得
    [SerializeField] private Hit_Stop_Manager hit_stop_script = null;
    // 破壊率を管理しているスクリプトを取得
    [SerializeField] private Destruction_Rate_Manager destruction_rate_script = null;
    // 経験値を管理しているスクリプトを取得
    [SerializeField] private Player_Exp_Get player_exp_script = null;
    // ビルにヒットした時の音を管理しているスクリプト
    [SerializeField] private Player_SE_Manager player_se_script = null;
    // ゲームの時間を管理しているスクリプト
    [SerializeField] private Time_Manager time_script = null;
    // ゲーム全体のデータを管理しているスクリプト
    [SerializeField] private Variable_Manager variable_script;
    // ビルについている破壊に関するスクリプトを取得
    [SerializeField] private Bill_Destroy[] bill_Destroise = null;
    // 壊れるパーティクル
    private ParticleSystem[] crash_particle;
    // ヒットエフェクト
    private ParticleSystem[] hit_particle;
    // コインのパーティクル
    private ParticleSystem coin_particle;

    private float default_crash_particle_scale = 0.0f;
    private float default_hit_particle_scale = 0.0f;
    private float default_coin_particle_scale = 0.0f;
    private int coin_number = 1;

    public Player_Level_Manager Player_Level_Manager
    {
        get { return player_level_script; }
        private set { player_level_script = value; }
    }

    public Hit_Stop_Manager Hit_Stop_Manager
    {
        get { return hit_stop_script; }
        private set { hit_stop_script = value; }
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

    public Variable_Manager Variable_Manager
    {
        get { return variable_script; }
        private set { variable_script = value; }
    }

    [System.Obsolete]
    public void PlayCrashEffect(int billLevel, Vector3 bill_pos, int playerLevel, int coin)
    {
        // ビルの破片の処理
        for (int i = 0; i < crash_particle.Length; i++) 
        {
            // ビル破壊時の破片のパーティクルを出す
            crash_particle[i].transform.position = bill_pos;
            // 破片のパーティクルをビルのレベルに合わせて拡大
            var cras_scale = Vector3.one * default_crash_particle_scale * billLevel;
            crash_particle[i].transform.localScale = cras_scale;

            crash_particle[i].Play();
        }

        // コインエフェクトの処理
        coin_particle.transform.position = bill_pos;
        var coin_scale = Vector3.one * default_coin_particle_scale * playerLevel;
        coin_particle.transform.localScale = coin_scale;

        var burst = coin_particle.emission.GetBurst(0);
        burst.count = coin_number * billLevel;
        coin_particle.emission.SetBurst(0, burst);
        coin_particle.gravityModifier = 10 * playerLevel;

        coin_particle.Play();
    }

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

    private void Start()
    {
        var crash = (GameObject)Resources.Load("Collapse_Effect");
        var crash_obj = Instantiate(crash, gameObject.transform);
        crash_particle = crash_obj.GetComponentsInChildren<ParticleSystem>();
        default_crash_particle_scale = crash_particle[0].transform.localScale.x;

        var hit_effect = (GameObject)Resources.Load("hit");
        var hit_effect_obj = Instantiate(hit_effect, gameObject.transform);
        hit_particle = hit_effect_obj.GetComponentsInChildren<ParticleSystem>();
        default_hit_particle_scale = hit_particle[0].transform.localScale.x;

        var hit_coin = (GameObject)Resources.Load("Coin_Test");
        var hit_coin_obj = Instantiate(hit_coin, gameObject.transform);
        coin_particle = hit_coin_obj.GetComponent<ParticleSystem>();
        default_coin_particle_scale = coin_particle.transform.localScale.x;

        for (int i = 0; i < bill_Destroise.Length; i++)
        {
            bill_Destroise[i].Initialized(this);
        }
    }

    private void Reset()
    {
        game_manager = GameObject.Find("GameManager");
        data_manager = GameObject.Find("Data_Manager");
        player_level_script = game_manager.GetComponent<Player_Level_Manager>();
        hit_stop_script = game_manager.GetComponent<Hit_Stop_Manager>();
        destruction_rate_script = game_manager.GetComponent<Destruction_Rate_Manager>();
        bill_Destroise = GetComponentsInChildren<Bill_Destroy>();
        player_exp_script = game_manager.GetComponent<Player_Exp_Get>();
        player_se_script = game_manager.GetComponent<Player_SE_Manager>();
        time_script = game_manager.GetComponent<Time_Manager>();
        variable_script = data_manager.GetComponent<Variable_Manager>();
    }

    public void SetCoinNumber(int coin) 
    {
        coin_number = coin;
    }
}
