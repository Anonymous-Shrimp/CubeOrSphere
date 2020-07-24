using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
	public float musicVolume = 1;

	Sound sh;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;


	void Awake()
	{

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = s.mixerGroup;
		}
	}

    private void Start()
    {
		sh = Array.Find(sounds, item => item.name == "Menu");
		Play("Menu");
		Play("Slide");
	}
    private void Update()
    {
		//print(musicVolume);
		sh.source.volume = musicVolume;
    }


    public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume;
		s.source.pitch = s.pitch;

		s.source.Play();
	}
	public void Stop(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume;
		s.source.pitch = s.pitch;

		s.source.Stop();
	}
	public void setVolume (string sound, float volume)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		s.volume = volume;
		s.source.volume = s.volume;
		s.source.pitch = s.pitch;
	}
	

}
