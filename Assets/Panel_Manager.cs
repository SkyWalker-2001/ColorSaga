using GoogleMobileAds.Api;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Panel_Manager : MonoBehaviour
{
    public static Panel_Manager panel_Instance;

    [SerializeField] private CanvasGroup cGroup;
    [SerializeField] private GameObject panel_Screen;
    [SerializeField] private GameObject Player;
    [SerializeField] private AudioSource BG_Sound;

    [Header("Buttons")]
    [SerializeField] private Button resume_Button;
    [SerializeField] private Button ad_Button;

    [Header("CoinTextHandler")]
    [SerializeField] private TextMeshProUGUI coin_TMP;


    private void Awake()
    {
        panel_Instance = this;
    }
    public void Activate_Panel_Screen_Panel()
    {
        cGroup.alpha = 1;
        panel_Screen.SetActive(true);
        Player.SetActive(false);

        BG_Sound.Stop();

        coin_TMP.text = ScoreManager.scoreManager_Instance.coin.ToString();

        ad_Button.gameObject.SetActive(true);
        resume_Button.gameObject.SetActive(false);

        Time.timeScale = 0;
    }

    public void Deactivate_Panel_Screen_Panel()
    {
        cGroup.alpha = 0;
        panel_Screen.SetActive(false);
        Player.SetActive(true);

        BG_Sound.Play();

        resume_Button.gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    // Button Manager

    public void Resume_Button()
    {
        Deactivate_Panel_Screen_Panel();
        RewardedAdController.rewardedAdController.LoadAd();
    }

    public void AD_Button()
    {
        // Ad Internet Handler

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No Internert Connected");
        }
        else
        {
            Debug.Log("Internet is Connected");
            MobileAds.Initialize((InitializationStatus initStatus) =>
            {
                RewardedAdController.rewardedAdController.ShowAd();

            });

        }

    }

    public void UseCoin_Button()
    {
        int coin_Pref = PlayerPrefs.GetInt("CoinGamePlay", 0);
        
        if(coin_Pref >= 50)
            Deactivate_Panel_Screen_Panel();
    }

    public void EndScreen_Button()
    {
        SceneManager.LoadScene("EndScreen");
    }
}
