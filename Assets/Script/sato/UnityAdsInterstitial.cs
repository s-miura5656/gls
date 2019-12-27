using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsInterstitial : MonoBehaviour, IUnityAdsListener
{
    private string placementId = string.Empty;

    public void InitializeVideoReward(string interstitialPlacementID)
    {
        placementId = interstitialPlacementID;
        Advertisement.AddListener(this);
    }

    public void LoadAd()
    {
        if (Advertisement.isInitialized == false)
        {
            Debug.Log("Unity Ads not initialized");
            return;
        }
        Advertisement.Load(placementId);
    }

    public bool IsReadyInterstitial()
    {
        return Advertisement.IsReady(placementId);
    }

    public void ShowAds(UnityEngine.Monetization.ShowAdCallbacks showAdCallbacks)
    {
        if (!IsReadyInterstitial()) return;

        UnityEngine.Monetization.ShowAdPlacementContent content =
            (UnityEngine.Monetization.ShowAdPlacementContent)UnityEngine.Monetization.Monetization.GetPlacementContent(placementId);

        content.Show(showAdCallbacks);
    }

    public void OnUnityAdsReady(string placementId)
    {
        //Debug.Log("Ad Ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log($"Ad Error ={message}");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Start!!!!");
    }

    public void OnUnityAdsDidFinish(string interstitialPlacementID, ShowResult showResult)
    {
        if (placementId != interstitialPlacementID) return;

        switch (showResult)
        {
            case ShowResult.Finished:
                Debug.Log("Ad Finished!");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad Skipped!");
                break;
            case ShowResult.Failed:
                Debug.Log("Ad Failed..");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(showResult), showResult, $"placementId:{placementId}");
        }
    }
}
