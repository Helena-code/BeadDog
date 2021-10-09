using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Enums;

public class QuestThing : MonoBehaviour
{
    public bool IsCollected
    {
        get { return _isCollected; }
    }

    [SerializeField] private NPC _questNPC;

    private int _questNumber = 1;   // TODO сделать связку с самими квестами или назначать их программно
    private bool _isCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInteract _player = other.GetComponent<PlayerInteract>();
        if (_player != null)
        {
            _isCollected = true;

            
            //_player.bunnyQuestState = 2;


            
            Destroy(gameObject);
            // УСТАНОВИТЬ ЗНАЧЕНИЕ КВЕСТА 1 НА ВЫПОЛНЕНО
            // СМЕНИТЬ АНИМАЦИЮ У КВЕСТОВЫХ ПЕРСОНАЖЕЙ 1
        }
    }
}
