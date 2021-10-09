using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PortalScr : MonoBehaviour
{
    public GameObject doorExit;     // местоположение выхода из двери
    public GameObject border2;      // это тут для смены границ?? не через гейм менеджер?
    public GameObject pl;
    public int exitLocationNumber;

    PlayerInteract player;
    Rigidbody2D rb;
    public bool doorOpen = false;

    public void Awake()
    {
        player = pl.GetComponent<PlayerInteract>();
        rb = pl.GetComponent<Rigidbody2D>();
    }
    public void Door()
    {
        if (doorOpen)
        {
            rb.position = doorExit.transform.position;
            //player._gameManager.ChangeCamera(exitLocationNumber); // TODO ВЕРНУТЬ, но в другое место

            // прописать, что игрок должен выйти из зоны коллаидера двери
            // и отойти к какой нибудь точке - наверное уже не надо
        }

        else if (doorOpen == false)
        {
            //Debug.Log("дверь закрыта");
            if (player.lockNumber > 0)
            {
                doorOpen = true;
                // отключить коллаидер на время анимации и включить через пару секунд
                player.lockNumber -= 1;
                //Debug.Log("дверь открылась");
            }
            else return;
        }
    }
}
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    PlayerController player = other.GetComponent<PlayerController>();
    //    if (player != null)
    //    {
    //        //Debug.Log("дверь увидела игрока");
    //        if (doorOpen)
    //        {
    //            //Debug.Log("дверь уже открыта");
    //            Rigidbody2D rb = player.gameObject.GetComponent<Rigidbody2D>();

    //            //if (player.local.Equals("red"))
    //            //player.local = "green";

    //            rb.position = doorExit.transform.position;
    //            player.gameManager.ChangeCamera(exitLocationNumber);

    //            // прописать, что игрок должен выйти из зоны коллаидера двери
    //            // и отойти к какой нибудь точке
    //            // уменьшить коллаидер двери - он будет вызываться по нажатию действие
    //            // наверное
    //            // отключить коллаидер на время анимации и включить через пару секунд

    //        }
            
    //        else if (doorOpen == false)
    //        {
    //            //Debug.Log("дверь закрыта");
    //            if (player.lockNumber > 0)
    //            {
    //                doorOpen = true;
    //                player.lockNumber -= 1;
    //                //Debug.Log("дверь открылась");
    //            }
    //            else return;
    //        }



        
    

