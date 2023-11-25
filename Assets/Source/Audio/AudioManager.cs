using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;

	[SerializeField] private Sound[] sounds;

	private void Awake ()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		} 
		else
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound sond in sounds)
		{
			sond.source = gameObject.AddComponent<AudioSource>();
			sond.source.clip = sond.clip;
			sond.source.volume = sond.volume;
			sond.source.pitch = sond.pitch;
			sond.source.loop = sond.loop;
		}
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Play();
	}

	public void Stop(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Stop();
	}
}
