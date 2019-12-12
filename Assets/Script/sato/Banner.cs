using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;

public class Banner : MonoBehaviour
{
    public bool testMode;
    public string appleAppStoreGameId = "3356876";
    public string googlePlayStoreGameId = "3356877";
    public string placementId = "banner_test";
    public BannerPosition bannerPosition = BannerPosition.BOTTOM_CENTER;
    private string _gameId = "";
    private BannerLoadOptions loadOption = new BannerLoadOptions();

    private void Awake()
    {
        InitUnityAds();
    }

    private void OnDestroy()
    {
        loadOption.loadCallback -= BannerCallBackLoad;
        loadOption.errorCallback -= BannerCallBackError;
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

        loadOption.loadCallback += BannerCallBackLoad;
        loadOption.errorCallback += BannerCallBackError;
        Advertisement.Banner.Load(placementId, loadOption);
    }

    private void ShowBanner()
    {
        Advertisement.Banner.Show();
    }

    private void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    private void BannerCallBackError(string message)
    {
        Debug.Log($"error message = {message}");
        Advertisement.Banner.Load(placementId, loadOption);
    }

    private void BannerCallBackLoad()
    {
        ShowBanner();
    }
}