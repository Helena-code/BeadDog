using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControllerScr player = other.GetComponent<PlayerControllerScr>();
        if (player != null)
        {
            //Debug.Log("объект мысль");
            player.Mind();
            Destroy(gameObject);
        }
    }
}
