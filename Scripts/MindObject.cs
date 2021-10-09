using UnityEngine;
using Scripts.Enums;

public class MindObject : MonoBehaviour, IInteractible
{
    public ObjectType Type
    {
        get { return _type; }
    }

    [SerializeField] private ObjectType _type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInteract player = other.GetComponent<PlayerInteract>();
        if (player != null)
        {
            Destroy(gameObject);
        }
    }

    public ObjectType GetObjectType()
    {
        return _type;
    }
}
