using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UnityAdsVideoReward : MonoBehaviour, IUnityAdsListener
{
   
    private GameObject coin_object;
    private Coin_Manager coin_script;

    private string placementId = string.Empty;

    public void InitializeVideoReward(string rewardVideoPplacementId)
    {
        placementId = rewardVideoPplacementId;
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
        Debug.Log("Ads Ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log($"Ads Error ={message}");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ads Start!!!!");
    }

    public void OnUnityAdsDidFinish(string rewardVideoPplacementId, ShowResult showResult)
    {
        if (placementId != rewardVideoPplacementId) return;

        switch (showResult)
        {
            case ShowResult.Finished:
                coin_object = GameObject.Find("coin");
                coin_script = coin_object.GetComponent<Coin_Manager>();
                coin_script.Calculation_Manager();
                
               
                Debug.Log("Ads Finished!");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ads Skipped!");
                break;
            case ShowResult.Failed:
                Debug.Log("Ads Failed..");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(showResult), showResult, $"placementId:{placementId}");
        }
    }

 

   
}
