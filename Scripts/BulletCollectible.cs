using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInteract player = other.GetComponent<PlayerInteract>();
        if (player!= null)
        {
            player.bulletNumber += 5;
            Destroy(gameObject);
        }
    }
}
