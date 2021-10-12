using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Enums;

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
    public NPC QuestNPC
    {
        set { _questNpc = value; }
    }
    public string Description
    {
        set { _description = value; }
    }

    private int _number;               // зачем вообще номер у квеста? только на случай, если один персонаж даст 2 задания  
    private QuestThing _thing;         // вроде логика потерялась, просто буду делать комплит? и проверку у самой вещи что за тип
    private NPC _questNpc;
    private string _description;
    private bool _isComplete;

    private void Awake()
    {
        _isComplete = false;
    }
}
