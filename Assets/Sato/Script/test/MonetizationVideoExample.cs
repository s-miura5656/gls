using System;
using UnityEngine;
using UnityEngine.Monetization;

public class MonetizationVideoExample : MonoBehaviour
{
    public bool testMode;
    public string appleAppStoreGameId = "3356876";
    public string googlePlayStoreGameId = "3356877";
    public string placementId = "rewardedVideo";
    private string _gameId = "";
    private ShowAdCallbacks _showAdCallbacks;

    private void Start()
    {
        InitUnityAds();
    }

    private void InitUnityAds()
    {
        if (!Monetization.isSupported) return;
#if UNITY_IOS
        _gameId = appleAppStoreGameId;
#elif UNITY_ANDROID
        _gameId = googlePlayStoreGameId;
#endif
        Monetization.Initialize(_gameId, testMode);
        _showAdCallbacks = new ShowAdCallbacks { startCallback = AdStart, finishCallback = AdFinished };
    }

    public void ShowAd()
    {
        if (!Monetization.IsReady(placementId)) return;
        ShowAdPlacementContent pc =
            (ShowAdPlacementContent)Monetization.GetPlacementContent(placementId);
        pc.Show(_showAdCallbacks);
    }

    private static void AdStart()
    {
        Debug.Log("Ad Start!!!!");
    }

    private static void AdFinished(ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                Debug.Log("Ads Finished!");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ads Skipped!");
                break;
            case ShowResult.Failed:
                Debug.Log("Ads Failed..");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(showResult), showResult, null);
        }
    }
}