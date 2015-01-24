using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
	public int MinimumAcceptableMood = 100;

	bool isCurrentWaveClear ()
	{
		MoodMeter[] tutorialPlants = GameObject.FindObjectsOfType<TutorialTree>();
		
		for (int i = 0; i < tutorialPlants.Length; i++)
		{
			if (tutorialPlants[i].gameObject.activeSelf)
				if (tutorialPlants[i].CurrentMood < MinimumAcceptableMood)
					return false;
		}
		
		return true;
	}

	void LoadGameScene()
	{
		Application.LoadLevel("Main");
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isCurrentWaveClear())
		{
			LoadGameScene();
		}
	}
}
