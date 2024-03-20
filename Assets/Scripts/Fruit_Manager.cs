using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit_Manager : MonoBehaviour
{
    public static Fruit_Manager fruit_Manager_Instance;

    [SerializeField] private int random_FruitCode; // 1 = Apple, 2 = Banana, 3 = BlueBErry 

    [SerializeField] private float FruitChangeTime;

    private void Awake()
    {
        fruit_Manager_Instance = this;
    }

    private void Start()
    {
        random_FruitCode = 1;

        InvokeRepeating("RandomCodeGenerator", FruitChangeTime, FruitChangeTime);
    }

    private void RandomCodeGenerator()
    {
        random_FruitCode = Random.Range(1,4);
    }

    public void CheckCorrectFruit(int Fruit_CodeNumber)
    {
        if(Fruit_CodeNumber == 1)
        {
            Debug.Log("Apple IS HITTED");        
        }

        else if(Fruit_CodeNumber == 2)
        {
            Debug.Log("Banana IS HITTED");
        }

        else if(Fruit_CodeNumber == 3)
        {
            Debug.Log("BlueBerry IS HITTED");
        }

        else
        {
            Debug.Log("NO CODE PASS // Error in Fruit Manager CheckCorrectFruit FN");
        }
    }
}
