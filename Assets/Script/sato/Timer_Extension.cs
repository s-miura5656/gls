using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Monetization;

public class Timer_Extension : MonoBehaviour
{
    //[SerializeField] private GameObject continue_button = null;
    // ボーナスボタン
    [SerializeField] private Button timerButton = null;
    // ボーナスボタンの表示時間に合わせて減っていくゲージ
    [SerializeField] private Image ring = null;
    // 時間を管理しているスクリプト   
    [SerializeField] private Time_Manager time_manager_script = null;
    // 破壊率を管理しているスクリプト
    [SerializeField] private Destruction_Rate_Manager destruction_rate_script = null;
    private ShowAdCallbacks showAdTimerCallbacks = new ShowAdCallbacks();

    // ボタンが出ている時間
    private float continue_time = 8f;
    // ボタン表示のカウントダウンのフラグ
    private bool count_flag = false;
    // リザルトへ遷移するまでの時間のカウント
    private float wait_result_count = 0f;
    // リザルトへ遷移する時間
    private float change_result_time = 3f;
    // 一回だけリザルトを読み込むフラグ
    private bool load_result = true;
    // タイムを延長した 
    private int on_time = 0;
    // タイムを延長しなかった 
    private int off_time = 0;
    // 破壊率100%
    private float dest_rate_max = 100f;

    // Noボタンを出す時間
    private float no_time = 8f;
    // Noボタンが出ている時間
    [SerializeField]
    private Button no_button = null;

    void Start()
    {
        no_button.gameObject.SetActive(false);

        showAdTimerCallbacks.finishCallback += VideoRerwardTimer;

        timerButton.onClick.AddListener(() => UnityAdsUtility.Instance.ShowVideoReward(showAdTimerCallbacks));
        //timerButton.onClick.AddListener(CountFlag);
        no_button.onClick.AddListener(No_Push);
    }

    // Update is called once per frame
    void Update()
    {
        if (!load_result)
                return;

        if (timerButton.transform.parent.gameObject.activeSelf && !time_manager_script.GetGamePlayState)
        {
            // 延長前の選択処理
            TimeOut();
        }
        else if(!timerButton.transform.parent.gameObject.activeSelf && time_manager_script.GetGameEndState && destruction_rate_script.GetDestRate < dest_rate_max)
        {
            wait_result_count += Time.deltaTime;

            // 延長後の終了処理
            if (wait_result_count >= change_result_time && load_result)
            {
                time_manager_script.ChangeResult();
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
            //ContinueInput(false);
            
            //load_result = false;
        }
        else if (showResult == ShowResult.Skipped)
        {
            // 広告をスキップした時
            //ContinueInput(false);

            //load_result = false;
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
            time_manager_script.BonusTime(10f);

            timerButton.transform.parent.gameObject.SetActive(false);
            on_time = 1;
            UnityAnaltics.Instance.Timer_on(on_time);
            on_time = 0;

            no_button.gameObject.SetActive(false);
        }
        else
        {
            time_manager_script.ChangeResult();
            destruction_rate_script.SetDestructionRate();
            timerButton.transform.parent.gameObject.SetActive(false);

            no_button.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 一定時間後にリザルトへ遷移
    /// </summary>
    private void TimeOut() 
    {
        if (count_flag) 
            return;

        ring.fillAmount -= Time.deltaTime / continue_time;

        if(ring.fillAmount <= 0.6)
        {
            no_button.gameObject.SetActive(true);
        }

        if (ring.fillAmount <= 0)
        {
            ContinueInput(false);
            load_result = false;
            off_time = 1;
            UnityAnaltics.Instance.Timer_off(off_time);
            off_time = 0;
        }
    }

    private void CountFlag() 
    {
        count_flag = true;
    }

    private void No_Push()
    {
        time_manager_script.ChangeResult();
        destruction_rate_script.SetDestructionRate();
        timerButton.transform.parent.gameObject.SetActive(false);

        no_button.gameObject.SetActive(false);
    }
}
