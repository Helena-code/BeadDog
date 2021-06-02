using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerScr : MonoBehaviour
{
    public float speed = 3.0f;                          // скорость игрока
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
    float vertical;
    float horizontal;
    public Vector2 lookD
    {
        get { return lookDirection; }
    }
    Vector2 lookDirection = new Vector2(1, 0);          // направление взгляда
    Rigidbody2D rigidbody;
    Animator animator;
    Transform trPlayer;

    public GameObject bulletPrefab;                     // префаб снаряда
    public DialogScript dialogScript;
    public GameManager gameManager;
    public MindScript mindScript;
    public FixedJoystick fixedJoystick;
    public AudioSource audioSource;
    public AudioClip clip;

    void Awake()
    {

    }
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        gameManager = GetComponent<GameManager>();
        mindScript = GetComponent<MindScript>();
        dialogScript = GetComponent<DialogScript>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        trPlayer = GetComponent<Transform>();

        //dogMind = GetComponentInChildren<TextMeshProUGUI>();
        //dogMind = GameObject.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        //Debug.Log(dogMind);

        //GetComponentInChildren<Canvas>().enabled = false;
    }

    void Update()
    {
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        horizontal = Input.GetAxis("Horizontal");                             // считываю данные, передаваемые по горизонтали и вертикали  
        vertical = Input.GetAxis("Vertical");


#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        horizontal = fixedJoystick.Horizontal;
        vertical = fixedJoystick.Vertical;


#endif

        Vector2 move = new Vector2(horizontal, vertical);                     // создаю вектор, в который записываю данные о задаваемом положении игрока
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))  // сравнение х или y c 0 через эту функцию, потому что через == не точно
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
            Debug.Log(lookDirection);
        }
        animator.SetFloat("LookX", lookDirection.x);
        animator.SetFloat("LookY", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);                   // это не скорость игра, а параметр, который считывает было ли вообще какое-либо движение
        if (move.magnitude > 0.1)
        {
            //audioSource.PlayOneShot(clip);
        }

        trPlayer.Translate(move * speed * Time.deltaTime);

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
            RaycastHit2D hit1 = Physics2D.Raycast(rigidbody.position + Vector2.up * 0.5f, lookDirection, 3.0f, LayerMask.GetMask("NPC"));
            if (hit1.collider != null)
            {
                //Debug.Log("Луч запущен и поймал NPC");
                Dialog(hit1.collider.gameObject.GetComponent<NPCScript>().npcName);
            }
            RaycastHit2D hit2 = Physics2D.Raycast(rigidbody.position + Vector2.up * 0.2f, lookDirection, 3.0f, LayerMask.GetMask("Portal"));
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

    // МЕТОД ДИАЛОГА
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

    // МЕТОД ЗАПУСКА СНАРЯДА
    void Launch()
    {
        if (bulletNumber <= 0)
        {
            return;
        }
        GameObject bullet = Instantiate(bulletPrefab, rigidbody.position + Vector2.up, Quaternion.identity);       // создаю снаряд
        BulletShot bulletShot = bullet.GetComponent<BulletShot>();                                                 // получаю доступ к его скрипту
        bulletShot.Launch(lookDirection, 300);                                                                     // запускаю метод запуска 
        bulletNumber -= 1;
    }

    //МЕТОД ИЗМЕНЕНИЯ ЗДОРОВЬЯ
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

    //МЕТОД МЫСЛЕЙ ИГРОКА
    public void Mind()
    {
        mindScript.ShowMind();
    }
}
