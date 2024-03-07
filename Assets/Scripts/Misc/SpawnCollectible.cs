using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectible : MonoBehaviour
{
    SpriteRenderer sr;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public GameObject PowerUpPrefab;
    public GameObject FoodPrefab;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    [SerializeField] GameObject[] itemsToSpawn;
    [SerializeField] int itemSpawnWeight = 1;


    // Start is called before the first frame update
    //void Start()
    //{
        //int randNum = Random.Range(0, itemsToSpawn.Length + itemSpawnWeight);

        //if (randNum > 2) return;

        //Instantiate(itemsToSpawn[randNum], transform.position, Quaternion.identity);
    //}
//}
public void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(PowerUpPrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(FoodPrefab, spawnPoint2.position, spawnPoint2.rotation);
    }
}
