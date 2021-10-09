using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    Rigidbody2D rb;
    Transform tr;
    bool startShoot;
    Vector3 dir;
    float speed = 5f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        startShoot = false;
        dir = new Vector3();
    }

    void Update()
    {
        Destroy(gameObject, 5.0f);
        if (startShoot)
        {
            tr.Translate(dir* speed*Time.deltaTime);
        }
    }
    public void Launch (Vector2 direction, float force)
    {
        //rb.AddForce(direction * force);
        float coef = 0f;
        if (Mathf.Abs (direction.x) > Mathf.Abs(direction.y))    // эту проверку возможно стоит вынести в player contl
        {                                                        // если он не будет стерелять вверх и вниз, а префаб инстаншиейтит собака
            if (direction.x < 0)
            {
                coef = -1f;
            }
            else coef = 1f;
           // Debug.Log("coef " + coef);
        }
        dir = Vector3.right * coef;
        //tr.Translate(dir);
        startShoot = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //EnemyController e = other.collider.GetComponent<EnemyController>();
        PinHit e = other.collider.GetComponent<PinHit>();
        if(e!= null)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
