using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 144;
        InvokeRepeating("IncreaseSpeed", 10, 1);
    }

    private void IncreaseSpeed()
    {
        Time.timeScale = 2f;
    }
}
