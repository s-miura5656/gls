using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Time_Manager : MonoBehaviour
{
    // ゲームスタート時のカウントダウン
    private float time_count_down = 4f;
    private float count_zero = 0f;
    private bool game_start_state = true;
    private int count_down_second = 0;
    [SerializeField] private GameObject count_down_text;

    // ゲーム終了時までの時間（ゲーム時間）
    private float time_count_up = 0f;
    private float end_time = 31f;
    private bool game_end_state = true;
    private int game_time_second = 0;
    private int zero_not_display = 0;
    [SerializeField] private GameObject game_time_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CountDown();
        GameTime();
    }

    private void CountDown() 
    {
        if (game_start_state)
        {
            time_count_down -= Time.deltaTime;

            if (time_count_down > count_zero)
            {
                count_down_second = (int)time_count_down;
                Text _text = count_down_text.GetComponent<Text>();
                _text.text = count_down_second.ToString();
            }
            else
            {
                count_down_text.SetActive(false);
                game_time_text.SetActive(true);
                game_start_state = false;
            }
        }
    }

    private void GameTime() 
    {
        if (game_end_state && game_start_state == false)
        {
            time_count_up += Time.deltaTime;

            if (time_count_up < end_time)
            {
                game_time_second = (int)time_count_up;

                Text _text = game_time_text.GetComponent<Text>();

                if (game_time_second > zero_not_display)
                {
                    _text.text = game_time_second.ToString();
                }
            }
            else
            {
                game_end_state = false;
                SceneManager.LoadScene("Resalt_");
            }
        }
    }
}
