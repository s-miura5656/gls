using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

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

    public void ShowAd()
    {
        if (!Advertisement.IsReady(placementId)) return;
        Advertisement.Show(placementId);
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ad Ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log($"Ad Error ={message}");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Start!!!!");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:

                Debug.Log("Ads Finished!");
                SceneManager.LoadScene("GameMain_1");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ads Skipped!");
                SceneManager.LoadScene("GameMain_1");
                break;
            case ShowResult.Failed:
                Debug.Log("Ads Failed..");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(showResult), showResult, $"placementId:{placementId}");
        }
    }
}
