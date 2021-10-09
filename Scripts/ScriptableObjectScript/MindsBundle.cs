using UnityEngine;


[CreateAssetMenu(fileName = "New MindBundleData", menuName = "ScriptableObjects/Menu Mind Bundle Data")]
public class MindsBundle : ScriptableObject
{
   [SerializeField] [TextArea]
    private string[] _mindsArray;

    public string[] MindsArray
    {
        get { return _mindsArray; }
    }
}
