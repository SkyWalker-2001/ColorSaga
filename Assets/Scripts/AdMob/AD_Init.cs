using GoogleMobileAds.Api;
using UnityEngine;

public class AD_Init : MonoBehaviour
{
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
        }

        else
        {
            MobileAds.Initialize((InitializationStatus initStatus) =>
            {
                Debug.Log("Done init");
            });
        }
    }

    private void Update()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Chalgya");
        }

        else
        {
            Debug.Log("AAGIA");
        }
    }
}
