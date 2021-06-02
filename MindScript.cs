using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MindScript : MonoBehaviour
{
    public GameObject mindCanvas;
    public TextMeshProUGUI dogMind;
    int mindNumber = 0;
    string[] MindArray = new string[6];
    void Awake()
    {
        //mindCanvas = GetComponentInChildren<Canvas>();
        //mindCanvas.enabled = false;
        //mindCanvas = GetComponentInChildren<Canvas>();

        mindCanvas.SetActive(false);

        MindArray[0] = "О, вот и синий крест из очень толстых ниточек.. Наверное, о нем говорила Зайчиха. Нужно осторожно поискать вокруг.";
        MindArray[1] = "О, что это?.. Какие чудесные цветы! Сорву парочку, порадовать Зайчиху. Ой.. Они такие прочные.. Это не цветы! Это иголки! Они мне пригодятся.";
        MindArray[2] = "Еще один крест. И какая то странная штуковина. На язык похоже. Возьму ее.";
        MindArray[3] = "Еще крест. Но вокруг ничего нет. И я слышу скрип недалеко впереди..";
        MindArray[4] = "Это было очень стр.. Сложно. Но я справился. А вот и бусины.";
        MindArray[5] = "Никогда такого не видел.. Она выглядит..Волшебно..";
    }

    
    public void ShowMind()
    {
        mindCanvas.SetActive(true);
        dogMind.SetText(MindArray[mindNumber]);
        //dogMind.SetText("G");
        //Debug.Log(MindArray[5]);
        mindNumber += 1;
        Invoke("MindClose", 7.0f);
    }
    public void MindClose()
    {
        mindCanvas.SetActive(false);
    }
}
