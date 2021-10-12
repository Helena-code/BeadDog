using UnityEngine;
using Scripts.Enums;

public class DialogsData : MonoBehaviour
{
    // TODO переделать хранение в XML

    [SerializeField] private string[][] jBunny;             // объявляем ступенчатый массив строк
    [SerializeField] private string[][] jFrog;             // объявляем ступенчатый массив строк
    [SerializeField] private string[][] jCock;             // объявляем ступенчатый массив строк

    private void Awake()
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

    public string[] GetDialog(NPC npc, MeetStage stage)
    {
        switch (npc)
        {
            case NPC.Bunny:
                return jBunny[(int)stage];
                break;
            case NPC.Frog:
                return jFrog[(int)stage];
                break;
            case NPC.Cock:
                return jCock[(int)stage];
                break;
            default:
                return new string[0];
        }
    }
}
