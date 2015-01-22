using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
	// Singleton
	private static SpawnManager instance = null;
	public static SpawnManager Instance { get { return instance; } }

	public float MoodIncreaseAmountPerSecond = 3;
	public float MoodDecrementPerSecond = -1;


	// TODO: Tutorial wave

	public Wave[] StartWave = new Wave[]
	{
		/* 0 */	new Wave { Positions =	new int[] {1},	MoodMin =  50,	MoodMax = 90},
	};

	//TODO: Normal wave

	public int WaveIndex = 0;

	public MoodMeter[] Planets;

	void Awake()
	{
		// Singleton
		instance = this;
	}

	void Start ()
	{
	
	}
	
	void Update ()
	{
		
	}
}
