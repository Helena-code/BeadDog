using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControllerScr player = other.GetComponent<PlayerControllerScr>();
        if (player != null)
        {
            if (gameObject.name.Equals("BlueBead"))
            {
                player.healthChestNumber++;
                Destroy(gameObject);
            }
            if (gameObject.name.Equals("WhiteBead"))
            {
                player.whiteBeadsNumber++;
                Destroy(gameObject);
            }
            if (gameObject.name.Equals("Lock"))
            {
                player.lockNumber++;
                Destroy(gameObject);
            }
            if (gameObject.name.Equals("Bullet"))
            {
                player.bulletNumber += 5;
                Destroy(gameObject);
            }
        }
    }
}
