using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
	// Singleton
	private static SpawnManager instance = null;
	public static SpawnManager Instance { get { return instance; } }

	public float MoodIncreaseAmountPerSecond = 3;
	public float MoodDecrementPerSecond = -1;

	public int MaxNumOfAcceptableDeadTrees;

	public int NumOfEasyWavesCreated;
	public int NumOfMediumWavesCreated;
	public int NumOfHardWavesCreated;

	private int[] LoadedTreeIDsForThisWave;

	private bool isGameOver = false;

	public Canvas GameOverCanvase;

	public Text SavedTreeText;
	public int NumOfSavedTrees = 0;

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
		/* 0 */		new Wave { Positions =	new int[] {1, 2},			MoodMin =  30,	MoodMax = 50},
		/* 1 */		new Wave { Positions =	new int[] {2, 3},			MoodMin =  30,	MoodMax = 50},
		/* 2 */		new Wave { Positions =	new int[] {3, 4},			MoodMin =  30,	MoodMax = 50},
		/* 3 */		new Wave { Positions =	new int[] {4, 5},			MoodMin =  30,	MoodMax = 50},
		/* 4 */		new Wave { Positions =	new int[] {5, 6},			MoodMin =  30,	MoodMax = 50},
		/* 5 */		new Wave { Positions =	new int[] {6, 7},			MoodMin =  30,	MoodMax = 50},
		/* 6 */		new Wave { Positions =	new int[] {7, 0},			MoodMin =  30,	MoodMax = 50},
		/* 7 */		new Wave { Positions =	new int[] {1, 2, 	3},		MoodMin =  45,	MoodMax = 50},
		/* 8 */		new Wave { Positions =	new int[] {2, 3, 	4},		MoodMin =  45,	MoodMax = 50},
		/* 9 */		new Wave { Positions =	new int[] {3, 4, 	5},		MoodMin =  45,	MoodMax = 50},
		/* 10 */	new Wave { Positions =	new int[] {5, 6, 	7},		MoodMin =  45,	MoodMax = 50},
		/* 11 */	new Wave { Positions =	new int[] {6, 7, 	0},		MoodMin =  45,	MoodMax = 50},
		/* 12 */	new Wave { Positions =	new int[] {7, 0, 	1},		MoodMin =  45,	MoodMax = 50},
		/* 13 */	new Wave { Positions =	new int[] {1},				MoodMin =  20,	MoodMax = 50},
		/* 14 */	new Wave { Positions =	new int[] {2},				MoodMin =  20,	MoodMax = 50},
		/* 15 */	new Wave { Positions =	new int[] {3},				MoodMin =  20,	MoodMax = 50},
		/* 16 */	new Wave { Positions =	new int[] {4},				MoodMin =  20,	MoodMax = 50},
		/* 17 */	new Wave { Positions =	new int[] {5},				MoodMin =  20,	MoodMax = 50},
		/* 18 */	new Wave { Positions =	new int[] {6},				MoodMin =  20,	MoodMax = 50},
		/* 19 */	new Wave { Positions =	new int[] {7},				MoodMin =  20,	MoodMax = 50},
	};
	
	public Wave[] MediumWaves = new Wave[]
	{
		/* 1 */		new Wave { Positions =	new int[] {1, 3},					MoodMin =  30,	MoodMax = 40},
		/* 2 */		new Wave { Positions =	new int[] {2, 4},					MoodMin =  30,	MoodMax = 40},
		/* 3 */		new Wave { Positions =	new int[] {3, 5},					MoodMin =  30,	MoodMax = 40},
		/* 4 */		new Wave { Positions =	new int[] {4, 6},					MoodMin =  30,	MoodMax = 40},
		/* 5 */		new Wave { Positions =	new int[] {5, 7},					MoodMin =  30,	MoodMax = 40},
		/* 6 */		new Wave { Positions =	new int[] {6, 0},					MoodMin =  30,	MoodMax = 40},
		/* 7 */		new Wave { Positions =	new int[] {7, 1},					MoodMin =  30,	MoodMax = 40},
		/* 8 */		new Wave { Positions =	new int[] {1, 4},					MoodMin =  30,	MoodMax = 50},
		/* 9 */		new Wave { Positions =	new int[] {2, 5},					MoodMin =  30,	MoodMax = 50},
		/* 10 */	new Wave { Positions =	new int[] {3, 6},					MoodMin =  30,	MoodMax = 50},
		/* 11 */	new Wave { Positions =	new int[] {4, 7},					MoodMin =  30,	MoodMax = 50},
		/* 12 */	new Wave { Positions =	new int[] {5, 0},					MoodMin =  30,	MoodMax = 50},
		/* 13 */	new Wave { Positions =	new int[] {6, 1},					MoodMin =  30,	MoodMax = 50},
		/* 14 */	new Wave { Positions =	new int[] {7, 2},					MoodMin =  30,	MoodMax = 50},
		/* 15 */	new Wave { Positions =	new int[] {1, 5},					MoodMin =  45,	MoodMax = 50},
		/* 16 */	new Wave { Positions =	new int[] {2, 6},					MoodMin =  45,	MoodMax = 50},
		/* 17 */	new Wave { Positions =	new int[] {3, 7},					MoodMin =  45,	MoodMax = 50},
		/* 18 */	new Wave { Positions =	new int[] {4, 0},					MoodMin =  45,	MoodMax = 50},
		/* 19 */	new Wave { Positions =	new int[] {5, 1},					MoodMin =  45,	MoodMax = 50},
		/* 20 */	new Wave { Positions =	new int[] {1, 6},					MoodMin =  45,	MoodMax = 50},
		/* 21 */	new Wave { Positions =	new int[] {2, 7},					MoodMin =  45,	MoodMax = 50},
		/* 22 */	new Wave { Positions =	new int[] {3, 0},					MoodMin =  45,	MoodMax = 50},
		/* 23 */	new Wave { Positions =	new int[] {4, 1},					MoodMin =  30,	MoodMax = 50},
		/* 24 */	new Wave { Positions =	new int[] {5, 2},					MoodMin =  30,	MoodMax = 50},
		/* 25 */	new Wave { Positions =	new int[] {6, 3},					MoodMin =  30,	MoodMax = 50},
		/* 26 */	new Wave { Positions =	new int[] {1, 2, 4},				MoodMin =  30,	MoodMax = 50},
		/* 27 */	new Wave { Positions =	new int[] {2, 3, 5},				MoodMin =  30,	MoodMax = 50},
		/* 28 */	new Wave { Positions =	new int[] {3, 4, 6},				MoodMin =  30,	MoodMax = 50},
		/* 29 */	new Wave { Positions =	new int[] {4, 5, 7},				MoodMin =  30,	MoodMax = 50},
		/* 30 */	new Wave { Positions =	new int[] {5, 6, 0},				MoodMin =  30,	MoodMax = 50},
		/* 31 */	new Wave { Positions =	new int[] {6, 7, 1},				MoodMin =  30,	MoodMax = 50},
		/* 32 */	new Wave { Positions =	new int[] {7, 0, 2},				MoodMin =  30,	MoodMax = 50},
		/* 33 */	new Wave { Positions =	new int[] {1, 3, 4},				MoodMin =  30,	MoodMax = 50},
		/* 34 */	new Wave { Positions =	new int[] {2, 4, 5},				MoodMin =  30,	MoodMax = 50},
		/* 35 */	new Wave { Positions =	new int[] {3, 5, 6},				MoodMin =  30,	MoodMax = 50},
		/* 36 */	new Wave { Positions =	new int[] {4, 6, 7},				MoodMin =  30,	MoodMax = 50},
		/* 37 */	new Wave { Positions =	new int[] {5, 7, 0},				MoodMin =  30,	MoodMax = 50},
		/* 38 */	new Wave { Positions =	new int[] {6, 0, 1},				MoodMin =  30,	MoodMax = 50},
		/* 39 */	new Wave { Positions =	new int[] {7, 1, 2},				MoodMin =  30,	MoodMax = 50},
		/* 40 */	new Wave { Positions =	new int[] {1, 3, 5},				MoodMin =  30,	MoodMax = 50},
		/* 41 */	new Wave { Positions =	new int[] {2, 4, 6},				MoodMin =  30,	MoodMax = 50},
		/* 42 */	new Wave { Positions =	new int[] {3, 5, 7},				MoodMin =  30,	MoodMax = 50},
		/* 43 */	new Wave { Positions =	new int[] {4, 6, 0},				MoodMin =  30,	MoodMax = 50},
		/* 44 */	new Wave { Positions =	new int[] {5, 7, 1},				MoodMin =  30,	MoodMax = 50},
		/* 45 */	new Wave { Positions =	new int[] {6, 0, 2},				MoodMin =  30,	MoodMax = 50},
		/* 46 */	new Wave { Positions =	new int[] {7, 1, 3},				MoodMin =  30,	MoodMax = 50},
		/* 47 */	new Wave { Positions =	new int[] {1, 2, 5},				MoodMin =  30,	MoodMax = 50},
		/* 48 */	new Wave { Positions =	new int[] {2, 3, 6},				MoodMin =  30,	MoodMax = 50},
		/* 49 */	new Wave { Positions =	new int[] {3, 4, 7},				MoodMin =  30,	MoodMax = 50},
		/* 50 */	new Wave { Positions =	new int[] {4, 5, 0},				MoodMin =  30,	MoodMax = 50},
		/* 51 */	new Wave { Positions =	new int[] {5, 6, 1},				MoodMin =  30,	MoodMax = 50},
		/* 52 */	new Wave { Positions =	new int[] {6, 7, 2},				MoodMin =  30,	MoodMax = 50},
		/* 53 */	new Wave { Positions =	new int[] {7, 0, 3},				MoodMin =  30,	MoodMax = 50},
		/* 54 */	new Wave { Positions =	new int[] {2, 3, 6, 7}	,			MoodMin =  45,	MoodMax = 50},
	};
	
	public Wave[] HardWaves = new Wave[]
	{
		/* 0 */		new Wave { Positions =	new int[] {1, 2, 3, 4},				MoodMin =  20,	MoodMax = 50},
		/* 1 */		new Wave { Positions =	new int[] {2, 3, 4, 5},				MoodMin =  20,	MoodMax = 50},
		/* 2 */		new Wave { Positions =	new int[] {3, 4, 5, 6},				MoodMin =  20,	MoodMax = 50},
		/* 3 */		new Wave { Positions =	new int[] {5, 6, 7, 0},				MoodMin =  20,	MoodMax = 50},
		/* 4 */		new Wave { Positions =	new int[] {6, 7, 0, 1},				MoodMin =  20,	MoodMax = 50},
		/* 5 */		new Wave { Positions =	new int[] {7, 0, 1, 2},				MoodMin =  20,	MoodMax = 50},
		/* 6 */		new Wave { Positions =	new int[] {1, 3, 4, 5},				MoodMin =  20,	MoodMax = 50},
		/* 7 */		new Wave { Positions =	new int[] {1, 2, 4, 5},				MoodMin =  20,	MoodMax = 50},
		/* 8 */		new Wave { Positions =	new int[] {1, 2, 3, 5},				MoodMin =  20,	MoodMax = 50},
		/* 9 */		new Wave { Positions =	new int[] {2, 4, 5, 6},				MoodMin =  20,	MoodMax = 50},
		/* 10 */	new Wave { Positions =	new int[] {2, 3, 5, 6},				MoodMin =  20,	MoodMax = 50},
		/* 11 */	new Wave { Positions =	new int[] {2, 3, 4, 6},				MoodMin =  20,	MoodMax = 50},
		/* 12 */	new Wave { Positions =	new int[] {3, 5, 6, 7},				MoodMin =  20,	MoodMax = 50},
		/* 13 */	new Wave { Positions =	new int[] {3, 4, 6, 7},				MoodMin =  20,	MoodMax = 50},
		/* 14 */	new Wave { Positions =	new int[] {3, 4, 5, 7},				MoodMin =  20,	MoodMax = 50},
		/* 15 */	new Wave { Positions =	new int[] {4, 6, 7, 0},				MoodMin =  20,	MoodMax = 50},
		/* 16 */	new Wave { Positions =	new int[] {4, 5, 7, 0},				MoodMin =  20,	MoodMax = 50},
		/* 17 */	new Wave { Positions =	new int[] {4, 5, 6, 0},				MoodMin =  20,	MoodMax = 50},
		/* 18 */	new Wave { Positions =	new int[] {5, 7, 0, 1},				MoodMin =  20,	MoodMax = 50},
		/* 19 */	new Wave { Positions =	new int[] {5, 6, 0, 1},				MoodMin =  20,	MoodMax = 50},
		/* 20 */	new Wave { Positions =	new int[] {5, 6, 7, 1},				MoodMin =  20,	MoodMax = 50},
		/* 21 */	new Wave { Positions =	new int[] {6, 0, 1, 2},				MoodMin =  20,	MoodMax = 50},
		/* 22 */	new Wave { Positions =	new int[] {6, 7, 1, 2},				MoodMin =  20,	MoodMax = 50},
		/* 23 */	new Wave { Positions =	new int[] {6, 7, 0, 2},				MoodMin =  20,	MoodMax = 50},
		/* 24 */	new Wave { Positions =	new int[] {1, 2, 3, 4, 5},			MoodMin =  30,	MoodMax = 50},
		/* 25 */	new Wave { Positions =	new int[] {2, 3, 4, 5, 6},			MoodMin =  30,	MoodMax = 50},
		/* 26 */	new Wave { Positions =	new int[] {3, 4, 5, 6, 7},			MoodMin =  30,	MoodMax = 50},
		/* 27 */	new Wave { Positions =	new int[] {5, 6, 7, 0, 1},			MoodMin =  30,	MoodMax = 50},
		/* 28 */	new Wave { Positions =	new int[] {6, 7, 0, 1, 2},			MoodMin =  30,	MoodMax = 50},
		/* 29 */	new Wave { Positions =	new int[] {7, 0, 1, 2, 3},			MoodMin =  30,	MoodMax = 50},
		/* 30 */	new Wave { Positions =	new int[] {1, 2, 3, 4, 5, 6},		MoodMin =  40,	MoodMax = 50},
		/* 31 */	new Wave { Positions =	new int[] {2, 3, 4, 5, 6, 7},		MoodMin =  40,	MoodMax = 50},
		/* 32 */	new Wave { Positions =	new int[] {3, 4, 5, 6, 7, 0},		MoodMin =  40,	MoodMax = 50},
		/* 33 */	new Wave { Positions =	new int[] {5, 6, 7, 0, 1, 2},		MoodMin =  40,	MoodMax = 50},
		/* 34 */	new Wave { Positions =	new int[] {6, 7, 0, 1, 2, 3},		MoodMin =  40,	MoodMax = 50},
		/* 35 */	new Wave { Positions =	new int[] {7, 0, 1, 2, 3, 4},		MoodMin =  40,	MoodMax = 50},
		/* 36 */	new Wave { Positions =	new int[] {1, 2, 3, 5, 6, 7},		MoodMin =  40,	MoodMax = 50},
		/* 37 */	new Wave { Positions =	new int[] {2, 3, 4, 6, 7, 0},		MoodMin =  40,	MoodMax = 50},
		/* 38 */	new Wave { Positions =	new int[] {3, 4, 5, 7, 0, 1},		MoodMin =  40,	MoodMax = 50},
		/* 39 */	new Wave { Positions =	new int[] {1, 2, 4, 5, 7, 0},		MoodMin =  40,	MoodMax = 50},
		/* 40 */	new Wave { Positions =	new int[] {2, 3, 5, 6, 0, 1},		MoodMin =  40,	MoodMax = 50},
		/* 41 */	new Wave { Positions =	new int[] {3, 4, 6, 7, 1, 2},		MoodMin =  40,	MoodMax = 50},
		/* 42 */	new Wave { Positions =	new int[] {1, 3, 5, 6, 7},			MoodMin =  40,	MoodMax = 50},
		/* 43 */	new Wave { Positions =	new int[] {0, 2, 4, 6},				MoodMin =  40,	MoodMax = 50},
		/* 44 */	new Wave { Positions =	new int[] {1, 2, 3, 4, 6, 7},		MoodMin =  40,	MoodMax = 50},
		/* 45 */	new Wave { Positions =	new int[] {1, 2, 3, 4, 5, 6, 7, 0},	MoodMin =  40,	MoodMax = 50},
	};

	public int WaveIndex = -1;	// it's -1 so first time that we increase it in LoadNextWave, it gets to zero. ("I know, right?")
	public Wave CurrentWave;

	public MoodMeter[] Planets;

	public int MediumWaveIndexStarterNumber = 1;
	public int HardWaveIndexStarterNumber 	= 3;

	public const int MinimumAcceptableMood = 60;

	//========================================================================================================================

	void disableAllPlanets ()
	{
		for (int i = 0; i < Planets.Length; i++)
		{
			Planets[i].gameObject.SetActive(false);
		}
	}

	//========================================================================================================================

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

	//========================================================================================================================

	bool doesCurrentWaveHaveMe(int planetIndex)
	{
		for (int i = 0; i < CurrentWave.Positions.Length; i++)
		{
			if (CurrentWave.Positions[i] == planetIndex)
				return true;
		}

		return false;
	}

	public void LoadMenu()
	{
		Application.LoadLevel("MainMenuWithTutorial");
	}

	//========================================================================================================================

	void LoadNextWave()
	{
		// Giving score as number of saved trees
		if (WaveIndex > 0)
			NumOfSavedTrees += CurrentWave.Positions.Length;

		// advancing to next wave
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

//		Debug.Log(die);

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

		// Selecting a Medium wave
		else if (die <= MediumWaveChance)
		{
			int randomWave = Random.Range(0, MediumWaves.Length);
			CurrentWave = MediumWaves[randomWave];
			
			//			Debug.Log("CurrentWave MediumWaves#: " + randomWave);
			NumOfMediumWavesCreated = NumOfMediumWavesCreated + 1;
		}

		// Selecting an Easy wave
		else
		{
			int randomWave = Random.Range(0, EasyWaves.Length);
			CurrentWave = EasyWaves[Random.Range(0, EasyWaves.Length)];
			
			//			Debug.Log("CurrentWave EasyWaves#: " + CurrentWave);
			NumOfEasyWavesCreated = NumOfEasyWavesCreated + 1;
		}

		// Applying new wave

		List<int> TreesID = new List<int>();

		for (int i = 0; i < 7; i++)
			TreesID.Add(i);



		for (int i = 0; i < Planets.Length; i++)
		{
			if ( doesCurrentWaveHaveMe( i ))
			{
				Planets[i].CurrentMood = Random.Range(CurrentWave.MoodMin, CurrentWave.MoodMax);
				Planets[i].ResetMoodMultiplier();
				Planets[i].gameObject.SetActive(true);


				int id = Random.Range(0, TreesID.Count);
				TreesID.Remove(id);
				Planets[i].TreeID = id;
			}
			else
			    Planets[i].gameObject.SetActive(false);
		}

	}

	//========================================================================================================================

	bool checkIfGameIsOver ()
	{
		int deadTrees = 0;

		for (int i = 0; i < Planets.Length; i++)
		{
			if (Planets[i].CurrentMood <= 0)
				deadTrees = deadTrees + 1;
		}

		if (deadTrees >= MaxNumOfAcceptableDeadTrees)
			return true;
		else
			return false;
	}

	//========================================================================================================================

	void DisplayGameOver ()
	{
		// Delete Sun
		GameObject.FindGameObjectWithTag("Sun").SetActive(false);

		// Delete Trees
		for (int i = 0; i < Planets.Length; i++)
		{
			Planets[i].gameObject.SetActive(false);
		}

		// Display game over canvas summary
		GameOverCanvase.gameObject.SetActive(true);
		SavedTreeText.text = ": " + NumOfSavedTrees.ToString() + " Saved.";

	}

	//========================================================================================================================

	void Awake()
	{
		// Singleton
		instance = this;
	}

	//========================================================================================================================

	void Start ()
	{
		GameOverCanvase.gameObject.SetActive(false);
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

	//========================================================================================================================

	void Update ()
	{
		if (!isGameOver)
		{
			if (isCurrentWaveClear())
			{
				LoadNextWave();
			}
			else if (checkIfGameIsOver())
			{
				isGameOver = true;
				DisplayGameOver();
			}
		}
	}
}
