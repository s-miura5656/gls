using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;

public class MonetizationBannerExample : MonoBehaviour
{
    public bool testMode;
    public string appleAppStoreGameId = "3356876";
    public string googlePlayStoreGameId = "3356877";
    public string placementId = "banner_test";
    public BannerPosition bannerPosition = BannerPosition.BOTTOM_CENTER;
    private string _gameId = "";

    private void Start()
    {
        InitUnityAds();
        ShowBanner();
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
        Advertisement.Banner.SetPosition(bannerPosition);
    }

    public void ShowBanner()
    {
        if (Advertisement.IsReady(placementId))
            Advertisement.Banner.Show(placementId);
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }
}