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


//	public Wave[] StartWave = new Wave[]
//	{
//		/* 0 */	new Wave { Positions =	new int[] {1},	MoodMin =  50,	MoodMax = 90},
//		/* 1 */	new Wave { Positions =	new int[] {2},	MoodMin =  50,	MoodMax = 90},
//		/* 2 */	new Wave { Positions =	new int[] {3},	MoodMin =  50,	MoodMax = 90},
//		/* 3 */	new Wave { Positions =	new int[] {4},	MoodMin =  50,	MoodMax = 90},
//	};

	public Wave[] EasyWaves = new Wave[]
	{
		/* 0 */	new Wave { Positions =	new int[] {1},	MoodMin =  50,	MoodMax = 90},
		/* 1 */	new Wave { Positions =	new int[] {2},	MoodMin =  50,	MoodMax = 90},
		/* 2 */	new Wave { Positions =	new int[] {3},	MoodMin =  50,	MoodMax = 90},
		/* 3 */	new Wave { Positions =	new int[] {4},	MoodMin =  50,	MoodMax = 90},
	};

	public Wave[] MediumWaves = new Wave[]
	{
		/* 0 */	new Wave { Positions =	new int[] {1},	MoodMin =  50,	MoodMax = 90},
		/* 1 */	new Wave { Positions =	new int[] {2},	MoodMin =  50,	MoodMax = 90},
		/* 2 */	new Wave { Positions =	new int[] {3},	MoodMin =  50,	MoodMax = 90},
		/* 3 */	new Wave { Positions =	new int[] {4},	MoodMin =  50,	MoodMax = 90},
	};

	public Wave[] HardWaves = new Wave[]
	{
		/* 0 */	new Wave { Positions =	new int[] {1},	MoodMin =  50,	MoodMax = 90},
		/* 1 */	new Wave { Positions =	new int[] {2},	MoodMin =  50,	MoodMax = 90},
		/* 2 */	new Wave { Positions =	new int[] {3},	MoodMin =  50,	MoodMax = 90},
		/* 3 */	new Wave { Positions =	new int[] {4},	MoodMin =  50,	MoodMax = 90},
	};

	public int WaveIndex = 0;
	public Wave CurrentWave;

	public MoodMeter[] Planets;

	public int MediumWaveIndexStarterNumber = 1;
	public int HardWaveIndexStarterNumber 	= 3;

	public const int MinimumAcceptableMood = 60;

	bool currentWaveIsClear ()
	{
//		MoodMeter[] planets = GameObject.FindObjectsOfType<MoodMeter>();

		for (int i = 0; i < Planets.Length; i++)
		{
			if (Planets[i].CurrentMood < MinimumAcceptableMood)
				return false;
		}

		return true;
	}

	void LoadNextWave()
	{


		++WaveIndex;

		// Calculating chances
		int MediumWaveChance = (WaveIndex - MediumWaveIndexStarterNumber) * 0.05;
		int HardWaveChance = (WaveIndex - HardWaveIndexStarterNumber) * 0.05;

//		int EasyWaveChance = 1 - (MediumWaveChance + HardWaveChance);

		int die = Random.value;

		if (die <= MediumWaveChance)
		{
			CurrentWave = MediumWaves[Random.Range(0, MediumWaves.Length)];
		}
		else if (die <= MediumWaveChance + HardWaveChance)
		{
			CurrentWave = HardWaveChance[Random.Range(0, HardWaves.Length)];
		}
		else
		{
			CurrentWave = EasyWaves[Random.Range(0, EasyWaves.Length)];
		}


	}

	void Awake()
	{
		// Singleton
		instance = this;
	}

	void Start ()
	{
		if (currentWaveIsClear())
		{
			LoadNextWave();
		}
	}
	
	void Update ()
	{
		
	}
}
