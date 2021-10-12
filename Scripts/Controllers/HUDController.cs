using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    public static HUDController Instance;

    [SerializeField] private Text _healthText;
    [SerializeField] private Text _blueBeadsText;
    [SerializeField] private Text _bulletText;
    [SerializeField] private Text _whiteBeadsText;
    [SerializeField] private Text _lockText;
    [SerializeField] private GameObject dialogCanvas;
    [SerializeField] private TextMeshProUGUI dialogText;

    // TODO HUD не хранит значения,а только их отображает, переделать
    float currentHealth;
    public int healthChestNumber;                            // количество аптечек
    public int bulletNumber;                                 // количество патронов
    public int whiteBeadsNumber;                             // количество белых бусин
    public int lockNumber;                                   // количество замочков

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Another instance of GameBalance already exists!");
        }
        Instance = this;

        // тестовый UI
        _healthText.text = "Health: ";
        _blueBeadsText.text = "Blue beads: ";
        _bulletText.text = "Bullet: ";
        _whiteBeadsText.text = "White beads: ";
        _lockText.text = "Lock: ";
    }

    public void ShowDialog(string[] currentDialog)
    {
        //dialogCanvas.SetActive(true);
        //currentText = 0;
        //dialogText.SetText(_currentDialog[currentText]);
        //currentText += 1;
    }


    // МЕТОД ПРИ НАЖАТИИ КНОПКИ В ДИАЛОГЕ
    public void NextText()
    {
        //Debug.Log("кнопка нажата");

        //if (currentText == _currentDialog.Length)
        //{
        //    dialogCanvas.SetActive(false);
        //    // то закрытие диалогового окна и активация канваса с джостиком
        //}
        //else
        //{
        //    dialogText.SetText(_currentDialog[currentText]);
        //    currentText += 1;
        //}

    }

}
