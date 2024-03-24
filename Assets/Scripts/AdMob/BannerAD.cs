using GoogleMobileAds.Api;
using UnityEngine;

public class BannerAd : MonoBehaviour
{

    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
  private string _adUnitId = "unused";
#endif

    BannerView _bannerView;

    private void Start()
    {
        CreateBannerView();
        LoadAd();
    }


    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Top);
    }

    public void LoadAd()
    {
        if (_bannerView == null)
        {
            CreateBannerView();
        }

        var adRequest = new AdRequest();

        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }
}