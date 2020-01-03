using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Monetization;

public class Timer_Extension : MonoBehaviour
{

    [SerializeField]
    private Button timerButton = null;
    private ShowAdCallbacks showAdTimerCallbacks = new ShowAdCallbacks();
    [SerializeField]
    private Image ring;
    [SerializeField]
    private Image move;
    private bool time_in = true;

    void Start()
    {


        showAdTimerCallbacks.finishCallback += VideoRerwardTimer;

        timerButton.onClick.AddListener(() => UnityAdsUtility.Instance.ShowVideoReward(showAdTimerCallbacks));

    }

    // Update is called once per frame
    void Update()
    {
        ring.fillAmount -= 1.0f / 60.0f;
        //ring.fillAmount -= 1.0f / 60.0f;

        if (ring.fillAmount <= 0)
        {

            if (time_in == true)
            {
                //SceneManager.LoadScene("new_Result", LoadSceneMode.Additive);
                Result_In();
                ring.gameObject.SetActive(false);
                timerButton.gameObject.SetActive(false);
                move.gameObject.SetActive(false);
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
            //　広告を最後まで視聴した時
            
            SceneManager.LoadScene("Result",LoadSceneMode.Additive);
        }
        else if (showResult == ShowResult.Failed)
        {
            // 広告読み込みエラー
            SceneManager.LoadScene("Result", LoadSceneMode.Additive);
        }
        else if (showResult == ShowResult.Skipped)
        {
            // 広告をスキップした時
            SceneManager.LoadScene("Result", LoadSceneMode.Additive);
        }
    }

    private void Result_In()
    {

        SceneManager.LoadScene("new_Result", LoadSceneMode.Additive);
        time_in = false;
       
    }
}
