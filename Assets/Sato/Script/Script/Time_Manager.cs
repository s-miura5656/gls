﻿using System.Collections;
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
    [SerializeField] private GameObject start_count_text = null;
    [SerializeField] private GameObject count = null;
    // カウントダウンテキスト
    private Text start_count_down = null;

    // ゲーム終了時までの時間（ゲーム時間）
    [SerializeField] private float time_count_down_main = 41f;
    private float end_time = -1f;
    private bool game_main_state = false;
    private int game_main_second = 0;
    private int zero_not_display = 0;
    [SerializeField] private GameObject game_time_text = null;

    // ゲームタイムのテキスト
    private Text game_time_number = null;

    // ゲーム終了間際のカウントダウン用
    [SerializeField] private GameObject end_count_text = null;

    // カウントダウンのテキスト
    private Text end_count_down = null;

    // 時間加算用
    [SerializeField] private GameObject player = null;
    // 経験値の入手のスクリプト
    private Player_Exp_Get time_exp_script = null;
    // 時間加算レベルアップ用経験値
    private int time_exp_level_table = 10;
    // 時間加算時に表示するオブジェクト
    [SerializeField] private GameObject time_plus = null;
    // メインカメラの取得
    [SerializeField] private Camera main_camara = null;
    // 増やす時間
    private float increase_time = 3f;
    // 操作等可能にするための変数
    private bool game_play_state = false;
    // ローディング画面のオブジェクト取得
    [SerializeField] private GameObject loading_screen = null;
    // スタートのローディングを管理するスクリプト
    private Start_Loading loading_script = null;

    // Start is called before the first frame update
    void Start()
    {
        time_exp_script = player.GetComponent<Player_Exp_Get>();
        start_count_down = count.GetComponent<Text>();
        game_time_number = game_time_text.GetComponent<Text>();
        end_count_down = end_count_text.GetComponent<Text>();
        loading_script = loading_screen.GetComponent<Start_Loading>();
    }

    // Update is called once per frame
    void Update()
    {
        if (loading_script.GetCountDownStart())
        {
            CountDown();
            GameTime();
        }
    }

    /// <summary>
    /// ゲーム開始のカウントダウン
    /// </summary>
    private void CountDown() 
    {
        if (game_start_state)
        {
            start_count_text.SetActive(true);
            time_count_down_start -= Time.deltaTime;
            count_down_second = (int)time_count_down_start;

            if (time_count_down_start > 1f)
            {
                start_count_down.text = count_down_second.ToString();
            }
            else if (time_count_down_start <= 1f)
            {
                //start_count_text.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                start_count_down.text = "START";
                game_main_state = true;
                game_play_state = true;

                if (time_count_down_start < -1)
                {
                    game_start_state = false;
                    start_count_text.SetActive(false);
                    game_time_text.SetActive(true);
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
            time_count_down_main -= Time.deltaTime;
            game_main_second = (int)time_count_down_main;

            if (time_count_down_main > 6f)
            {
                game_time_number.text = game_main_second.ToString();                
            }
            else if (time_count_down_main > 1f && time_count_down_main <= 6f)
            {
                end_count_down.text = game_main_second.ToString();
                game_time_text.SetActive(false);
                end_count_text.SetActive(true);

            }
            else if (time_count_down_main <= 1f && time_count_down_main > end_time)
            {
                end_count_down.text = "TIME UP";
                game_play_state = false;
            }
            else if (time_count_down_main < end_time)
            {
                game_main_state = false;
                SceneManager.LoadScene("Result");
            }
        }
    }

    public void TimeCountDownMainPlus() 
    {
        GameObject one_copy = Instantiate(time_plus, new Vector3(player.transform.position.x, player.transform.position.y * 2, player.transform.position.z), transform.rotation);
        one_copy.GetComponent<CameraLookSprite>().SetCamera(main_camara);
        time_count_down_main += increase_time;
    }

    /// <summary>
    /// 操作可能かどうか
    /// </summary>
    /// <returns></returns>
    public bool GetGamePlayState() { return game_play_state; }

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