using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControllerScr player = other.GetComponent<PlayerControllerScr>();
        if (player != null)
        {
            Destroy(gameObject);
        }
    }
}
