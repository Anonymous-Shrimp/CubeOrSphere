using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class AudioManagerMenu : MonoBehaviour
{


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
		Play("Menu");
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}
	public void FadeMusicOut()
	{
		StartCoroutine(FadeOut());
	}
	IEnumerator FadeOut()
	{
		Sound s = Array.Find(sounds, item => item.name == "menu");
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			yield return null;
		}

		for (float i = s.source.volume; i <= 0; i -= 1)
		{
			s.source.volume = i;
		}

		yield return null;
	}
	IEnumerator FadeIn()
	{
		Sound s = Array.Find(sounds, item => item.name == "menu");
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			yield return null;
		}

		float volume = s.source.volume;

		for (float i = 0; i >= volume; i -= 1)
		{
			s.source.volume = i;
		}

		yield return null;
	}

}
