using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Level_Manager : MonoBehaviour
{ 
    // レベルアップに必要な経験値
    private int[] level_up_exp = new int[5];
    // プレイヤーのレベル
    private int player_level = 1;
    // プレイヤーレベルの限界値
    private int player_level_max = 10;
    // プレイヤーの大きさ
    private Vector3 player_scale = new Vector3(4f, 4f, 4f);
    // レベルアップのステートマシン
    private bool level_up_phase = false;
    // プレイヤーの速度
    private float speed = 0.0f;
    // プレイヤーのリジッドボディ
    private Rigidbody rb;
    // プレイヤーのゲームオブジェクト
    [SerializeField] private GameObject player;
    // プレイヤーの経験値を持っているスクリプト
    private Player_Exp_Get script_player;
    // デバック用
    [SerializeField] private GameObject text_;
    
    // Start is called before the first frame update
    void Start()
    {
        // レベルアップに必要な経験値の初期化
        for (int i = 0; i < level_up_exp.Length; i++)
        {
            level_up_exp[i] = level_up_exp[i] + (20 * (i + 1));
        }

        script_player = player.GetComponent<Player_Exp_Get>();

        rb = player.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの速度の計算
        speed = rb.velocity.magnitude;

        // スピードが０になったらレベルアップ
        if (speed <= 1.0f)
        {
            if (level_up_phase == false)
            {
                PlayerLevelUpPhase();
                level_up_phase = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            level_up_phase = false;
        }

        //Text _text = text_.GetComponent<Text>();
        //_text.text = "" + speed;
    }

    /// <summary>
    /// プレイヤーのレベルアップとそれに合わせてサイズを変更する
    /// </summary>
    private void PlayerLevelUpPhase() 
    {
        if (player_level < player_level_max)
        {
            for (int i = player_level - 1; i < level_up_exp.Length; i++)
            {
                // 現在の経験値が指定の経験値と同じか超えるかした場合レベルアップ
                if (script_player.GetExp() >= level_up_exp[i])
                {
                    player_level = player_level + 1;

                    if (player_level > player_level_max)
                    {
                        player_level = player_level_max;
                    }

                    // サイズ変更
                    player.transform.localScale = player_scale * player_level;

                    // サイズ変更に合わせて高さを変更
                    player.transform.position += new Vector3(0f, 2f, 0f);
                }
            }
        }

        
    }

    /// <summary>
    /// プレイヤーの現在のレベル
    /// </summary>
    /// <returns></returns>
    public int GetLevel() { return player_level; }

    /// <summary>
    /// プレイヤーの速度
    /// </summary>
    /// <returns></returns>
    public float GetSpeed() { return speed; }
}
