using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] Fruits_Prefabs;

    public float respawnTime;

    private Collider2D _box_Collider;


    private void Start()
    {
       _box_Collider = GetComponent<Collider2D>();

        StartCoroutine(asteroidWave());
    }

    private void SpawnEnemy()
    {
        GameObject Fruits = Instantiate(Fruits_Prefabs[Random.Range(0, Fruits_Prefabs.Length)]) as GameObject;

        Fruits.transform.position = new Vector2(Random.Range(_box_Collider.bounds.min.x, _box_Collider.bounds.max.x),transform.position.y);

    }

    private IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }
}
