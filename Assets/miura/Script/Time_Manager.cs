using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Time_Manager : MonoBehaviour
{
    // ゲームスタート時のカウントダウン
    private float time_count_down_start = 4f;
    private float count_zero = 0f;
    private bool game_start_state = true;
    private int count_down_second = 0;
    [SerializeField] private GameObject count_down_text;

    // ゲーム終了時までの時間（ゲーム時間）
    private float time_count_down_main = 31f;
    private float end_time = 0f;
    private bool game_main_state = false;
    private int game_main_second = 0;
    private int zero_not_display = 0;
    [SerializeField] private GameObject game_time_text;

    // 時間加算用
    [SerializeField] GameObject player;
    // 経験値の入手のスクリプト
    private Player_Exp_Get time_exp_script;
    // 時間加算レベルアップ用経験値
    private int time_exp_level_table = 10;
    // 時間加算時に表示するオブジェクト
    [SerializeField] private GameObject one_plus;
    // メインカメラの取得
    [SerializeField] private Camera main_camara = null; 

    // Start is called before the first frame update
    void Start()
    {
        time_exp_script = player.GetComponent<Player_Exp_Get>();
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
        GameTime();
        TimeCountDownMainPlus();
    }

    /// <summary>
    /// ゲーム開始のカウントダウン
    /// </summary>
    private void CountDown() 
    {
        if (game_start_state)
        {
            time_count_down_start -= Time.deltaTime;

            if (time_count_down_start > count_zero)
            {
                count_down_second = (int)time_count_down_start;
                Text _text = count_down_text.GetComponent<Text>();
                _text.text = count_down_second.ToString();
            }
            else
            {
                count_down_text.SetActive(false);
                game_time_text.SetActive(true);
                game_start_state = false;
                game_main_state = true;
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
            time_count_down_main -= Time.deltaTime;

            if (time_count_down_main >= end_time)
            {
                game_main_second = (int)time_count_down_main;

                Text _text = game_time_text.GetComponent<Text>();

                if (game_main_second >= zero_not_display)
                {
                    _text.text = game_main_second.ToString();
                }
            }
            else
            {
                game_main_state = false;
                SceneManager.LoadScene("Resalt_");
            }
        }
    }

    private void TimeCountDownMainPlus() 
    {
        if (time_exp_level_table <= time_exp_script.GetTimeExp())
        {
            GameObject one_copy = Instantiate(one_plus, new Vector3(player.transform.position.x, player.transform.position.y * 2, player.transform.position.z), transform.rotation);
            one_copy.GetComponent<CameraLookSprite>().SetCamera(main_camara);
            time_count_down_main += 1f;
            time_exp_level_table = time_exp_level_table + 10;
            time_exp_script.TimeExpReset();
        }
    }

    /// <summary>
    /// ゲームメインのステート
    /// </summary>
    /// <returns></returns>
    public bool GetGameMainState() { return game_main_state; }
}
