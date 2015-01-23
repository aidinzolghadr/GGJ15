using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
	// Singleton
	private static SpawnManager instance = null;
	public static SpawnManager Instance { get { return instance; } }

	public float MoodIncreaseAmountPerSecond = 3;
	public float MoodDecrementPerSecond = -1;

	public int NumOfEasyWavesCreated;
	public int NumOfMediumWavesCreated;
	public int NumOfHardWavesCreated;


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
		/* 0 */	new Wave { Positions =	new int[] {0, 1},	MoodMin =  30,	MoodMax = 50},
		/* 1 */	new Wave { Positions =	new int[] {2, 3},	MoodMin =  35,	MoodMax = 50},
		/* 2 */	new Wave { Positions =	new int[] {0, 5},	MoodMin =  40,	MoodMax = 50},
		/* 3 */	new Wave { Positions =	new int[] {1, 6},	MoodMin =  20,	MoodMax = 50},

	};

	public Wave[] MediumWaves = new Wave[]
	{
		/* 0 */	new Wave { Positions =	new int[] {1},	MoodMin =  30,	MoodMax = 50},
		/* 1 */	new Wave { Positions =	new int[] {2},	MoodMin =  35,	MoodMax = 50},
		/* 2 */	new Wave { Positions =	new int[] {3},	MoodMin =  40,	MoodMax = 50},
		/* 3 */	new Wave { Positions =	new int[] {4},	MoodMin =  20,	MoodMax = 50},
	};

	public Wave[] HardWaves = new Wave[]
	{
		/* 0 */	new Wave { Positions =	new int[] {1},	MoodMin =  30,	MoodMax = 50},
		/* 1 */	new Wave { Positions =	new int[] {2},	MoodMin =  35,	MoodMax = 50},
		/* 2 */	new Wave { Positions =	new int[] {3},	MoodMin =  40,	MoodMax = 50},
		/* 3 */	new Wave { Positions =	new int[] {4},	MoodMin =  20,	MoodMax = 50},
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

//		Debug.Log("Loading wave#: " + WaveIndex);

		float MediumWaveChance = 0, HardWaveChance = 0;

		// Calculating chances
		if (WaveIndex >= MediumWaveIndexStarterNumber)
		{
			MediumWaveChance = (WaveIndex - MediumWaveIndexStarterNumber) * 0.05f;
		}

		if (WaveIndex >= HardWaveIndexStarterNumber)
		{
			HardWaveChance = (WaveIndex - HardWaveIndexStarterNumber) * 0.05f;
		}


		float die = Random.value;

		Debug.Log(die);

		float EasyWaveChance = 1 - (MediumWaveChance + HardWaveChance);
		MediumWaveChance += HardWaveChance;

		if (WaveIndex >= 12)
			EasyWaveChance = 0;

		if (WaveIndex >= 23)
		{
			MediumWaveChance = 0;
			HardWaveChance = 1;
		}



		if (die <= HardWaveChance)
		{
			int randomWave = Random.Range(0, HardWaves.Length);
			CurrentWave = HardWaves[randomWave];
			
			//			Debug.Log("CurrentWave HardWaves#: " + randomWave);
			NumOfHardWavesCreated = NumOfHardWavesCreated + 1;
		}
		else if (die <= MediumWaveChance)
		{
			int randomWave = Random.Range(0, MediumWaves.Length);
			CurrentWave = MediumWaves[randomWave];
			
			//			Debug.Log("CurrentWave MediumWaves#: " + randomWave);
			NumOfMediumWavesCreated = NumOfMediumWavesCreated + 1;
		}
		else
		{
			int randomWave = Random.Range(0, EasyWaves.Length);
			CurrentWave = EasyWaves[Random.Range(0, EasyWaves.Length)];
			
			//			Debug.Log("CurrentWave EasyWaves#: " + CurrentWave);
			NumOfEasyWavesCreated = NumOfEasyWavesCreated + 1;
		}

		// Selecting a Medium wave
		if (die <= MediumWaveChance + HardWaveChance)
		{

		}

		// Selecting a Hard wave
		else if (die <= MediumWaveChance)
		{

		}


		// Selecting an Easy wave
		else
		{

		}

		// Applying new wave

		for (int i = 0; i < Planets.Length; i++)
		{
			if ( doesCurrentWaveHaveMe( i ))
			{
				Planets[i].CurrentMood = Random.Range(CurrentWave.MoodMin, CurrentWave.MoodMax);
				Planets[i].ResetMoodMultiplier();
				Planets[i].gameObject.SetActive(true);
			}
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

		/*
		for (int i = 0; i < 2500; i++)
		{
			LoadNextWave();
		}

		Debug.Log("Num Of Easy Waves Created: " + 	NumOfEasyWavesCreated);
		Debug.Log("Num Of Medium Waves Created: " + NumOfMediumWavesCreated);
		Debug.Log("Num Of Hard Waves Created: " + 	NumOfHardWavesCreated);
		*/

	}
	
	void Update ()
	{

		if (isCurrentWaveClear())
		{
			LoadNextWave();
		}
		
	}
}
