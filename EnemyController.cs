using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public int  angrySpeed = 150;
    public int angrySpeed2 = 200;
    public int angrySpeed3 = 50;
    public float changeTime = 3f;                 // время до измнения направления врага
    public Transform point;                       // точка возврата для врага
    public float pointDistance = 10f;            // максимальное расстояние до точки возврата
    public float stoppingDistance = 5f;                 // расстояние до игрока

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

    }
    void FixedUpdate()
    {

        if (Vector2.Distance(rb.position, point.position) < pointDistance && angry == false)
        {
            patrol = true;
            goBack = false;
        }

        if (Vector2.Distance(rb.position, target.position) < stoppingDistance)
        {
            angry = true;
            patrol = false;
            goBack = false;
        }
        if (Vector2.Distance(rb.position, target.position) > stoppingDistance && patrol == false)
        {
            goBack = true;
            angry = false;
        }
        if (patrol)
        {
            Patrol();
        }
        if (angry)
        {
            Angry();
        }
        if (goBack)
        {
            GoBack();
        }
    }
    void Patrol()
    {
        Debug.Log("вызывается Patrol");
        rb.velocity = Vector2.zero;
        Vector2 position = rb.position;
        position.x = position.x + speed * Time.deltaTime * direction;
        rb.MovePosition(position);
    }
    void Angry()
    {
        Debug.Log("вызывается Angry");
        //Vector2 pos = rb.position;
        //rb.position = Vector2.MoveTowards(pos, target.position, angrySpeed * Time.deltaTime);
        var distance = target.transform.position - rb.transform.position;
        rb.AddForce(angrySpeed * distance * Time.deltaTime);

        //Vector3 per = (target.position - rigidbody.transform.position).normalized;
        //rigidbody.MovePosition(rigidbody.transform.position + per * speed * Time.deltaTime);

        Vector3 pos = rb.transform.position;

        // АТАКА
        if (Vector2.Distance(rb.position, target.position) < 3f)
        {
            
            rb.AddForce(angrySpeed2 * distance * Time.deltaTime);
            Debug.Log("нападение");
            //rb.velocity = Vector2.zero;
            //rb.AddForce(angrySpeed3 * (pos - rb.transform.position) * Time.deltaTime);
            Debug.Log("отход");
            angry = false;
            goBack = true;
            //rb.velocity = Vector2.zero;
            return;
        }
        return;

        //if (Vector2.Distance(rigidbody.position, target.position) < 2)
        //{
        //    Vector2 pos = rigidbody.transform.position;
        //    rigidbody.transform.position = target.transform.position;
        //    rigidbody.transform.position = pos;
        //    //rigidbody.MovePosition(target.position);
        //    //return;
        //}
    }
    void GoBack()
    {
        Debug.Log("вызывается GoBack");
        var distance = point.transform.position - rb.transform.position;
        rb.AddForce((angrySpeed3) * distance * Time.deltaTime);

        //rb.position = Vector2.MoveTowards(rb.position, point.position, speed * Time.deltaTime);

        //rigidbody.transform.position = Vector2.MoveTowards(rigidbody.transform.position, point.transform.position, speed * Time.deltaTime);
        //Vector3 per2 = (point.position - rigidbody.transform.position).normalized;
        //rigidbody.MovePosition(rigidbody.transform.position + per2 * speed * Time.deltaTime);
    }
}
