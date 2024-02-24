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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(PowerUpPrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(FoodPrefab, spawnPoint2.position, spawnPoint2.rotation);
    }
}
