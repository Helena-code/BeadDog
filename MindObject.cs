using UnityEngine;

public class MindObject : MonoBehaviour
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
