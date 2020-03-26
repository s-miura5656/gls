using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Smoke : MonoBehaviour
{
    // 動いてる時の土煙
    [SerializeField] private ParticleSystem smoke = null;
    // プレイヤーのレベルを管理してるスクリプト
    [SerializeField] private Player_Level_Manager player_level_script = null;
    // プレイヤーパラメーター
    [SerializeField] private PlayerParametor player_parametor_script = null;
    // プレイヤーのリジッドボディ
    [SerializeField] private Rigidbody rb = null;
    // プレイヤー
    [SerializeField] private GameObject player = null;
    // 土煙をプレイヤーレベルに合わせて大きくするためのステートマシン
    private bool smoke_scale_up_state = true;
    // 土煙のベースサイズ
    private Vector3 smoke_scale_base = Vector3.one;

    // Start is called before the first frame update
    void Start()
    {
        smoke_scale_base = player_parametor_script.SmokeSize;
        smoke.transform.localScale = smoke_scale_base * player_level_script.GetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの土煙
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - player.transform.localScale.y / 2, player.transform.position.z);

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

    private void Reset()
    {
        smoke = gameObject.GetComponent<ParticleSystem>();
    }
}
