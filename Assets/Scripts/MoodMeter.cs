using UnityEngine;
using System.Collections;

public class MoodMeter : MonoBehaviour
{
	public float MaxMood = 100;
	public float CurrentMood = 40;

	private float MoodDelta = -1;
	private GUIText _myGUItext;

//	private float _maxScale = 0.45f;
//	private float _minScale = 0.15f;

	private SpriteRenderer _spriteRenderer;

	public Sprite[] fruitSprites;

	public int TreeID;

	public void IncreaseMood ()
	{
		MoodDelta = SpawnManager.Instance.MoodIncreaseAmountPerSecond;
	}

	public void ResetMoodMultiplier ( )
	{
		MoodDelta = SpawnManager.Instance.MoodDecrementPerSecond;
	}

	public void Reset()
	{
		CurrentMood = 40;
	}

	void updateArtBasedOnMood()
	{

		if (CurrentMood <= 20)
		{
			_spriteRenderer.sprite = AnimationManager.Instance.GetTreeSprite( TreeID, 0);
		}
		else if (CurrentMood < 40)
		{
			_spriteRenderer.sprite = AnimationManager.Instance.GetTreeSprite( TreeID, 1);
		}
		else if (CurrentMood < 60)
		{
			_spriteRenderer.sprite = AnimationManager.Instance.GetTreeSprite( TreeID, 2);
		}
		else if (CurrentMood < 80)
		{
			_spriteRenderer.sprite = AnimationManager.Instance.GetTreeSprite( TreeID, 3);
		}
		else if (CurrentMood <= 100)
		{
			_spriteRenderer.sprite = AnimationManager.Instance.GetTreeSprite( TreeID, 4);
		}
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
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Start ()
	{
		ResetMoodMultiplier();
	}

	void Update ()
	{
		UpdateMood();
		updateArtBasedOnMood();
		_myGUItext.text = ((int)CurrentMood).ToString();

		/*
		float normalMaxScale = _maxScale - _minScale;

		float scale = ( CurrentMood * normalMaxScale ) / MaxMood;
		scale += _minScale;
		scale = (scale < _minScale) ? _minScale : scale;

		transform.localScale =  new Vector3 ( scale, scale, scale);
		*/
	}
}
