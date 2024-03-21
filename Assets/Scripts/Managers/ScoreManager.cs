using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager_Instance;

    [SerializeField] private TextMeshProUGUI score_Text;
    [SerializeField] private TextMeshProUGUI coin_Text;

    private int score;
    private int high_Score;
    private int coin;

    private void Awake()
    {
        scoreManager_Instance = this;
    }

    private void Start()
    {
        score = 0;
        coin = 0;

        score_Text.text = "0";

    }

    private void Update()
    {
        Score_Mechanics();

        Coin_Mechanics();
    }

    public void AddCoin(int coin_Amount)
    {
        coin += coin_Amount;
    }

    private void Coin_Mechanics()
    {
        coin_Text.text = "Coins: "+ coin.ToString();
    }

    private void Score_Mechanics()
    {
        score += 1;

        score_Text.text = $"{score}";
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name, score);
        int highScore = PlayerPrefs.GetInt("High_Score" + SceneManager.GetActiveScene().name, 0);

        if (score > highScore)
        {
            PlayerPrefs.SetInt("High_Score" + SceneManager.GetActiveScene().name, score);
        }

    }
}
