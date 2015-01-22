using UnityEngine;
using System.Collections;

public class MoodMeter : MonoBehaviour
{
	public float MaxMood = 100;
	public float CurrentMood = 40;

	public float MoodIncreaseAmountPerSecond = 3;
	public float MoodDecrementPerSecond = -1;

	private float MoodDelta = -1;

	public void IncreaseMood ()
	{
		MoodDelta = MoodIncreaseAmountPerSecond;
//		CurrentMood = CurrentMood > MaxMood ? MaxMood : CurrentMood;
	}

	public void DecreaseMood ()
	{
		MoodDelta = MoodDecrementPerSecond;
//		CurrentMood = CurrentMood <= 0 ? 0 : CurrentMood;
	}

//	void OnTriggerStay2D (Collider2D other)
//	{
//
//	}

//	void OnTriggerExit2D (Collider2D other)
//	{
//
//	}

	void UpdateMood()
	{
		CurrentMood += MoodDelta * Time.deltaTime;
	}

	void Start ()
	{
		MoodDelta = MoodDecrementPerSecond;
	}

	// Update is called once per frame
	void Update ()
	{
		UpdateMood();
		Debug.Log(CurrentMood);
	}
}
