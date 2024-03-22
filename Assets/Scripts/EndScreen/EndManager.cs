using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class EndManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HighScore_Text;
    [SerializeField] private TextMeshProUGUI Score_Text;

    private void Start()
    {

        float highScore_Pref = PlayerPrefs.GetFloat("High_ScoreGamePlay", 0);
        float score_Pref = PlayerPrefs.GetFloat("ScoreGamePlay", 0);

        HighScore_Text.text = "HighSCore: " + highScore_Pref.ToString();
        Score_Text.text = "Score:" + score_Pref.ToString();
    }


    public void RetryButton()
    {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1;
    }

}
