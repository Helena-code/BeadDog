using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPinContrl : MonoBehaviour
{
    Transform trPin;
    public Transform trPlayer;
    PlayerMove playerScript;
    bool goToPlayer;
    public float speed;
    float dirLeftRight;
    bool goLeft;
    bool goRight;

    private void Start()
    {
        trPin = GetComponent<Transform>();
        playerScript = trPlayer.gameObject.GetComponent<PlayerMove>();
        goToPlayer = false;
    }


    private void Update()
    {
        //if (Vector2.Distance(trPin.position, trPlayer.position) < 2f)
        //{
        //    // если не атака
        //    CheckingPlayer();

        //}
        if (goToPlayer)
        {
            GoToPlayer();
        }
        //Vector3 move = trPlayer.position.normalized;
        //trPin.Translate(move * speed * Time.deltaTime);
        // trPin.Translate(trPlayer.position.normalized * speed * Time.deltaTime);
    }

    void CheckingPosPlayer()
    {

        if (Mathf.Abs(playerScript.LookDirection.x) > Mathf.Abs(playerScript.LookDirection.y))    // т.е. собака смотрит вправо или влево

        {
            // определить булеву переменную куда смотрит лево или право
            // пустить луч влево
            // если есть собака и она смотрит влево - атаковать
            // пустить луч вправо 
            // тоже самое только право
            // обнулить булевы переменные
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.GetComponent<PlayerController>() != null)
    //    {

    //        //Debug.Log("<PlayerController>() != null");
    //        //Debug.Log("playerScript.lookD.x = " + playerScript.lookD.x);
    //        //Debug.Log("playerScript.lookD.y = " + playerScript.lookD.y);

    //        if (Mathf.Abs(playerScript.lookD.x) > Mathf.Abs(playerScript.lookD.y))
    //        // if (Mathf.Abs(collision.gameObject.GetComponent<PlayerController>().lookD.x) > Mathf.Abs(collision.gameObject.GetComponent<PlayerController>().lookD.y))
    //        {
    //            if (playerScript.lookD.x < 0)
    //            {
    //                // анимация идти влево
    //            }
    //            //else // анимация идти вправо
    //            goToPlayer = true;
    //            //Debug.Log("goToPlayer = true;");
    //        }

    //    }
    //    //trPin.Translate(collision.transform.position);

    //}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMove>() != null)
        {

            //Debug.Log("<PlayerController>() != null");
            //Debug.Log("playerScript.lookD.x = " + playerScript.lookD.x);
            //Debug.Log("playerScript.lookD.y = " + playerScript.lookD.y);

            if (Mathf.Abs(playerScript.LookDirection.x) > Mathf.Abs(playerScript.LookDirection.y))  // собака смотрит вправо или влево, а не вверх и низ
            // if (Mathf.Abs(collision.gameObject.GetComponent<PlayerController>().lookD.x) > Mathf.Abs(collision.gameObject.GetComponent<PlayerController>().lookD.y))
            {
                if (trPlayer.position.x < trPin.position.x)   // если собака слева 
                {
                    if (playerScript.LookDirection.x < 0)   // если она смотрит влево
                    {
                        // анимация идти влево
                        dirLeftRight = -1f;
                        goToPlayer = true;
                    }
                    else goToPlayer = false;
                }

                else
                {
                    if (trPlayer.position.x > trPin.position.x)  // если собака справа
                    {
                        if (playerScript.LookDirection.x > 0)   // если она смотри враво
                        {
                            // анимация идти вправо
                            dirLeftRight = 1f;
                            goToPlayer = true;
                        }
                        else goToPlayer = false;
                    }


                    //Debug.Log("goToPlayer = true;");
                }
            }
        }
        //trPin.Translate(collision.transform.position);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerInteract>() != null)
        {
            goToPlayer = false;
            // вернуть анимацию idle
        }
    }
    void GoToPlayer()
    {
        trPin.Translate((Vector3.right * dirLeftRight) * speed * Time.deltaTime);
        // скорее всего надо наращивать скорость - либо резко, либо по-немному, но иначе она не дойдет никогда
        // типа trPin.Translate((Vector3.right * dirLeftRight) * speed*0,0001f * Time.deltaTime);
        // или по таймеру, через пару секунд уже изменить значение скорости

        // trPin.Translate(trPlayer.position.normalized * speed * Time.deltaTime);
        // Debug.Log("метод GoToPlayer() запущен");
    }
}
