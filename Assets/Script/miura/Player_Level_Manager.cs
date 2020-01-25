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
    // 経験値ゲージ用のキャンバス
    [SerializeField] private RectTransform gage_canvas = null;
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
    // レベルアップのエフェクトの親オブジェクト
    [SerializeField] private GameObject level_up_effect_obj = null;
    // カメラのスクリプト
    [SerializeField] private camera_controller camera_scipt = null;
    // プレイヤーパラメーターの取得
    [SerializeField] private PlayerParametor player_parametor = null;

    // レベルアップに必要な経験値
    private int[] level_up_exp;
    // プレイヤーのレベル
    private int player_level = 1;
    // プレイヤーレベルの限界値
    private int player_level_max = 10;
    // プレイヤーの大きさ
    private Vector3[] player_scale = new Vector3[10];
    // プレイヤーのスケールを割る数
    private float half = 2f;
    // 経験値ゲージの一番最初のサイズ
    private Vector3 default_gage_size = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        player_level_max = player_parametor.PlayerLevelMax;

        level_up_exp = new int[player_level_max - 1];

        player_scale = new Vector3[player_level_max];

        // レベルごとの必要経験値の初期化
        for (int i = 0; i < level_up_exp.Length; i++)
        {
            level_up_exp[i] = player_parametor.PlayerLevelUpExp[i];
        }

        // レベルごとのサイズの初期化
        for (int i = 0; i < player_scale.Length; i++)
        {
            player_scale[i] = Vector3.one * player_parametor.PlayerScale[i];
        }

        if (Variable_Manager.Instance.GetSetAvatarNumber == 13)
        {
            player_level = 5;
            gage_canvas.transform.localScale = default_gage_size * player_level;
            player.transform.DOScale(player_scale[player_level - 1], 2f);
            camera_scipt.ZoomCamera(player_level);
        }

        player = game_level_script.GetPlayer();

        player.transform.localScale = player_scale[0];

        bill_level_script.BillPossible(player_level);

        // サイズ変更に合わせて高さを変更
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + (player.transform.localScale.y / half), player.transform.position.z);

        default_gage_size = gage_canvas.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (time_script.GetGamePlayState)
        {
            PlayerLevelUpPhase();
        }

        // サイズ変更に合わせて高さを変更
        //player.transform.position = new Vector3(player.transform.position.x, player.transform.localScale.y / half, player.transform.position.z);

        gage_canvas.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - ((player.transform.localScale.y / 2) + 0.3f), player.transform.position.z);

        ExpGage();
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
            if (player_get_exp_script.PlayerExp < level_up_exp[i]) continue;

            player_level = player_level + 1;

            // 時間をプラスする
            time_script.TimeCountDownMainPlus();

            // ビルとの破壊判定
            bill_level_script.BillPossible(player_level);

            // EXPのリセット
            player_get_exp_script.PlayerExp = 0;

            // EXPゲージのサイズをレベルに合わせて大きくする
            gage_canvas.transform.localScale = default_gage_size * player_level;

            // レベルアップ表示のアクティブ化
            level_up_text.SetActive(true);

            // レベルアップのエフェクトの再生
            PlayLevelUpEffect();

            // レベルが最大よりも上がらなくなる
            if (player_level >= player_level_max)
            {
                player_level = player_level_max;
            }

            // サイズ変更
            player.transform.DOScale(player_scale[player_level - 1], 2f);

            // カメラ位置をレベルに合わせて変更
            camera_scipt.ZoomCamera(player_level);
        }
    }

    /// <summary>
    /// レベルアップエフェクト再生
    /// </summary>
    private void PlayLevelUpEffect()
    {
        GameObject childObject = Instantiate(level_up_effect_obj);
        childObject.transform.localScale *= (float)player_level;
        childObject.transform.position = player.transform.position;
    }

    /// <summary>
    /// 経験値ゲージを経験値に合わせてゲージを動かす
    /// </summary>
    private void ExpGage()
    {
        if (player_level >= player_level_max)
            return;

        exp_slider.fillAmount = (float)player_get_exp_script.PlayerExp / (float)level_up_exp[player_level - 1];
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
    public int PlayerLevelMax
    {
        get { return player_level_max; }
    }

    private void Reset()
    {
        player = GameObject.Find("Player");

        level_up_text = GameObject.Find("Level_Up");

        game_level_script = gameObject.GetComponent<Game_Level_Manager>();

        player_get_exp_script = gameObject.GetComponent<Player_Exp_Get>();

        time_script = gameObject.GetComponent<Time_Manager>();
    }
}
