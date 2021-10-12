using System.Collections.Generic;
using UnityEngine;

public sealed class QuestController : MonoBehaviour
{
    [SerializeField] private QuestBundle _questBundle;

    private List<Quest> _quests;
    private List<QuestData> _questsData; 

    private void Awake()
    {
        InitQuests();
    }

    private void InitQuests()
    {
        _questsData = _questBundle.QuestsData;

        foreach (var item in _questsData)
        {
            Quest temp = new Quest();
            _quests.Add(temp);
            temp.QuestNPC = item.NPC;
            temp.Description = item.Description;
        }
    }

    public void CheckComplete()          // переписать метод, ничего не делает теперь
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

