using Scripts.Enums;
using UnityEngine;

public class NPCScript : MonoBehaviour, IInteractible
{
    [SerializeField] private ObjectType _objectType;
    [SerializeField] private NPC _npctype;

    private MeetStage _meetStage;

    private void Awake()
    {
        SetStage(MeetStage.FirstMeet);
    }

    public ObjectType GetObjectType()
    {
        return _objectType;
    }

    public void Talk()
    {
        GameManager.Instance.StartDialog(_npctype,_meetStage);
    }

    private void SetStage(MeetStage stage)
    {
        switch (stage)
        {
            case MeetStage.FirstMeet:
                _meetStage = MeetStage.FirstMeet;
                break;
            case MeetStage.InProcess:
                _meetStage = MeetStage.InProcess;
                break;
            case MeetStage.Complete:
                _meetStage = MeetStage.Complete;
                break;
            case MeetStage.None:
                _meetStage = MeetStage.None;
                break;
        }
    }
}
