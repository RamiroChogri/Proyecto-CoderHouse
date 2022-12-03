using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBackgroundMusic : MonoBehaviour
{
    public AudioSource MusicSource;
    public static SingletonBackgroundMusic Instance = null;
    private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
    }
    public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
