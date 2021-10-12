using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New QuestBundle", menuName = "ScriptableObjects/Menu Quest Bundle Data")]
public class QuestBundle : ScriptableObject
{
    public List<QuestData> QuestsData
    {
        get { return _questData; }
    }

    [SerializeField]
    private List<QuestData> _questData;
}
