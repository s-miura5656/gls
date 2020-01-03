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

    void Start()
    {


        showAdTimerCallbacks.finishCallback += VideoRerwardTimer;

        timerButton.onClick.AddListener(() => UnityAdsUtility.Instance.ShowVideoReward(showAdTimerCallbacks));

    }

    // Update is called once per frame
    void Update()
    {
        
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
            
            SceneManager.LoadScene("Result");
        }
        else if (showResult == ShowResult.Failed)
        {
            // 広告読み込みエラー
          //  SceneManager.LoadScene("Result");
        }
        else if (showResult == ShowResult.Skipped)
        {
            // 広告をスキップした時
            //SceneManager.LoadScene("Result");
        }
    }
}
