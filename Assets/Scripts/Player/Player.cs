using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Player_Controller controller;

    public static Player player_Instance;

    private void Awake()
    {
        player_Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        if (collision.gameObject.GetComponent<Apple>() != null)
        {
            Fruit_Manager.fruit_Manager_Instance.CheckCorrectFruit(1);
        }

        else if (collision.gameObject.GetComponent<Banana>() != null)
        {
            Fruit_Manager.fruit_Manager_Instance.CheckCorrectFruit(2);
        }

        else if (collision.gameObject.GetComponent<BlueBerry>() != null)
        {
            Fruit_Manager.fruit_Manager_Instance.CheckCorrectFruit(3);
        }
    }

    public void Die()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 0;

        ScoreManager.scoreManager_Instance.SaveScore();

        Panel_Manager.panel_Instance.Activate_Panel_Screen_Panel();
    }
}
