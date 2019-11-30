using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Monetization;
using UnityEngine.UI;

public class UnityAdsUtility : SingletonMonoBehaviour<UnityAdsUtility>
{
    private static string appleAppStoreGameId = "3356876";
    private static string googlePlayStoreGameId = "3356877";
    private static string bannerPplacementId = "banner_test";
    private static string rewardVideoPplacementId = "rewardedVideo";
    private static string interstitialPplacementId = "InterstitialVideo";

    [SerializeField] private bool testMode = true;
    private string _gameId = "";
    private UnityAdsBanner unityAdsBanner = null;
    private UnityAdsVideoReward unityAdsVideoReward = null;
    private UnityAdsInterstitial unityAdsInterstitial = null;
    
    protected override void Awake()
    {
        //singletonクラスのAwakeを呼び出す。
        base.Awake();

        // バナーとリワードのクラスを取得
        unityAdsBanner = GetComponent<UnityAdsBanner>();
        unityAdsVideoReward = GetComponent<UnityAdsVideoReward>();
        unityAdsInterstitial = GetComponent<UnityAdsInterstitial>();

        // 初期化処理
        InitializeAds();
    }

    private void InitializeAds()
    {
        // IOSとAndroid毎にゲームIDを指定する。
#if UNITY_IOS
        _gameId = appleAppStoreGameId;
#elif UNITY_ANDROID
        _gameId = googlePlayStoreGameId;
#endif

        // UnityAdsが対応していない場合は実行しない
        if (!Advertisement.isSupported) return;

        // UnityAdsの初期化（ゲーム起動中に一度だけ実行します）
        Monetization.Initialize(_gameId, testMode);

        // バナーの初期化処理
        unityAdsBanner.InitializeBanner(bannerPplacementId);

        // 動画リワードの初期化処理
        unityAdsVideoReward.InitializeVideoReward(rewardVideoPplacementId);

        // インタースティシャルの初期化
        unityAdsInterstitial.InitializeVideoReward(interstitialPplacementId);
    }

    public void ShowVideoReward(ShowAdCallbacks showAdCallbacks)
    {
        // 動画リワードの再生
        unityAdsVideoReward.ShowAd(showAdCallbacks);
    }

    public void ShowInterstitialVideo(ShowAdCallbacks showAdCallbacks)
    {
        // インタースティシャル広告再生
        unityAdsInterstitial.ShowAds(showAdCallbacks);
    }

    public bool IsReadyInterstitialVideo()
    {
        return unityAdsInterstitial.IsReadyInterstitial();
    }
}
