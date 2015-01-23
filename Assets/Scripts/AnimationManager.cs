using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour
{
	// Singleton
	private static AnimationManager instance = null;
	public static AnimationManager Instance { get { return instance; } }

	private Sprite[] _trees;

	void Awake ()
	{
		// Singleton
		instance = this;

		_trees = Resources.LoadAll<Sprite>("trees");
	}

	public Sprite GetTreeSprite (int treeID, int frame)
	{
		return _trees[ (treeID * 5) + frame];
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
