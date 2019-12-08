﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Monetization;

public class ResultBotton_Manger : MonoBehaviour
{
    [SerializeField]
    private Button rewardButton = null;
    [SerializeField]
    private Button interstitialButton = null;
    [SerializeField]
    private GameObject back;
    [SerializeField]
    private float push_scale = 2.0f;
    [SerializeField]
    private float push_animtime = 1.0f;
    [SerializeField]
    private float leave_animtime = 1.0f;
    [SerializeField]
    private float leave_scale = 1.0f;
    [SerializeField]
    private GameObject Advertisement_Bottoun;
    private bool botton_push = true;

    private ShowAdCallbacks showAdRewardCallbacks = new ShowAdCallbacks();
    private ShowAdCallbacks showAdInterstitialCallbacks = new ShowAdCallbacks();

    [SerializeField]
    private Coin_Manager script;

    void Start()
    {
        // ShowAdCallbacksにコールバックを設定
        showAdRewardCallbacks.finishCallback += VideoRerwardResult;
        showAdInterstitialCallbacks.finishCallback += InterstitialResult;

        rewardButton.onClick.AddListener(() => UnityAdsUtility.Instance.ShowVideoReward(showAdRewardCallbacks));
        interstitialButton.onClick.AddListener(() => ShowInterstitial());
    }

    private void OnDestroy()
    {
        // ShowAdCallbacksにコールバックを解除
        showAdRewardCallbacks.finishCallback -= VideoRerwardResult;
        showAdInterstitialCallbacks.finishCallback -= InterstitialResult;
    }

    private void ShowInterstitial()
    {
        if (UnityAdsUtility.Instance.IsReadyInterstitialVideo())
        {
            UnityAdsUtility.Instance.ShowInterstitialVideo(showAdInterstitialCallbacks);
        }
        else
        {
            GetPossessionCoin();
            UnityEngine.SceneManagement.SceneManager.LoadScene("Title_ 1");
        }
    }

    private void GetPossessionCoin()
    {
        if (script.after_score != 0)
        {
            Variable_Manager.Instance.GetSetPossessionCoin += (int)script.bonus_score;
        }
        else
        {
            //Variable_Manager.Instance.GetSetPossessionCoin += (int)script.bonus_score;
        }
    }

    private void VideoRerwardResult(ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            //　広告を最後まで視聴した時
            var coin_object = GameObject.Find("coin");
            var coin_script = coin_object.GetComponent<Coin_Manager>();

            Advertisement_Bottoun.SetActive(false);

            coin_script.Calculation_Manager();
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

    private void InterstitialResult(ShowResult showResult)
    {
        GetPossessionCoin();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title_ 1");
    }

    public void PushBotton()
    {
        //var recttransform_2 = back.GetComponent<RectTransform>();
        //recttransform_2.DOScale(
        //      push_scale,　　//終了時点のScale
        //  push_animtime 　　　　　　//時間
        //       ).SetEase(Ease.Linear);
    }

    public void LeaveBotton()
    {
        //var recttransform_2 = back.GetComponent<RectTransform>();
        //recttransform_2.DOScale(
        //     leave_scale,　　//終了時点のScale
        //leave_animtime  //時間
        //       ).SetEase(Ease.InCirc);
    }
}
