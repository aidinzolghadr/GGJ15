﻿using UnityEngine;
using System.Collections;

public class MoodMeter : MonoBehaviour
{
	public float MaxMood = 100;
	public float CurrentMood = 40;

	private float MoodDelta = -1;
	private GUIText _myGUItext;

	private float _maxScale = 0.45f;
	private float _minScale = 0.15f;

	public void IncreaseMood ()
	{
		MoodDelta = SpawnManager.Instance.MoodIncreaseAmountPerSecond;
	}

	public void ResetMoodMultiplier ( )
	{
		MoodDelta = SpawnManager.Instance.MoodDecrementPerSecond;
	}

	void UpdateMood()
	{
		CurrentMood += MoodDelta * Time.deltaTime;

		// Clamps
		CurrentMood = CurrentMood > MaxMood ? MaxMood : CurrentMood;
		CurrentMood = CurrentMood <= 0 ? 0 : CurrentMood;
	}

	void Awake()
	{
		_myGUItext = transform.GetComponentInChildren<GUIText>();
	}

	void Start ()
	{
		ResetMoodMultiplier();
	}

	void Update ()
	{
		UpdateMood();
		_myGUItext.text = ((int)CurrentMood).ToString();

		float normalMaxScale = _maxScale - _minScale;

		float scale = ( CurrentMood * normalMaxScale ) / MaxMood;
		scale += _minScale;
		scale = (scale < _minScale) ? _minScale : scale;

		transform.localScale =  new Vector3 ( scale, scale, scale);
	}
}
