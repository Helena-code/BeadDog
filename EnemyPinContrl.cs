using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPinContrl : MonoBehaviour
{
    Transform trPin;
    public Transform trPlayer;
    PlayerControllerScr playerScript;

    private void Start()
    {
        trPin = GetComponent<Transform>();
        playerScript = trPlayer.gameObject.GetComponent<PlayerControllerScr>();
    }


    private void Update()
    {
        if (Vector2.Distance(trPin.position, trPlayer.position) < 2f)
        {
            // если не атака
            CheckingPlayer();

        }
    }

    void CheckingPlayer()
    {

        if (Mathf.Abs(playerScript.lookD.x) > Mathf.Abs(playerScript.lookD.y))    // т.е. собака смотрит вправо или влево
            
        {
            // определить булеву переменную куда смотрит лево или право
            // пустить луч влево
            // если есть собака и она смотрит влево - атаковать
            // пустить луч вправо 
            // тоже самое только право
            // обнулить булевы переменные
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.GetComponent< PlayerControllerScr>() != null)
    //    {
    //        if (Mathf.Abs( other.gameObject.GetComponent<PlayerControllerScr>().lookD.x)> Mathf.Abs(other.gameObject.GetComponent<PlayerControllerScr>().lookD.y))
    //        {
    //            if ()
    //        }
    //        trPin.Translate(other.transform.position);
    //    }
    //}
}
