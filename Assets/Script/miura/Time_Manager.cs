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
    
    // ゲームスタート時のカウントダウン
    private float time_count_down_start = 4f;
    // スタート
    private bool game_start_state = true;
    private int count_down_second = 0;

    // ゲーム終了時までの時間（ゲーム時間）
    private float time_count_down_main = 41f;
    // ゲームが終わる時間
    private float end_time = -3f;
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

    // Start is called before the first frame update
    void Start()
    {
        time_plus_rect = time_plus_obj.GetComponent<RectTransform>();
        default_time_plus_pos = time_plus_rect.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (loading_script.GetCountDownStart())
        {
            CountDown();
            GameTime();
        }

        // プラスした時間が徐々に上に行く演出
        if (time_plus_obj.activeSelf)
        {
            plus_time_count += Time.deltaTime;
            time_plus_rect.transform.position += new Vector3(0f, 0.1f, 0f);
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
            start_count_down.SetActive(true);
            time_count_down_start -= Time.deltaTime;
            count_down_second = (int)time_count_down_start;

            if (time_count_down_start > 1f)
            {
                start_count.text = "" + count_down_second;    
            }
            else if (time_count_down_start <= 1f)
            {
                start_count.text = "START";
                game_main_state = true;
                game_play_state = true;

                if (time_count_down_start < -1)
                {
                    game_start_state = false;
                    start_count_down.SetActive(false);
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
                if (end_count_down_text.gameObject.activeSelf != false)
                {
                    // ５秒前カウントダウン非表示
                    end_count_down_text.gameObject.SetActive(false);
                }
            }
            else
            {
                if (end_count_down_text.gameObject.activeSelf != true)
                {
                    // ５秒前カウントの表示
                    end_count_down_text.gameObject.SetActive(true);
                }

                end_count_down_text.text = "" + (int)(time_count_down_main + 1f);
            }

            if (game_timer.fillAmount == 0)
            {
                game_play_state = false;
                game_end_state = true;
                end_count_down_text.text = "TIME UP";
            }

            if (time_count_down_main < end_time)
            {
                SceneManager.LoadScene("Result");
            }
        }
    }

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
}
