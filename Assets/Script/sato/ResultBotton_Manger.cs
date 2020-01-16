using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Monetization;


public class ResultBotton_Manger : MonoBehaviour
{
    [SerializeField]
    private Text next_game;


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

    private int button_time = 0;

    [SerializeField]
    private GameObject Loading;

    private int time_count = 0;


    [SerializeField]
    private Text coin_text;

    void Start()
    {
        interstitialButton.gameObject.SetActive(false);


        // ShowAdCallbacksにコールバックを設定
        showAdRewardCallbacks.finishCallback += VideoRerwardResult;
        showAdInterstitialCallbacks.finishCallback += InterstitialResult;


        rewardButton.onClick.AddListener(() => UnityAdsUtility.Instance.ShowVideoReward(showAdRewardCallbacks));
        interstitialButton.onClick.AddListener(() => ShowInterstitial());

        interstitialButton.gameObject.SetActive(false);

        Loading.SetActive(false);
    }

    private void Update()
    {
        button_time++;
        if(button_time >= 120)
        {
            interstitialButton.gameObject.SetActive(true);

        }
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
            UnityEngine.SceneManagement.SceneManager.LoadScene("Title_1");
            
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
            
        }
    }

    private void VideoRerwardResult(ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            //　広告を最後まで視聴した時
            var coin_object = GameObject.Find("coin");
            var coin_script = coin_object.GetComponent<Coin_Manager>();
            coin_text.gameObject.SetActive(false);
            Advertisement_Bottoun.SetActive(false);
            next_game.text = "NEXT";

            coin_script.Calculation_Manager();
            int push_rate = 0;
            push_rate = 1;
            UnityAnaltics.Instance.reword(push_rate);
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title_1");
        Loading.SetActive(true);
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
