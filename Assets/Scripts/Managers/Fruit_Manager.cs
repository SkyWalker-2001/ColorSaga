using UnityEngine;

public class Fruit_Manager : MonoBehaviour
{
    public static Fruit_Manager fruit_Manager_Instance;

    [SerializeField] private int random_FruitCode; // 1 = Apple, 2 = Banana, 3 = BlueBErry 

    [SerializeField] private float FruitChangeTime;

    [SerializeField] private Sprite[] fruits_Images;

    [SerializeField] private SpriteRenderer fruit_SpriteRenderer;

    private void Awake()
    {
        fruit_Manager_Instance = this;
    }

    private void Start()
    {
        random_FruitCode = 1;

        InvokeRepeating("RandomCodeGenerator", FruitChangeTime, FruitChangeTime);
    }

    private void FixedUpdate()
    {
        fruit_SpriteRenderer.sprite = fruits_Images[random_FruitCode - 1];
    }

    private void RandomCodeGenerator()
    {
        random_FruitCode = Random.Range(1, 4);
    }

    public void CheckCorrectFruit(int Fruit_CodeNumber)
    {
        if (Fruit_CodeNumber == random_FruitCode)
        {
            Debug.Log("SAME number");

            ScoreManager.scoreManager_Instance.AddCoin(5);
        }

        else
        {
            Player.player_Instance.Die();
        }
    }
}
