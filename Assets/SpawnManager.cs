using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
	// TODO: Tutorial wave

	public Wave[] StartWave = new Wave[]
	{
		/* 0 */	new Wave { Positions = {1}, MoodMin =  50,	MoodMax = 90},
	};

	public int WaveIndex = 0;

	//TODO:	

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
