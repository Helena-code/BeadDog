using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public bool ThingCollected
    {
        get { return _thing.IsCollected; }
    }
    public bool IsComplete
    {
        set { _isComplete = value; }
    }

    [SerializeField] private int _number;
    [SerializeField] private QuestThing _thing;
    [SerializeField] private string _description;

    private bool _isComplete;

}
