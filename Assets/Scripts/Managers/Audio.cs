using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Audio
{
	public string name; // Name

	public AudioClip clip; // Audio clip

	[Range(0f, 1f)]
	public float volume = .75f; // Volume variable
	[Range(0f, 1f)]
	public float volumeVariance = .1f; // Volume variance variable

	[Range(.1f, 3f)]
	public float pitch = 1f; // Pitch variable
	[Range(0f, 1f)]
	public float pitchVariance = .1f; // Pitch variance variable

	public bool loop = false; // Is the sound looping?

	public AudioMixerGroup mixerGroup; // Mixer group

	[HideInInspector]
	public AudioSource source; // The audiosource

}
