﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInteract player = other.GetComponent<PlayerInteract>();
        if (player != null)
        {
            Destroy(gameObject);
        }
    }
}
