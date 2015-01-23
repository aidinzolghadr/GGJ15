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
		/* 0 */	new Wave { Positions =	new int[] {0},	MoodMin =  50,	MoodMax = 90},
		/* 1 */	new Wave { Positions =	new int[] {1},	MoodMin =  50,	MoodMax = 90},
		/* 2 */	new Wave { Positions =	new int[] {2},	MoodMin =  50,	MoodMax = 90},
		/* 3 */	new Wave { Positions =	new int[] {3},	MoodMin =  50,	MoodMax = 90},

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

	public int WaveIndex = -1;	// it's -1 so first time that we increase it in LoadNextWave, it gets to zero. ("I know, right?")
	public Wave CurrentWave;

	public MoodMeter[] Planets;

	public int MediumWaveIndexStarterNumber = 1;
	public int HardWaveIndexStarterNumber 	= 3;

	public const int MinimumAcceptableMood = 60;

	void disableAllPlanets ()
	{
		for (int i = 0; i < Planets.Length; i++)
		{
			Planets[i].gameObject.SetActive(false);
		}
	}

	bool isCurrentWaveClear ()
	{
//		MoodMeter[] planets = GameObject.FindObjectsOfType<MoodMeter>();

		for (int i = 0; i < Planets.Length; i++)
		{
			if (Planets[i].gameObject.activeSelf)
				if (Planets[i].CurrentMood < MinimumAcceptableMood)
					return false;
		}

		return true;
	}

	bool doesCurrentWaveHaveMe(int planetIndex)
	{
		for (int i = 0; i < CurrentWave.Positions.Length; i++)
		{
			if (CurrentWave.Positions[i] == planetIndex)
				return true;
		}

		return false;
	}

	void LoadNextWave()
	{
		++WaveIndex;

		Debug.Log("Loading wave#: " + WaveIndex);

		// Calculating chances
		float MediumWaveChance = (WaveIndex - MediumWaveIndexStarterNumber) * 0.05f;
		float HardWaveChance = (WaveIndex - HardWaveIndexStarterNumber) * 0.05f;

		float die = Random.value;

		if (die <= MediumWaveChance)
		{
			CurrentWave = MediumWaves[Random.Range(0, MediumWaves.Length)];
			Debug.Log("CurrentWave MediumWaves#: " + CurrentWave);
		}
		else if (die <= MediumWaveChance + HardWaveChance)
		{
			CurrentWave = HardWaves[Random.Range(0, HardWaves.Length)];
			Debug.Log("CurrentWave HardWaves#: " + CurrentWave);
		}
		else
		{
			CurrentWave = EasyWaves[Random.Range(0, EasyWaves.Length)];
			Debug.Log("CurrentWave EasyWaves#: " + CurrentWave);
		}

		// Applying new wave

		for (int i = 0; i < Planets.Length; i++)
		{
			if ( doesCurrentWaveHaveMe( i ))
			    Planets[i].gameObject.SetActive(true);
			else
			    Planets[i].gameObject.SetActive(false);
		}

	}

	void Awake()
	{
		// Singleton
		instance = this;
	}

	void Start ()
	{
		disableAllPlanets();

	}
	
	void Update ()
	{
		if (isCurrentWaveClear())
		{
			LoadNextWave();
		}
		
	}
}
