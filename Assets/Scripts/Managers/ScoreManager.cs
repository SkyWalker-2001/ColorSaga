using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager_Instance;

    [SerializeField] private TextMeshProUGUI score_Text;
    [SerializeField] private TextMeshProUGUI coin_Text;

    private float score;
    public int coin;

    private void Awake()
    {
        scoreManager_Instance = this;
    }

    private void Start()
    {
        score = 0;
        coin = 0;
    }

    private void Update()
    {
        Coin_Mechanics();
    }

    private void FixedUpdate()
    {
        Score_Mechanics();
    }

    public void AddCoin(int coin_Amount)
    {
        coin += coin_Amount;
    }

    private void Coin_Mechanics()
    {
        coin_Text.text = "Coins: " + coin.ToString();
    }

    private void Score_Mechanics()
    {
        score = score + 1 * Time.fixedDeltaTime;

        score_Text.text = "Score: " + $"{score:0}";
    }

    public void SaveScore()
    {
        PlayerPrefs.SetFloat("Score" + SceneManager.GetActiveScene().name, score);
        float highScore = PlayerPrefs.GetFloat("High_Score" + SceneManager.GetActiveScene().name, 0);

        if (score > highScore)
        {
            PlayerPrefs.SetFloat("High_Score" + SceneManager.GetActiveScene().name, score);
        }

        PlayerPrefs.SetInt("Coin" + SceneManager.GetActiveScene().name, coin);
    }
}
