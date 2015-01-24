using UnityEngine;
using System.Collections;

public class TutorialTree : MoodMeter
{
	protected override void Start ()
	{
		base.MoodDelta = 0;
//		ResetMoodMultiplier();
	}

//	public new void IncreaseMood ()
//	{
//		MoodDelta = 20;
//	}

	public override void IncreaseMood ()
	{
		MoodDelta = 20;
	}

	public override void ResetMoodMultiplier ( )
	{
		MoodDelta = 0;
	}

//	void Update ()
//	{
		
		/*
		float normalMaxScale = _maxScale - _minScale;

		float scale = ( CurrentMood * normalMaxScale ) / MaxMood;
		scale += _minScale;
		scale = (scale < _minScale) ? _minScale : scale;

		transform.localScale =  new Vector3 ( scale, scale, scale);
		*/
//	}
}
