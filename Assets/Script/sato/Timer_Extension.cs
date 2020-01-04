using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Monetization;

public class Timer_Extension : MonoBehaviour
{

    [SerializeField] private Button timerButton = null;
    [SerializeField] private Image ring = null;
    [SerializeField] private Time_Manager time_manager_script = null;
    private ShowAdCallbacks showAdTimerCallbacks = new ShowAdCallbacks();
    
    void Start()
    {
        showAdTimerCallbacks.finishCallback += VideoRerwardTimer;

        timerButton.onClick.AddListener(() => UnityAdsUtility.Instance.ShowVideoReward(showAdTimerCallbacks));
    }

    // Update is called once per frame
    void Update()
    {
        // 一定時間たったらリザルトへ遷移
        ring.fillAmount -= 1.0f / 60.0f;
        
        if (ring.fillAmount <= 0)
        {
            TimeInOut(false);
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
            TimeInOut(true);
        }
        else if (showResult == ShowResult.Failed)
        {
            // 広告読み込みエラー
            TimeInOut(false);
        }
        else if (showResult == ShowResult.Skipped)
        {
            // 広告をスキップした時
            TimeInOut(false);
        }
    }

    /// <summary>
    /// 時間をプラスするかしないか
    /// </summary>
    /// <param name="time_plus">true = プラス false = リザルトへ</param>
    private void TimeInOut(bool time_in) 
    {
        if (time_in)
        {
            time_manager_script.BonusTime(5f);

            gameObject.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene("new_Result", LoadSceneMode.Additive);

            gameObject.SetActive(false);
        }
    }
}
