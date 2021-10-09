using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour
{
    public GameObject dialogCanvas;
    public TextMeshProUGUI dialogText;

    int currentText;
    string[] currentDialog;
    DialogArray da;


    public void Awake()
    {
        da = GetComponent<DialogArray>();
    }
    public void ShowDialogCanvas(string name, int state)
    {
        dialogCanvas.SetActive(true);
        
        currentText = 0;
        if (name == "Bunny")
        {
            currentDialog = da.jBunny[state];
        }
        else if (name == "Frog")
        {
            currentDialog = da.jFrog[state];
        }

        dialogText.SetText(currentDialog[currentText]);
        currentText += 1;

    }

    // МЕТОД ПРИ НАЖАТИИ КНОПКИ В ДИАЛОГЕ
    public void NextText()             
    {
        //Debug.Log("кнопка нажата");
        
        if (currentText == currentDialog.Length)
        {
            dialogCanvas.SetActive(false);
            // то закрытие диалогового окна и активация канваса с джостиком
        }
        else
        {
            dialogText.SetText(currentDialog[currentText]);
            currentText += 1;
        }

    }

}
