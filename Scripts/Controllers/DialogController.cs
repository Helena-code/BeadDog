using Scripts.Enums;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    [SerializeField] private DialogsData _dialogData;           // переделать, оставлено для проверки

    private string[] _currentDialog;

    public void StartDialog(NPC npc, MeetStage stage)
    {
        SelectDialog(npc, stage);
        HUDController.Instance.ShowDialog(_currentDialog);
    }

    private void SelectDialog(NPC npc, MeetStage stage)
    {
        _currentDialog = _dialogData.GetDialog(npc, stage);
    }
}
