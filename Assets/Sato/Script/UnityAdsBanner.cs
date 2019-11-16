using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsBanner : MonoBehaviour
{
    private BannerLoadOptions loadOption = new BannerLoadOptions();
    private string placementId = string.Empty;

    public void InitializeBanner(string bannerPlacementId)
    {
        placementId = bannerPlacementId;
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);

        loadOption.loadCallback += BannerCallBackLoad;
        loadOption.errorCallback += BannerCallBackError;
        Advertisement.Banner.Load(placementId, loadOption);
    }

    private void OnDestroy()
    {
        loadOption.loadCallback -= BannerCallBackLoad;
        loadOption.errorCallback -= BannerCallBackError;
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
        Debug.Log($"error banner message = {message}");
        Advertisement.Banner.Load(placementId, loadOption);
    }

    private void BannerCallBackLoad()
    {
        ShowBanner();
    }
}
