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

    [SerializeField] private bool testMode = true;
    private string _gameId = "";
    private UnityAdsBanner unityAdsBanner = null;
    private UnityAdsVideoReward unityAdsVideoReward = null;
    
    protected override void Awake()
    {
        base.Awake();

        unityAdsBanner = GetComponent<UnityAdsBanner>();
        unityAdsVideoReward = GetComponent<UnityAdsVideoReward>();

        InitializeAds();
    }

    private void InitializeAds()
    {
#if UNITY_IOS
        _gameId = appleAppStoreGameId;
#elif UNITY_ANDROID
        _gameId = googlePlayStoreGameId;
#endif
        if (!Advertisement.isSupported) return;

        Monetization.Initialize(_gameId, testMode);

        unityAdsBanner.InitializeBanner(bannerPplacementId);
        unityAdsVideoReward.InitializeVideoReward(rewardVideoPplacementId);
    }

    public void ShowVideoReward()
    {
        unityAdsVideoReward.ShowAd();
    }
}
