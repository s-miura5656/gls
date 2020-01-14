using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Monetization;
using DG.Tweening;

public class CoinGet_Rewod : MonoBehaviour
{
    //リワードボタン
    [SerializeField]
    private Button coin_get_reword = null;
    //リワードのコールバックの設定
    private ShowAdCallbacks showAdRewardCallbacks = new ShowAdCallbacks();


    void Start()
    {
        // ShowAdCallbacksにコールバックを設定
        showAdRewardCallbacks.finishCallback += VideoRerwardResult;
        // リザルトボタンを押したらコールバックを呼び出す
        coin_get_reword.onClick.AddListener(() => UnityAdsUtility.Instance.ShowVideoReward(showAdRewardCallbacks));

    }

    void Update()
    {
        
    }

    private void VideoRerwardResult(ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            //　広告を最後まで視聴した時
            Variable_Manager.Instance.GetSetPossessionCoin += 2500;

        }
        else if (showResult == ShowResult.Failed)
        {
            // 広告読み込みエラー
        }
        else if (showResult == ShowResult.Skipped)
        {
            // 広告をスキップした時
        }
    }

    private void OnDestroy()
    {
        // ShowAdCallbacksにコールバックを解除
        showAdRewardCallbacks.finishCallback -= VideoRerwardResult;
    }
}
