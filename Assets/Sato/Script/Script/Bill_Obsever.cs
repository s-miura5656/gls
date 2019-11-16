using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bill_Obsever : MonoBehaviour
{
    // プレイヤーのレベルを取得するためのオブジェクト取得
    [SerializeField] private GameObject game_manager;
    // プレイヤーのレベルのスクリプトの取得
    [SerializeField] private Player_Level_Manager player_level_script;
    // ヒットストップのスクリプトを取得
    [SerializeField] private Hit_Stop_Manager hit_stop_script;
    // 破壊率を管理しているスクリプトを取得
    [SerializeField] private Destruction_Rate_Manager destruction_rate_script;

    [SerializeField] private Bill_Destroy[] bill_Destroise = null;

    // 壊れるパーティクル
    private ParticleSystem[] crash_particle;
    // ヒットエフェクト
    private ParticleSystem hit_particle;

    private float default_crash_particle_scale = 0.0f;
    private float default_hit_particle_scale = 0.0f;

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

    public Destruction_Rate_Manager Destruction_Rate_Manager 
    {
        get { return destruction_rate_script; }
        private set { destruction_rate_script = value; }
    }

    public void PlayCrashEffect(int billLevel, Vector3 bill_pos)
    {
        for (int i = 0; i < crash_particle.Length; i++) 
        {
            // ビル破壊時の破片のパーティクルを出す
            crash_particle[i].transform.position = bill_pos;
            // 破片のパーティクルをビルのレベルに合わせて拡大
            var cras_scale = Vector3.one * default_crash_particle_scale * billLevel;
            crash_particle[i].transform.localScale = cras_scale;

            crash_particle[i].Play();
        }
    }

    public void PlayHitEffect(int playerLevel, Vector3 hit_pos)
    {
        // プレイヤーと当たった場所にヒットエフェクト生成
        hit_particle.transform.position = hit_pos;
        // ヒットエフェクトのパーティクルをビルのレベルに合わせて拡大
        var hit_scale = Vector3.one * default_hit_particle_scale * playerLevel;
        hit_particle.transform.localScale = hit_scale;

        hit_particle.Play();
    }

    private void Start()
    {
        var crash = (GameObject)Resources.Load("Collapse_Effect");
        var crashObj = Instantiate(crash, gameObject.transform);
        crash_particle = crashObj.GetComponentsInChildren<ParticleSystem>();
        default_crash_particle_scale = crash_particle[0].transform.localScale.x;

        var hit_effect = (GameObject)Resources.Load("Hit_Effect_1");
        var hit_effect_obj = Instantiate(hit_effect, gameObject.transform);
        hit_particle = hit_effect_obj.GetComponent<ParticleSystem>();
        default_hit_particle_scale = hit_particle.transform.localScale.x;

        for (int i = 0; i < bill_Destroise.Length; i++)
        {
            bill_Destroise[i].Initialized(this);
        }
    }

    private void Reset()
    {
        game_manager = GameObject.Find("GameManager");
        player_level_script = game_manager.GetComponent<Player_Level_Manager>();
        hit_stop_script = game_manager.GetComponent<Hit_Stop_Manager>();
        destruction_rate_script = game_manager.GetComponent<Destruction_Rate_Manager>();

        bill_Destroise = GetComponentsInChildren<Bill_Destroy>();
    }
}
