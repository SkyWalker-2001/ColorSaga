using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Revive_Manager : MonoBehaviour
{
    public static Revive_Manager revive_Manager_Instance;

    [SerializeField] private CanvasGroup cGroup;
    [SerializeField] private GameObject revive_Screen;

    [SerializeField] private GameObject player_GO;

    [SerializeField] private AudioSource gamePlay_AS;

    private void Awake()
    {
        revive_Manager_Instance = this;

        StartCoroutine("WaitForLoad");
    }

    private IEnumerator WaitForLoad()
    {
        yield return new WaitForSeconds(.2f);
        RewardedAd_Controller.rewarded_AD_Instance.LoadRewardedAd();
    }

    public void Activate_Revive_Screen_Panel()
    {
        player_GO.SetActive(false);

        gamePlay_AS.Pause();
        cGroup.alpha = 1;
        revive_Screen.SetActive(true);

        Time.timeScale = 0;
    }

    public void Revive_Player()
    {
        player_GO.SetActive(true);

        gamePlay_AS.Play();
        cGroup.alpha = 0;
        revive_Screen.SetActive(false);

        Time.timeScale = 1;
    }

    // BUTTON MANAGER /////////////////// ..........................


    public void Watch_AD_Button()
    {
        RewardedAd_Controller.rewarded_AD_Instance.ShowRewardedAd();
    }


    public void Use100Coin_Button()
    {
        int coin_Prefab = PlayerPrefs.GetInt("CoinGamePlay",0);

        if (coin_Prefab >= 50)
        {
            Revive_Player();
        }

        PlayerPrefs.SetInt("CoinGamePlay",0);
    }


    public void EndScreen_Button()
    {
        SceneManager.LoadScene("EndScreen");
    }
}
