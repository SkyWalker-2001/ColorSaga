using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenue_Manager : MonoBehaviour
{
    public void OnPressPlay()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
