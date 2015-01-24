using UnityEngine;
using System.Collections;

public class MusicSingleton : MonoBehaviour
{
	AudioSource SoundSource;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		SoundSource = gameObject.GetComponent<AudioSource>();
		//SoundSource.playOnAwake = false;
		//SoundSource.rolloffMode = AudioRolloffMode.Logarithmic;
		//SoundSource.loop = true;
	}
		
	void Start()
	{
		SoundSource.Play();
	} 
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
