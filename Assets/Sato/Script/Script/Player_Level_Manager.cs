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
    // プレイヤーのスケールを割る数
    private float half = 2f;
    // プレイヤーのゲームオブジェクト
    [SerializeField] private GameObject player = null;
    // プレイヤーの経験値を持っているスクリプト
    private Player_Exp_Get player_get_exp_script;
    // 経験値ゲージ
    [SerializeField] private Slider exp_slider = null;
    // レベルアップのテキスト
    [SerializeField] private GameObject level_up_text = null;
    // タイムを管理しているスクリプト
    private Time_Manager time_script;
    // ゲームマネージャーの取得
    private Game_Level_Manager game_level_script = null;
    // Start is called before the first frame update
    void Start()
    {
        level_up_exp = new int[player_level_max - 1];

        // レベルアップに必要な経験値の初期化
        level_up_exp[0] = 20;
        level_up_exp[1] = 60;
        level_up_exp[2] = 560;
        level_up_exp[3] = 1560;
        level_up_exp[4] = 4560;
        level_up_exp[5] = 20000;
        level_up_exp[6] = 30000;
        level_up_exp[7] = 40000;
        level_up_exp[8] = 50000;

        game_level_script = gameObject.GetComponent<Game_Level_Manager>();

        player = game_level_script.GetPlayer();

        player_get_exp_script = gameObject.GetComponent<Player_Exp_Get>();

        time_script = gameObject.GetComponent<Time_Manager>();

        player.transform.localScale = player_scale;

        // サイズ変更に合わせて高さを変更
        player.transform.position = new Vector3(transform.position.x, player.transform.localScale.y / half, transform.position.z);

        exp_slider.maxValue = level_up_exp[player_level - 1];
    }

    // Update is called once per frame
    void Update()
    {
        if (time_script.GetGamePlayState())
        {
            PlayerLevelUpPhase();
        }

        if (player_get_exp_script.GetExp() >= exp_slider.maxValue)
        {
            exp_slider.value = 0;
        }

        exp_slider.value = player_get_exp_script.GetExp();
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
                if (player_get_exp_script.GetExp() >= level_up_exp[i])
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
                        player.transform.position = new Vector3(player.transform.position.x, player.transform.localScale.y / half, player.transform.position.z);
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

    private void Reset()
    {
        level_up_text = GameObject.Find("Level_Up");

        exp_slider = GameObject.Find("ExpGage").GetComponent<Slider>();
    }
}
