using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine;

public class Ad_Initialize : MonoBehaviour
{
    public void Awake()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>{ });
    }
}