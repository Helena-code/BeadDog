using UnityEngine;
using Scripts.Enums;

public class GameManager : MonoBehaviour
{
    public bool quest1;// рефакторинг

    public GameObject npc1;
    public static GameManager Instance
    {
        get; private set;
    }

    [SerializeField] private DoorsController _doorsController;
    [SerializeField] private PlayerInteract _playerController;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private QuestController _questController;
    [SerializeField] private DialogController _dialogController;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Another instance of GameController already exists!");
        }
        Instance = this;
    }

    void Update()
    {
        if (quest1 == true)
        {
            ChangePerson(1);
            ChangeLocation();
        }
    }
    void ChangePerson(int person)
    {
        if (person == 1)
        {
            // сменить анимацию и диалоги персонажам 1 локации
            // был тест анимации когда-то, убрать 
            npc1.GetComponent<Animator>().SetTrigger("BunnyQuest");
        }
        if (person == 2)
        {
            // сменить анимацию и диалоги персонажам 2 локации
        }
        if (person == 3)
        {
            // сменить анимацию и диалоги персонажам 3 локации
            // или записать данные и персонажи их считают
        }
    }
    void ChangeLocation()
    {
        // dop.SetActive(true);    // непонятно что это и зачем
    }

    public void ChangeCamera(int location)  // рефакторинг
    {
    }

    public void CompleteQuest(int number)
    {
        
    }

    public void CheckCompleteQuest()
    {
        _questController.CheckComplete();
    }

    public void StartDialog(NPC npc,MeetStage stage)
    {
        _dialogController.StartDialog(npc, stage);
    }
}
