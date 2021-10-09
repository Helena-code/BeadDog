using UnityEngine;
using UnityEngine.UI;
using Scripts.Enums;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private PlayerMove _playerMove;
    private PlayerView _playerView;
    private Vector2 _lookDirection;

    public float healthPoint = 25f;                     // очки аптечки 

    public Text healthText;
    public Text blueBeadsText;
    public Text bulletText;
    public Text whiteBeadsText;
    public Text LockText;

    public string local = "red";

    float maxHealth = 100f;                             // максимальное количество здоровья
    float currentHealth;                                // текущее количество здоровья
    public int healthChestNumber;                            // количество аптечек
    public int bulletNumber;                                 // количество патронов
    public int whiteBeadsNumber;                             // количество белых бусин
    public int lockNumber;                                   // количество замочков

    bool firstMeet = true;                                   // первая встреча персонажа
    public int bunnyQuestState = 0;
    int frogQuestState = 0;
    int cockQuestState = 0;
    // стадии квеста других персонажей
    int currentState = 0;



    Rigidbody2D rigidbody;



    public GameObject bulletPrefab;                     // префаб снаряда
    public DialogScript dialogScript;

    public MindVisualiser mindScript;

    public AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        _playerView = GetComponent<PlayerView>();
        _playerMove = GetComponent<PlayerMove>();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

        mindScript = GetComponent<MindVisualiser>();
        dialogScript = GetComponent<DialogScript>();

        audioSource = GetComponent<AudioSource>();


        //dogMind = GetComponentInChildren<TextMeshProUGUI>();
        //dogMind = GameObject.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        //Debug.Log(dogMind);

        //GetComponentInChildren<Canvas>().enabled = false;
    }

    void Update()
    {


        // ПРЕДВАРИТЕЛЬНЫЙ UI
        healthText.text = "Health: " + currentHealth;
        blueBeadsText.text = "Blue beads: " + healthChestNumber;
        bulletText.text = "Bullet: " + bulletNumber;
        whiteBeadsText.text = "White beads: " + whiteBeadsNumber;
        LockText.text = "Lock: " + lockNumber;


        // НАЗНАЧЕНИЕ КНОПКИ СТРЕЛЯТЬ
        if (Input.GetKeyDown(KeyCode.E))
        {
            Launch();
        }

        // НАЗНАЧЕНИЕ КНОПКИ ЛЕЧЕНИЕ
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (healthChestNumber > 0)
            {
                ChangeHealth(healthPoint);
                healthChestNumber -= 1;
            }
        }
        // НАЗНАЧЕНИЕ КНОПКИ ПОГОВОРИТЬ / ДЕЙСТВИЕ
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit2D hit1 = Physics2D.Raycast(rigidbody.position + Vector2.up * 0.5f, _playerMove.LookDirection, 3.0f, 11);//LayerMask.GetMask("NPC")
            if (hit1.collider != null)
            {
                //Debug.Log("Луч запущен и поймал NPC");
                Dialog(hit1.collider.gameObject.GetComponent<NPCScript>().npcName);
            }
            RaycastHit2D hit2 = Physics2D.Raycast(rigidbody.position + Vector2.up * 0.2f, _playerMove.LookDirection, 3.0f, 12); //LayerMask.GetMask("Portal")
            if (hit2.collider != null)
            {
                hit2.collider.gameObject.GetComponent<PortalScr>().Door();
            }
        }


    }
    private void FixedUpdate()
    {
        //Vector2 position = rigidbody.position;                                // запомининаю текущую позицию объекта
        //position.x = position.x + horizontal * speed * Time.deltaTime;        // добавляю к ней считанные значения по горизонтали и вертикали    
        //position.y = position.y + vertical * speed * Time.deltaTime;
        //rigidbody.MovePosition(position);                                     // передаю данные в риджитбади

    }

    // МЕТОД ОТКРЫВАНИЯ ДВЕРИ
    void OpenDoor() // нужен ли вообще? посмотреть, когда будет интерфес управления
    {

    }

    void Dialog(string npc)
    {
        if (npc == "Bunny")
        {
            currentState = bunnyQuestState;
            if (bunnyQuestState == 0) bunnyQuestState = 1;
        }
        else if (npc == "Frog")
        {
            currentState = frogQuestState;
            if (frogQuestState == 0) frogQuestState = 1;
        }
        else if (npc == "Cock")
        {
            currentState = cockQuestState;
            if (cockQuestState == 0) cockQuestState = 1;
        }

        dialogScript.ShowDialogCanvas(npc, currentState);

    }

    public void Launch()
    {
        if (bulletNumber <= 0)
        {
            return;
        }
        GameObject bullet = Instantiate(bulletPrefab, rigidbody.position + Vector2.up, Quaternion.identity);       // TODO убрать instantiate
        BulletShot bulletShot = bullet.GetComponent<BulletShot>();                                                 
        bulletShot.Launch(_playerMove.LookDirection, 300);                                                                     
        bulletNumber -= 1;
    }

    public void ChangeHealth(float amount)
    {
        if (amount < 0)
        {
            // запуск анимации и звука дамага
        }
        if (amount > 0)
        {
            // запуск анимации и звука лечения
        }
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        // если значение текущего здоровья приблизилось к 0, то вызвать метод смерть
    }

    private void ShowMind()
    {
        mindScript.ShowMind();
    }

    public void EnterButton()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit2D hit1 = Physics2D.Raycast(rigidbody.position + Vector2.up * 0.5f, _playerMove.LookDirection, 3.0f, 11);
            if (hit1.collider != null)
            {
                //Debug.Log("Луч запущен и поймал NPC");
                Dialog(hit1.collider.gameObject.GetComponent<NPCScript>().npcName);
            }
            RaycastHit2D hit2 = Physics2D.Raycast(rigidbody.position + Vector2.up * 0.2f, _playerMove.LookDirection, 3.0f, 12);
            if (hit2.collider != null)
            {
                hit2.collider.gameObject.GetComponent<PortalScr>().Door();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        var temp = other.GetComponent<IInteractible>();
        if (temp != null)
        {
            ObjectType otherType = temp.GetObjectType();
            switch (otherType)            
            {
                case ObjectType.BulletPack:
                    break;
                case ObjectType.Door:
                    break;
                case ObjectType.HealthBag:
                    break;
                case ObjectType.Key:
                    break;
                case ObjectType.Mind:
                    ShowMind();
                    break;
                case ObjectType.NPC:
                    break;
                case ObjectType.QuestThing:
                    _gameManager.CheckCompleteQuest();
                    break;
                default:
                    break;
            }
        }
    }
}
