using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Monetization;

public class Timer_Extension : MonoBehaviour
{
    [SerializeField] private GameObject continue_button = null;
    [SerializeField] private Button timerButton = null;
    [SerializeField] private Image ring = null;
    [SerializeField] private Time_Manager time_manager_script = null;
    [SerializeField] private Destruction_Rate_Manager destruction_rate_script = null;
    private ShowAdCallbacks showAdTimerCallbacks = new ShowAdCallbacks();

    // ボタンが出ている時間
    private float continue_time = 5f;
    // リザルトへ遷移するまでの時間のカウント
    private float wait_result_count = 0f;
    // リザルトへ遷移する時間
    private float change_result_time = 3f;
    // 一回だけリザルトを読み込むフラグ
    private bool load_result = true;

    void Start()
    {
        showAdTimerCallbacks.finishCallback += VideoRerwardTimer;

        timerButton.onClick.AddListener(() => UnityAdsUtility.Instance.ShowVideoReward(showAdTimerCallbacks));
    }

    // Update is called once per frame
    void Update()
    {
        if (!load_result)
                return;

        if (continue_button.activeSelf && !time_manager_script.GetGamePlayState)
        {
            TimeOut();
        }
        else if(!continue_button.activeSelf && time_manager_script.GetGameEndState)
        {
            wait_result_count += Time.deltaTime;

            if (wait_result_count >= change_result_time && load_result)
            {
                time_manager_script.ChangeResult();
                destruction_rate_script.SetDestructionRate();
                load_result = false;
            }
        }
    }

    private void OnDestroy()
    {
        showAdTimerCallbacks.finishCallback -= VideoRerwardTimer;
    }

    private void VideoRerwardTimer(ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            // 広告を最後まで視聴した時
            ContinueInput(true);
            load_result = true;
        }
        else if (showResult == ShowResult.Failed)
        {
            // 広告読み込みエラー
            ContinueInput(false);
        }
        else if (showResult == ShowResult.Skipped)
        {
            // 広告をスキップした時
            ContinueInput(false);
        }
    }

    /// <summary>
    /// 時間をプラスするかしないか
    /// </summary>
    /// <param name="time_plus">true = プラス false = リザルトへ</param>
    private void ContinueInput(bool time_in) 
    {
        if (time_in)
        {
            time_manager_script.BonusTime(5f);

            continue_button.SetActive(false);
        }
        else
        {
            time_manager_script.ChangeResult();
            destruction_rate_script.SetDestructionRate();
            continue_button.SetActive(false);
        }
    }

    /// <summary>
    /// 一定時間後にリザルトへ遷移
    /// </summary>
    private void TimeOut() 
    {
        ring.fillAmount -= Time.deltaTime / continue_time;

        if (ring.fillAmount <= 0)
        {
            ContinueInput(false);
            load_result = false;
        }
    }
}
