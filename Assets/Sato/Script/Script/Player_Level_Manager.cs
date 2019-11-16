using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Level_Manager : MonoBehaviour
{ 
    // レベルアップに必要な経験値
    private int[] level_up_exp;
    // プレイヤーのレベル
    private int player_level = 1;
    // プレイヤーレベルの限界値
    private int player_level_max = 5;
    // プレイヤーの大きさ
    private Vector3 player_scale = new Vector3(1f, 1f, 1f);
    // レベルアップのステートマシン
    private bool level_up_phase = false;
    // プレイヤーの速度
    private float speed = 0.0f;
    // プレイヤーのスケールを割る数
    private float half = 2f;
    // プレイヤーのリジッドボディ
    private Rigidbody rb;
    // プレイヤーのゲームオブジェクト
    [SerializeField] private GameObject player = null;
    // プレイヤーの経験値を持っているスクリプト
    private Player_Exp_Get script_player;
    // デバック用
    [SerializeField] private GameObject text_ = null;
    // 経験値ゲージ
    [SerializeField] private Slider exp_slider = null;
    // レベルアップのテキスト
    [SerializeField] private GameObject level_up_text = null;
    // タイムを管理しているスクリプト
    private Time_Manager time_script;

    // Start is called before the first frame update
    void Start()
    {
        level_up_exp = new int[player_level_max];

        // レベルアップに必要な経験値の初期化
        for (int i = 0; i < level_up_exp.Length; i++)
        {
            level_up_exp[i] = 10 * (i + 1);
            level_up_exp[i] += (10 * (i + 1)) * i;
        }

        script_player = player.GetComponent<Player_Exp_Get>();

        time_script = gameObject.GetComponent<Time_Manager>();

        rb = player.gameObject.GetComponent<Rigidbody>();

        player.transform.localScale = player_scale;

        exp_slider.maxValue = level_up_exp[player_level - 1];
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

        if (script_player.GetExp() >= exp_slider.maxValue)
        {
            exp_slider.value = 0;
        }

        exp_slider.value = script_player.GetExp();

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
                    exp_slider.minValue = level_up_exp[player_level - 1];

                    player_level = player_level + 1;

                    time_script.TimeCountDownMainPlus();

                    level_up_text.SetActive(true);

                    exp_slider.maxValue = level_up_exp[player_level - 1];

                    if (player_level > player_level_max)
                    {
                        player_level = player_level_max;
                    }
                    else
                    {
                        // サイズ変更
                        player.transform.localScale = player_scale * player_level;
                        // サイズ変更に合わせて高さを変更
                        player.transform.position += new Vector3(0f, player.transform.localScale.y / half, 0f);
                    }
                    

                    
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

    /// <summary>
    /// レベル上限の設定
    /// </summary>
    /// <param name="level_max"></param>
    public void SetLevelMax(int level_max) 
    {
        player_level_max = level_max;
    }

    /// <summary>
    /// プレイヤーの大きさ設定
    /// </summary>
    /// <param name="pos"></param>
    public void SetPlayerScale(float scale) 
    {
        player_scale = new Vector3(scale, scale, scale);
    }
}
