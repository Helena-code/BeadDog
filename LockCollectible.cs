using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControllerScr player = other.GetComponent<PlayerControllerScr>();
        if (player != null)
        {
            player.lockNumber++;
            Destroy(gameObject);
        }
    }
}
