﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Time_Manager : MonoBehaviour
{
    // スタートカウントダウンオブジェクト
    [SerializeField] private GameObject start_count_down = null;
    // カウントダウンテキスト
    [SerializeField] private TextMeshProUGUI start_count = null;
    // ゲームタイムのテキスト
    [SerializeField] private TextMeshProUGUI game_time = null;
    // カウントダウンのテキスト
    [SerializeField] private TextMeshProUGUI end_count_down_text = null;
    // 時間加算時に表示するオブジェクト
    [SerializeField] private GameObject time_plus_obj = null;
    // スタートのローディングを管理するスクリプト
    [SerializeField] private Start_Loading loading_script = null;

    // ゲームスタート時のカウントダウン
    private float time_count_down_start = 4f;
    // スタート
    private bool game_start_state = true;
    private int count_down_second = 0;

    // ゲーム終了時までの時間（ゲーム時間）
    private float time_count_down_main = 41f;
    // ゲームが終わる時間
    private float end_time = -1f;
    // ゲーム中かどうか
    private bool game_main_state = false;
    private int game_main_second = 0;

    // 増やす時間
    private float increase_time = 3f;
    // 操作等可能にするための変数
    private bool game_play_state = false;
    // プラスするタイムを表示する時間
    private float plus_time_count = 0;


    // Start is called before the first frame update
    void Start()
    {
        game_main_second = (int)time_count_down_main - 1;

        game_time.text = "" + game_main_second;
    }

    // Update is called once per frame
    void Update()
    {
        if (loading_script.GetCountDownStart())
        {
            CountDown();
            GameTime();
        }

        plus_time_count += Time.deltaTime;

        if (plus_time_count >= 2f)
        {
            time_plus_obj.SetActive(false);
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
                    game_time.gameObject.SetActive(true);
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
                game_time.text = "" + game_main_second;                
            }
            else if (time_count_down_main > 1f && time_count_down_main <= 6f)
            {
                end_count_down_text.text = "" + game_main_second;
                game_time.gameObject.SetActive(false);
                end_count_down_text.gameObject.SetActive(true);

            }
            else if (time_count_down_main <= 1f && time_count_down_main > end_time)
            {
                end_count_down_text.text = "TIME UP";
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
        plus_time_count = 0f;
        time_plus_obj.SetActive(true);
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
