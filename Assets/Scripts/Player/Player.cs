using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        
        if(collision.gameObject.GetComponent<Apple>() != null)
        {
            Fruit_Manager.fruit_Manager_Instance.CheckCorrectFruit(1);
        }

        else if(collision.gameObject.GetComponent<Banana>() != null)
        {
            Fruit_Manager.fruit_Manager_Instance.CheckCorrectFruit(2);
        }

        else if (collision.gameObject.GetComponent<BlueBerry>() != null)
        {
            Fruit_Manager.fruit_Manager_Instance.CheckCorrectFruit(3);
        }
    }
}
