using UnityEngine;
using System.Collections;

public class SoundManager : MonoSingleton<SoundManager> {

	public AudioSource audioSource;

	public AudioClip[] listAudio;

	public void PlaySoundWithName(string name)
	{
		AudioClip audioClip = ResourceLoader.GetAudioClip (name);
		audioSource.PlayOneShot (audioClip);
		//audioClip.
		//audioSource.Play (audioClip);
	}

	public void PlaySoundWithType(AudioType type)
	{
		int index = (int)type;
		AudioClip audioClip = listAudio [index];
		audioSource.PlayOneShot (audioClip);
	}
}

public enum AudioType
{
	NONE = 0,
	BACKGROND = 1,
	WORLD = 2,
	LOST_CHAR = 3,
	WIN_CHAR = 4,
	WIN_WORD = 5,
	TOUCH = 6
}
