using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    SpriteRenderer sr;


    public Vector2 initialVelocity;
    public Transform spawnPointA;
    public Transform spawnPointB;
    public Projectile projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Fire()
    {
        if (!sr.flipX)
        {
            Projectile currentProjectile = Instantiate(projectilePrefab, spawnPointB.position, spawnPointB.rotation);
            currentProjectile.initialVelocity = initialVelocity;
        }
        else
        {
            Projectile currentProjectile = Instantiate(projectilePrefab, spawnPointA.position, spawnPointA.rotation);
            currentProjectile.initialVelocity = new Vector2(-initialVelocity.x, initialVelocity.y);
            sr.flipX = true;
        }
    }
}