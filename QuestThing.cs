using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestThing : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControllerScr player = other.GetComponent<PlayerControllerScr>();
        if (player != null)
        {
            player.gameManager.quest1 = true;
            Debug.Log("квест 1 выполнен");
            player.bunnyQuestState = 2;
            Destroy(gameObject);
            // УСТАНОВИТЬ ЗНАЧЕНИЕ КВЕСТА 1 НА ВЫПОЛНЕНО
            // СМЕНИТЬ АНИМАЦИЮ У КВЕСТОВЫХ ПЕРСОНАЖЕЙ 1
        }
    }
}
