using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyTurrent : Enemies
{
    [SerializeField] float projectileFireRate;
    public Transform playerTarget;
    public float distance;
    public float distanceApart = 5f;
    float timeSinceLastFire = 0;
    Rigidbody2D rb;
    bool facingRight = true;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();

        if (projectileFireRate <= 0)
        {
            projectileFireRate = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] curPlayingClips = anim.GetCurrentAnimatorClipInfo(0);
        
        distance = Vector3.Distance(playerTarget.transform.position, transform.position);

        if (playerTarget.transform.position.x < transform.position.x) 
        {
            sr.flipX = true;        
        }
        else
        {
            sr.flipX= false;
        }

        if (distance <= distanceApart)
        {
            if (curPlayingClips[0].clip.name != "Fire")
            {
                if (Time.time >= timeSinceLastFire + projectileFireRate)
                {
                    anim.SetTrigger("Fire");
                    timeSinceLastFire = Time.time;
                }
            }
        }

    }
}

