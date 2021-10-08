using UnityEngine;


[CreateAssetMenu(fileName = "New MindBundleData", menuName = "Menu Bundle Data")]
public class MindsBundle : ScriptableObject
{
   [SerializeField] [TextArea]
    private string[] _mindsArray;

    public string[] MindsArray
    {
        get { return _mindsArray; }
    }
}
