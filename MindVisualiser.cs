using TMPro;
using UnityEngine;
using System.Collections;

public class MindVisualiser : MonoBehaviour
{
    [SerializeField] private GameObject _mindWindow;
    [SerializeField] private TextMeshProUGUI _mindText;
    [SerializeField] private MindsBundle _mindBundle;

    private string[] _mindsArray;
    private int _mindNumber = 0;


    void Awake()   
    {
        _mindWindow.SetActive(false);
        _mindsArray = _mindBundle.MindsArray;
    }

    public void ShowMind()
    {
        _mindWindow.SetActive(true);
        _mindText.SetText(_mindsArray[_mindNumber]);
        _mindNumber++;
        StartCoroutine(ReadingMind());
    }

    public void HideMind()
    {
        _mindWindow.SetActive(false);
    }

    private IEnumerator ReadingMind()
    {
        yield return new WaitForSeconds(GameBalance.Instance.TimeThinkingMind);
        HideMind();
        yield break;
    }
}
