using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogArray : MonoBehaviour
{
    public string[][] jBunny;             // объявляем ступенчатый массив строк
    public string[][] jFrog;             // объявляем ступенчатый массив строк
    public void Awake()               
    {
        jBunny = new string[3][];        // массив длиной 3, вложенные массивы любой длины
        jBunny[0] = new string[]         // первоначальные реплики
        {
            "Плак-плак-плак",
            "Что случилось? Почему ты плачешь?",
            "Привет, незнакомец.. Да как же не плакать.. Мой малыш, мой зайченок.."
        };
        jBunny[1] = new string[]         // реплика при полученном задании 
      {
            "Плак-плак"
      };
        jBunny[2] = new string[]         // реплики при выполненном задании 
     {
            "",
            "",
            ""
     };

        jFrog = new string[3][];        // массив длиной 3, вложенные массивы любой длины
        jFrog[0] = new string[]         // первоначальные реплики
        {
            "Привет!",
            "Привет",
            "У меня есть секрет",
            "Здорово!"
        };
        jFrog[1] = new string[]         // реплика при полученном задании 
      {
            "Я буду прямо здесь"
      };
        jFrog[2] = new string[]         // реплики при выполненном задании 
     {
            "Задание выполнено!",
            "",
            ""
     };
    }
}
