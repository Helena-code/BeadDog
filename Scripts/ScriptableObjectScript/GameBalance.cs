using UnityEngine;


[CreateAssetMenu(fileName = "New GameBalance", menuName = "ScriptableObjects/Menu Game Balance")]
public class GameBalance : ScriptableObject
{
	public static GameBalance Instance
	{
		get; private set;
	}

	[Header("GeneralSettings")]
	public float TimeThinkingMind;

	private void Awake()
    {
		if (Instance != null)
        {
			Debug.LogError("Another instance of GameBalance already exists!");
		}
		Instance = this;
	}
}
