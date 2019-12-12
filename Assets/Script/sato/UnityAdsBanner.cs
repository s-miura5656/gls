using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsBanner : MonoBehaviour
{
    // バナーロードのオプションを設定できるクラス
    private BannerLoadOptions loadOption = new BannerLoadOptions();
    private string placementId = string.Empty;

    public void InitializeBanner(string bannerPlacementId)
    {
        // 広告placementIdの設定
        placementId = bannerPlacementId;

        // バナーposition設定
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);

        // ロード完了時に呼ばれる関数の設定
        loadOption.loadCallback += BannerCallBackLoad;

        // ロードに失敗したときに呼ばれる関数の設定
        loadOption.errorCallback += BannerCallBackError;

        // バナーロード処理
        Advertisement.Banner.Load(placementId, loadOption);
    }

    private void OnDestroy()
    {
        // ロード完了時に呼ばれる関数の解除
        loadOption.loadCallback -= BannerCallBackLoad;

        // ロードに失敗したときに呼ばれる関数の設定
        loadOption.errorCallback -= BannerCallBackError;
    }

    private void ShowBanner()
    {
        // バナーの表示
        Advertisement.Banner.Show();
    }

    private void HideBanner()
    {
        // バナーの非表示
        Advertisement.Banner.Hide();
    }

    private void BannerCallBackError(string message)
    {
        // バナーエラー時のメッセージ表示
        Debug.Log($"error banner message = {message}");

        // バナー表示エラーだったらもう一度ロードする
        Advertisement.Banner.Load(placementId, loadOption);
    }

    private void BannerCallBackLoad()
    {
        // バナーのロードが完了したらバナーを表示する。
        ShowBanner();
    }
}
