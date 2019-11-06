using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Smoke : MonoBehaviour
{
    // 動いてる時の土煙
    [SerializeField] private ParticleSystem smoke;
    // ゲームマネージャーの取得
    [SerializeField] private GameObject game_manager;
    // プレイヤーのレベルを管理してるスクリプト
    private Player_Level_Manager player_level_script;
    // プレイヤーのリジッドボディ
    private Rigidbody rb;
    // 土煙をプレイヤーレベルに合わせて大きくするためのステートマシン
    private bool smoke_scale_up_state = true;
    // 土煙のベースサイズ
    private Vector3 smoke_scale_base = new Vector3(4f, 4f, 4f);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player_level_script = game_manager.GetComponent<Player_Level_Manager>();
        smoke.transform.localScale = smoke_scale_base * player_level_script.GetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        // 速度が0.1以上なら
        if (rb.velocity.magnitude > 15f)
        {
            smoke_scale_up_state = true;

            // 再生
            if (!smoke.isEmitting)
            {
                smoke.Play();
            }
        }
        else
        {
            // 停止
            if (smoke.isEmitting)
            {
                smoke.Stop();
            }

            if (smoke_scale_up_state)
            {
                // スモークをプレイヤーレベルに合わせて大きくする
                smoke.transform.localScale = smoke_scale_base * player_level_script.GetLevel();

                smoke_scale_up_state = false;
            } 
        }
    }
}
