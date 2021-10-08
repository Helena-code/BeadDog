using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public sealed class QuestController : MonoBehaviour
{
    //private List<bool> _quests;
    //private Dictionary<int, bool> _quests;

    [SerializeField] List<Quest> _quests = new List<Quest>();

    public void CheckComplete()
    {
        foreach (var item in _quests)
       {
           if (item.ThingCollected)
            {
                item.IsComplete = true;
            }
        }
    }

    //public void CompleteQuest(int number)
    //{
    //    foreach (var item in _quests)
    //    {
    //        if (_quests.ContainsKey(number))
    //        {
    //            _quests[number] = true;
    //        }
    //    }
    //}
}

