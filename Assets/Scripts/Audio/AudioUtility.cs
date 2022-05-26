using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class AudioUtility
{

	public static float VolumeToDecibels(float volume)
	{
		return Mathf.Log10(Mathf.Clamp(volume, 0.00001f, 1)) * 20;
	}

	private static float DecibelsToVolume(float decibels)
	{
		return Mathf.Pow(10, decibels / 20);
	}

	public static IEnumerator AudioMixerChangeVolume(AudioMixer audioMixer, string volumeParameter, float duration, float targetVolume)
	{
		float currentTime = 0;
		float currentDecibels;
		audioMixer.GetFloat(volumeParameter, out currentDecibels);
		float targetDecibels = VolumeToDecibels(targetVolume);

		while (currentTime < duration)
		{
			currentTime += Time.deltaTime;
			audioMixer.SetFloat(volumeParameter, Mathf.Lerp(currentDecibels, targetDecibels, currentTime / duration));

			yield return null;
		}

		audioMixer.SetFloat(volumeParameter, targetDecibels);
		yield break;
	}

	public static IEnumerator AudioSourceChangeVolume(AudioSource audioSource, float duration, float targetVolume)
	{
		float currentTime = 0;
		float currentVolume = audioSource.volume;

		while (currentTime < duration)
		{
			currentTime += Time.deltaTime;
			audioSource.volume = Mathf.Lerp(currentVolume, targetVolume, currentTime / duration);

			yield return null;
		}

		audioSource.volume = targetVolume;
		yield break;
	}

	public static IEnumerator PlayAndFadeInAudioSource(AudioSource audioSource, float duration, float targetVolume)
	{
		audioSource.volume = 0;
		float currentTime = 0;
		audioSource.Play();
		
		while (currentTime < duration)
		{
			currentTime += Time.deltaTime;
			audioSource.volume = Mathf.Lerp(0, targetVolume, currentTime / duration);

			yield return null;
		}

		audioSource.volume = targetVolume;
		yield break;
	}	
	
	public static IEnumerator FadeInAudioSource(AudioSource audioSource, float duration, float targetVolume)
	{
		audioSource.volume = 0;
		float currentTime = 0;

		while (currentTime < duration)
		{
			currentTime += Time.deltaTime;
			audioSource.volume = Mathf.Lerp(0, targetVolume, currentTime / duration);

			yield return null;
		}

		audioSource.volume = targetVolume;
		yield break;
	}

	public static IEnumerator FadeOutAudioSource(AudioSource audioSource, float duration)
	{
		float currentTime = 0;
		float startVolume = audioSource.volume;

		while (currentTime < duration)
		{
			currentTime += Time.deltaTime;
			audioSource.volume = Mathf.Lerp(startVolume, 0, currentTime / duration);

			yield return null;
		}

		audioSource.volume = 0;
		yield break;
	}

	public static IEnumerator FadeOutAndStopAudioSource(AudioSource audioSource, float duration)
	{
		float currentTime = 0;
		float startVolume = audioSource.volume;

		while (currentTime < duration)
		{
			currentTime += Time.deltaTime;
			audioSource.volume = Mathf.Lerp(startVolume, 0, currentTime / duration);

			yield return null;
		}

		audioSource.volume = 0;
		audioSource.Stop();
		yield break;
	}

	public static IEnumerator CrossfadeAudioSources(AudioSource audioSourceIn, float targetVolumeIn, AudioSource audioSourceOut, float duration)
	{
		float currentTime = 0;
		float startVolumeOut = audioSourceOut.volume;
		audioSourceIn.volume = 0;

		while (currentTime < duration)
		{
			currentTime += Time.deltaTime;
			audioSourceOut.volume = Mathf.Lerp(startVolumeOut, 0, currentTime / duration);
			audioSourceIn.volume = Mathf.Lerp(0, targetVolumeIn, currentTime / duration);

			yield return null;
		}
		yield break;
	}
	
	public static IEnumerator CrossfadeAudioSourcesWithPlayAndStop(AudioSource audioSourceIn, float targetVolumeIn, AudioSource audioSourceOut, float duration)
	{
		float currentTime = 0;
		float startVolumeOut = audioSourceOut.volume;
		audioSourceIn.volume = 0;
		audioSourceIn.Play();

		while (currentTime < duration)
		{
			currentTime += Time.deltaTime;
			audioSourceOut.volume = Mathf.Lerp(startVolumeOut, 0, currentTime / duration);
			audioSourceIn.volume = Mathf.Lerp(0, targetVolumeIn, currentTime / duration);

			yield return null;
		}
		audioSourceOut.Stop();
		yield break;
	}

	public static void PlayOneShotWithRandomization(AudioSource audioSource, AudioClip audioClip,
		float minVolume, float maxVolume, float minPitch, float maxPitch)
    {
		audioSource.pitch = Random.Range(minPitch, maxPitch);
		audioSource.PlayOneShot(audioClip, Random.Range(minVolume, maxVolume));
    }

	public static void PlayOneShotWithRandomization(AudioSource audioSource, AudioClip[] audioClipArray,
	float minVolume, float maxVolume, float minPitch, float maxPitch)
	{
		audioSource.pitch = Random.Range(minPitch, maxPitch);
		audioSource.PlayOneShot(audioClipArray[Random.Range(0, audioClipArray.Length)], Random.Range(minVolume, maxVolume));
	}

	public static void PlayOneShotWithRandomization(AudioSource audioSource, AudioClip[] audioClipArray,
float minVolume, float maxVolume, float minPitch, float maxPitch, int index)
	{
		audioSource.pitch = Random.Range(minPitch, maxPitch);
		audioSource.PlayOneShot(audioClipArray[index], Random.Range(minVolume, maxVolume));
	}
}
