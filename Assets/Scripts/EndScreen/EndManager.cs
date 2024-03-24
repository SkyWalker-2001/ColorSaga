using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HighScore_Text;
    [SerializeField] private TextMeshProUGUI Score_Text;

    private void Start()
    {

        float highScore_Pref = PlayerPrefs.GetFloat("High_ScoreGamePlay", 0);
        float score_Pref = PlayerPrefs.GetFloat("ScoreGamePlay", 0);

        HighScore_Text.text = "HighScore: " + $"{highScore_Pref:0}";
        Score_Text.text = "Score: " + $"{score_Pref:0}";
    }


    public void RetryButton()
    {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1;
    }

}
