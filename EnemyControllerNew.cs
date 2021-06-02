using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerNew : MonoBehaviour
{
    public float speed = 2f;
    public int angrySpeed = 150;
    public int angrySpeed2 = 200;
    public int angrySpeed3 = 20;
    public float changeTime = 4f;                 // время до измнения направления врага

    // public Transform point;                       // точка возврата для врага
    public Transform[] points;                    // точки передвижения для врага
    [SerializeField]
    Transform currentPoint;
    Vector3 distance;

    public float pointDistance = 10f;            // максимальное расстояние до точки возврата
    public float freeDistance = 5f;            // максимальное расстояние до точки возврата
    public float stoppingDistance = 5f;                 // расстояние до игрока

    public Vector3 randomPoint;

    float timer;                                  // отсчет до измнения направления врага
    int direction = 1;                            // текущее направление врага
    public bool patrol;
    public bool angry;
    public bool goBack;

    Transform target;                             // цель для атаки - игрок
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeTime;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        // присвоить положение одной из точек, как текущее положение
        currentPoint = points[Random.Range(0, 3)];
        distance = currentPoint.position - rb.transform.position;
    }

    void Update()
    {
        // СМЕНА НАПРАВЛЕНИЯ ДВИЖЕНИЯ ВРАГА
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        if (Vector2.Distance(currentPoint.position, rb.transform.position) < 3)
        {
            currentPoint = points[Random.Range(0, 3)];
            distance = currentPoint.position - rb.transform.position;
        }
        rb.AddForce(angrySpeed * distance * Time.deltaTime);
    }
    void FixedUpdate()
    {

        
        
        //если расстояние до точки возрата больше 10, то вернуться к точке возрата
        // это чтобы враг не выходил с поляны
        // двигаться к текущему положению
        // если оно достигнуто, то выбрать рандомно другую точку и двигаться к ней
        // если игрок ближе , чем 5 выбрать его положение и следовать к нему
        // если игрок ближе, чем 3 - атаковать его быстрым прыжком
        // затем выбрать любую точку и идти  к ней
    }

}
