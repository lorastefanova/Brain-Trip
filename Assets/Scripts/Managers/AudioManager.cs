using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance; // Instance of this script

	public AudioMixerGroup mixerGroup; // Mixer group

	public Audio[] sounds; // Array of Audio clips

	void Awake()
	{
		if (instance != null) // If there is an instance already - destroy it
		{
			Destroy(gameObject);
		}
		else // If not
		{
			instance = this; // This is the instance
			DontDestroyOnLoad(gameObject); // Don't destroy it when loading a new scene
		}

		foreach (Audio s in sounds)  // For each sound
		{
			s.source = gameObject.AddComponent<AudioSource>(); 
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

    void Start()
    {
		Play("main menu"); // Play main menu sound

	}

	// Function to play a sound
    public void Play(string sound)
	{
		Audio s = Array.Find(sounds, item => item.name == sound); // Find sounds

		if (s == null) // If sound is not found
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f)); // Set the volume's random variance
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f)); // Set the pitch's random variance

		s.source.Play(); // Play the sound
	}

}	