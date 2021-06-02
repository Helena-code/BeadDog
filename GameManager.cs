using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool quest1;
    public bool quest2;
    public bool quest3;

    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    public GameObject dop;

    public GameObject npc1;
    private void Awake()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
    }
    void Update()
    {
        if (quest1 == true)
        {
            ChangePerson(1);
            ChangeLocation();
        }
    }
    void ChangePerson(int person)
    {
        if (person == 1)
        {
            // сменить анимацию и диалоги персонажам 1 локации
            npc1.GetComponent<Animator>().SetTrigger("BunnyQuest");
        }
        if (person == 2)
        {
            // сменить анимацию и диалоги персонажам 2 локации
        }
        if (person == 3)
        {
            // сменить анимацию и диалоги персонажам 3 локации
            // или записать данные и персонажи их считают
        }
    }
    void ChangeLocation()
    {
        dop.SetActive(true);
    }
    public void ChangeCamera(int location)
    {
        if (location == 2)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        } else if (location == 3)
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
        }

        // РАБОЧЕЕ ИЗМЕНЕНИЕ ГРАНИЦ ЭКРАНА ПРИ ИЗМЕНЕНИИ ЛОКАЦИИ
        //CinemachineConfiner cmConf = player.cam2.GetComponent<CinemachineConfiner>();
        //cmConf.m_BoundingShape2D = border2.GetComponent<Collider2D>();
    }
}
