using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Player_Level_Manager : MonoBehaviour
{
    // プレイヤーのゲームオブジェクト
    [SerializeField] private GameObject player = null;
    // プレイヤーの経験値を持っているスクリプト
    [SerializeField] private Player_Exp_Get player_get_exp_script = null;
    // 経験値ゲージ
    [SerializeField] private Image exp_slider = null;
    // レベルアップのテキスト
    [SerializeField] private GameObject level_up_text = null;
    // タイムを管理しているスクリプト
    [SerializeField] private Time_Manager time_script = null;
    // ゲームレベルを管理するスクリプト
    [SerializeField] private Game_Level_Manager game_level_script = null;
    // ビルレベルに合わせてコライダーのisTriggerを付けはずし管理する
    [SerializeField] private Bill_Level_manager bill_level_script = null;
    // レベルアップエフェクト
    [SerializeField] private ParticleSystem level_up_effect = null;
    [SerializeField] private ParticleSystem level_up_effect_ = null;
    // カメラのスクリプト
    [SerializeField] private camera_controller camera_scipt = null;
    // シングルトンクラスの取得
    [SerializeField] private Variable_Manager variable_manager_script = null;
    // レベル表記のテキスト
    [SerializeField] private TextMeshProUGUI level_text = null;

    // レベルアップに必要な経験値
    private int[] level_up_exp;
    // プレイヤーのレベル
    private int player_level = 1;
    // プレイヤーレベルの限界値
    private int player_level_max = 10;
    // プレイヤーの大きさ
    private Vector3 player_scale = new Vector3(1f, 1f, 1f);
    // プレイヤーのスケールを割る数
    private float half = 2f;
    // レベルアップゲージ用
    int gage_count = 0;
    
    [SerializeField] private Text text = null;

    // Start is called before the first frame update
    void Start()
    {
        variable_manager_script = GameObject.Find("Data_Manager").GetComponent<Variable_Manager>();

        level_up_exp = new int[player_level_max - 1];

        // レベルアップに必要な経験値の初期化
        level_up_exp[0] = 25;
        level_up_exp[1] = level_up_exp[0] + 100;
        level_up_exp[2] = level_up_exp[1] + 500;
        level_up_exp[3] = level_up_exp[2] + 1500;
        level_up_exp[4] = level_up_exp[3] + 2000;
        level_up_exp[5] = level_up_exp[4] + 2500;
        level_up_exp[6] = level_up_exp[5] + 6000;
        level_up_exp[7] = level_up_exp[6] + 10000;
        level_up_exp[8] = level_up_exp[7] + 14000;

        player = game_level_script.GetPlayer();
        
        player.transform.localScale = player_scale;

        // サイズ変更に合わせて高さを変更
        player.transform.position = new Vector3(transform.position.x, player.transform.localScale.y / half, transform.position.z);

        exp_slider.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        level_text.text = "" + player_level;

        if (time_script.GetGamePlayState())
        {
            PlayerLevelUpPhase();
        }

        text.text = "" + player_get_exp_script.GetExp();
    }

    /// <summary>
    /// プレイヤーのレベルアップとそれに合わせてサイズを変更する
    /// </summary>
    private void PlayerLevelUpPhase() 
    {
        if (player_level >= player_level_max) return;

        for (int i = player_level - 1; i < level_up_exp.Length; i++)
        {
            // 現在の経験値が指定の経験値と同じか超えるかした場合レベルアップ
            if (player_get_exp_script.GetExp() < level_up_exp[i]) continue;

            player_level = player_level + 1;

            time_script.TimeCountDownMainPlus();

            bill_level_script.BillPossible(player_level);

            LevelUpGageReset();

            level_up_text.SetActive(true);

            level_up_effect.Play();
            level_up_effect_.Play();

            if (player_level >= player_level_max)
            {
                player_level = player_level_max;
            }

            player.transform.DOScale(player_scale * player_level, 2f);

            // サイズ変更
            //player.transform.localScale = player_scale * player_level;
            // サイズ変更に合わせて高さを変更
            player.transform.position = new Vector3(player.transform.position.x, player.transform.localScale.y / half, player.transform.position.z);
            camera_scipt.ZoomCamera();
        }
    }

    /// <summary>
    /// 取得経験値をゲージに反映
    /// </summary>
    public void LevelUpGage() 
    {
        exp_slider.fillAmount = (((float)player_get_exp_script.GetExp()) / (float)level_up_exp[gage_count]);
    }

    /// <summary>
    /// レベルアップ時にゲージをリセエエエエエエエエエエエット！！
    /// </summary>
    private void LevelUpGageReset() 
    {
        gage_count++;

        exp_slider.fillAmount = 0f;
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
        player = GameObject.Find("Player");

        level_up_text = GameObject.Find("Level_Up");

        level_up_effect = player.GetComponent<ParticleSystem>();

        game_level_script = gameObject.GetComponent<Game_Level_Manager>();

        player_get_exp_script = gameObject.GetComponent<Player_Exp_Get>();


        time_script = gameObject.GetComponent<Time_Manager>();
    }
}
