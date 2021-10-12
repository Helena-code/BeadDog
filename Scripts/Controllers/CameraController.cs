using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject cam1;
    [SerializeField] private GameObject _cam2;
    [SerializeField] private GameObject _cam3;


    private void Awake()
    {
        cam1.SetActive(true);
        _cam2.SetActive(false);
        _cam3.SetActive(false);
    }

    public void ChangeCamera(int location)
    {
        if (location == 2)
        {
            cam1.SetActive(false);
            _cam2.SetActive(true);
        }
        else if (location == 3)
        {
            cam1.SetActive(false);
            _cam2.SetActive(false);
            _cam3.SetActive(true);
        }

        // РАБОЧЕЕ ИЗМЕНЕНИЕ ГРАНИЦ ЭКРАНА ПРИ ИЗМЕНЕНИИ ЛОКАЦИИ
        //CinemachineConfiner cmConf = player._cam2.GetComponent<CinemachineConfiner>();
        //cmConf.m_BoundingShape2D = border2.GetComponent<Collider2D>();
    }
}

