using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Time_Manager : MonoBehaviour
{
    // スタートカウントダウンオブジェクト
    [SerializeField] private GameObject start_count_down = null;
    // スタートカウントダウンテキスト
    [SerializeField] private TextMeshProUGUI start_count = null;
    // エンドカウントダウンのテキスト
    [SerializeField] private TextMeshProUGUI end_count_down_text = null;
    // 時間加算時に表示するオブジェクト
    [SerializeField] private GameObject time_plus_obj = null;
    // スタートのローディングを管理するスクリプト
    [SerializeField] private Start_Loading loading_script = null;
    // 回転する時計のイメージ
    [SerializeField] private Image game_timer = null;
    // ゲームの時間（テキスト）
    [SerializeField] private TextMeshProUGUI game_timer_text = null;
    // ボーナスボタン
    [SerializeField] private GameObject continue_botton = null;
    // ゲームUI
    [SerializeField] private GameObject game_ui = null;
    // 現在の破壊率を表示するオブジェクト
    [SerializeField] private GameObject now_dest_rate = null;
    // ゲームスタート時のカウントダウン
    private float time_count_down_start = 3f;
    // スタート
    private bool game_start_state = true;
    // ゲーム終了時までの時間（ゲーム時間）
    private float time_count_down_main = 30f;
    // ゲーム中かどうか
    private bool game_main_state = false;
    // 増やす時間
    private float increase_time = 3f;
    // 操作等可能にするための変数
    private bool game_play_state = false;
    // プラスするタイムを表示する時間
    private float plus_time_count = 0;
    // 追加される時間のテキストのポジション
    private RectTransform time_plus_rect = null;
    // 追加される時間のテキストの初期位置
    private Vector3 default_time_plus_pos = Vector3.zero;
    // ゲームが終了した時のステート
    private bool game_end_state = false;
    // ゲームが終了後に時間プラスするかどうかのステート
    private bool bonus_time_state = true;
    // 破壊率を入れる変数
    private float destruction_rate = 0f;
    // ボーナスボタンを表示させるための破壊率
    private float show_button_min = 20f;
    private float show_button_max = 100f;

    // Start is called before the first frame update
    void Start()
    {
        time_plus_rect = time_plus_obj.GetComponent<RectTransform>();
        default_time_plus_pos = time_plus_rect.transform.position;
        game_timer_text.text = "" + (int)time_count_down_main;
    }

    // Update is called once per frame
    void Update()
    {
        if (loading_script.GetCountDownStart)
        {
            now_dest_rate.SetActive(true);
            CountDown();
            GameTime();
            TargetDestRate();
        }

        // プラスした時間が徐々に上に行く演出
        if (time_plus_obj.activeSelf)
        {
            plus_time_count += Time.deltaTime;
            time_plus_rect.transform.position += new Vector3(0f, 0.2f, 0f);
            if (plus_time_count >= 2f)
            {
                time_plus_rect.transform.position = default_time_plus_pos;
                time_plus_obj.SetActive(false);
            }
        }
    }

    /// <summary>
    /// ゲーム開始のカウントダウン
    /// </summary>
    private void CountDown() 
    {
        if (game_start_state)
        {
            time_count_down_start -= Time.deltaTime;

            // カウントダウン表示用
            int count_down_second = (int)time_count_down_start;

            if (time_count_down_start >= 1f)
            {
                start_count_down.SetActive(true);

                if (bonus_time_state)
                {
                    start_count.text = "Ready";
                }
                else
                {
                    start_count.text = "" + count_down_second;
                }
            }
            else if (time_count_down_start < 1f)
            {
                start_count.text = "Go!!";
                game_main_state = true;
                game_play_state = true;

                if (time_count_down_start < -1)
                {
                    game_start_state = false;
                    start_count_down.SetActive(false);
                    time_count_down_start = 4f;
                }
            }
        }
    }

    /// <summary>
    /// ゲーム中のカウントダウン
    /// </summary>
    private void GameTime() 
    {
        if (game_main_state)
        {
            // ゲーム時間（時計型ゲージ）
            time_count_down_main -= Time.deltaTime;

            if (time_count_down_main > -1f)
            {
                // タイマーゲージのアニメーション
                game_timer.fillAmount = game_timer.fillAmount - ((game_timer.fillAmount / time_count_down_main) * Time.deltaTime);
            }
            else
            {
                game_timer.fillAmount = 0f;
            }

            // ゲーム時間（数字）
            if (time_count_down_main > 0)
            {
                game_timer_text.text = "" + ((int)time_count_down_main + 1);
            }
            else
            {
                game_timer_text.text = "0";
            }

            if (time_count_down_main > 5f)
            {
                // ５秒前カウントダウン中にタイムが増えたとき用の５秒前のカウントダウン非表示
                if (end_count_down_text.gameObject.activeSelf)
                {
                    // ５秒前カウントダウン非表示
                    end_count_down_text.gameObject.SetActive(false);
                }
            }
            else
            {
                if (!end_count_down_text.gameObject.activeSelf)
                {
                    // ５秒前カウントの表示
                    end_count_down_text.gameObject.SetActive(true);
                }

                end_count_down_text.text = "" + (int)(time_count_down_main + 1f);
            }

            if (time_count_down_main <= 0f)
            {
                game_main_state = false;
                game_play_state = false;
                game_end_state = true;

                if (bonus_time_state)
                {
                    if (destruction_rate > show_button_min && destruction_rate < show_button_max)
                    {
                        continue_botton.SetActive(true);
                        end_count_down_text.gameObject.SetActive(false);
                        bonus_time_state = false;
                    }
                    else
                    {
                        end_count_down_text.text = "TIME UP";
                    }
                }
                else
                {
                    end_count_down_text.text = "TIME UP";
                }
            }
        }
    }

    /// <summary>
    /// ゲーム時間に時間を追加する
    /// </summary>
    public void TimeCountDownMainPlus() 
    {
        plus_time_count = 0f;
        time_plus_obj.SetActive(true);
        time_count_down_main += increase_time;
        game_timer.fillAmount += (game_timer.fillAmount / time_count_down_main);
    }

    /// <summary>
    /// 操作可能かどうか
    /// </summary>
    /// <returns></returns>
    public bool GetGamePlayState 
    {
        get { return game_play_state; } 
    }

    /// <summary>
    /// ゲームのメインが終了しているかどうか
    /// </summary>
    public bool GetGameEndState 
    {
        get { return game_end_state; }
    }

    /// <summary>
    /// 制限時間
    /// </summary>
    /// <param name="time_max"></param>
    public void SetGameTime(float time_max) 
    {
        time_count_down_main = time_max;
    }

    /// <summary>
    /// レベルアップ時の増える時間
    /// </summary>
    /// <param name="time"></param>
    public void SetIncreaseTime(float time) 
    {
        increase_time = time;
    }

    /// <summary>
    /// ボーナスタイムの時間の処理
    /// </summary>
    /// <param name="bonus_time">ボーナスで追加する時間</param>
    public void BonusTime(float bonus_time) 
    {
        time_count_down_main = bonus_time;
        start_count_down.SetActive(true);
        game_start_state = true;
        game_end_state = false;
        game_timer.fillAmount = 1f;
        game_timer_text.text = "" + ((int)time_count_down_main );
    }

    /// <summary>
    /// 破壊率100%達成時の処理
    /// </summary>
    private void TargetDestRate() 
    {
        if (destruction_rate < 100)
            return;

        bonus_time_state = false;
        game_main_state = false;
        game_play_state = false;

        if (!game_end_state)
            ChangeResult();

        game_end_state = true;
    }

    /// <summary>
    /// リザルトシーンを表示させる
    /// </summary>
    public void ChangeResult() 
    {
        Variable_Manager.Instance.GetSetDestructionRate = destruction_rate;
        SceneManager.LoadScene("new_Result", LoadSceneMode.Additive);
        game_ui.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="last_destruction_rate">破壊率を入れる</param>
    public void DestructionRate(float last_destruction_rate) 
    { 
        destruction_rate = last_destruction_rate; 
    }
}
