using GoogleMobileAds.Api;
using System;
using UnityEngine;


public class RewardedAdController : MonoBehaviour
{
    public static RewardedAdController rewardedAdController;

    /// <summary>
    /// UI element activated when an ad is ready to show.
    /// </summary>
    public GameObject AdLoadedStatus;
    public GameObject Resume_Button;
    public GameObject noConnection_Text;

    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID

    // real id
    //private const string _adUnitId = "ca-app-pub-6968725056779468/3326292834";

    // test id
    private string _adUnitId = "ca-app-pub-3940256099942544/5224354917";

#elif UNITY_IPHONE
        private const string _adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
        private const string _adUnitId = "unused";
#endif

    private RewardedAd _rewardedAd;

    private void Awake()
    {
        rewardedAdController = this;
        noConnection_Text.SetActive(false);
        LoadAd();
    }

    public void LoadAd()
    {
        Debug.Log("Loades the ad");

        // Clean up the old ad before loading a new one.
        if (_rewardedAd != null)
        {
            DestroyAd();
        }

        Debug.Log("Loading rewarded ad.");

        // Create our request used to load the ad.
        var adRequest = new AdRequest();

        // Send the request to load the ad.
        RewardedAd.Load(_adUnitId, adRequest, (RewardedAd ad, LoadAdError error) =>
        {
            // If the operation failed with a reason.
            if (error != null)
            {
                Debug.LogError("Rewarded ad failed to load an ad with error : " + error);
                return;
            }
            // If the operation failed for unknown reasons.
            // This is an unexpected error, please report this bug if it happens.
            if (ad == null)
            {
                Debug.LogError("Unexpected error: Rewarded load event fired with null ad and null error.");
                return;
            }

            // The operation completed successfully.
            Debug.Log("Rewarded ad loaded with response : " + ad.GetResponseInfo());
            _rewardedAd = ad;

            // Register to ad events to extend functionality.
            RegisterEventHandlers(ad);

            // Inform the UI that the ad is ready.
            AdLoadedStatus?.SetActive(true);
            Resume_Button.SetActive(false);
        });
    }

    public void ShowAd()
    {
        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            Debug.Log("Showing rewarded ad.");
            _rewardedAd.Show((Reward reward) =>
            {
                Debug.Log(String.Format("Rewarded ad granted a reward: {0} {1}",
                                        reward.Amount,
                                        reward.Type));
            });

            Resume_Button.SetActive(true);

        }
        else
        {
            Debug.LogError("Rewarded ad is not ready yet.");
            noConnection_Text.SetActive(true);
        }


        // Inform the UI that the ad is not ready.
        AdLoadedStatus?.SetActive(false);


    }



    public void DestroyAd()
    {
        if (_rewardedAd != null)
        {
            Debug.Log("Destroying rewarded ad.");
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }

        // Inform the UI that the ad is not ready.
        AdLoadedStatus?.SetActive(false);
        //Resume_Button.SetActive(true);

    }

    public void LogResponseInfo()
    {
        if (_rewardedAd != null)
        {
            var responseInfo = _rewardedAd.GetResponseInfo();
            UnityEngine.Debug.Log(responseInfo);
        }
    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Rewarded ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when the ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content with error : "
                + error);
        };
    }
}
