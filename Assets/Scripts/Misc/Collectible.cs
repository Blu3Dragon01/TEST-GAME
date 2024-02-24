using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum PickupType
    {
        PowerUp = 5,
        Score = 2,
        Life,
    }

    [SerializeField] PickupType currentCollectible;
    [SerializeField] float timeToDestroy = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            PlayerController pc = collision.GetComponent<PlayerController>();

            switch (currentCollectible)
            {
                case PickupType.PowerUp:
                    pc.StartJumpForceChange();
                    break;
                case PickupType.Score:
                    pc.score++;
                    break;
                case PickupType.Life:
                    pc.Lives++;
                    break;
            }
            Destroy(gameObject, timeToDestroy);
        }
    }
}
