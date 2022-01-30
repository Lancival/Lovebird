using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[DisallowMultipleComponent]

public class UpdateAudioMixer : MonoBehaviour
{

	[SerializeField] private AudioMixer mixer;

    void Awake()
    {
        if (mixer == null)
        {
        	Debug.LogError("UpdateAudioMixer missing reference to AudioMixer.");
        	Destroy(this);
        }

        Settings.OnMusicVolumeChanged.AddListener(UpdateMusicVolume);
        Settings.OnSfxVolumeChanged.AddListener(UpdateSfxVolume);
    }

    private void UpdateMusicVolume(float volume)
    {
    	mixer.SetFloat("Music Volume", volume);
    }

    private void UpdateSfxVolume(float volume)
    {
    	mixer.SetFloat("Sfx Volume", volume);
    }

    void OnDestroy()
    {
    	Settings.OnMusicVolumeChanged.RemoveListener(UpdateMusicVolume);
    	Settings.OnSfxVolumeChanged.RemoveListener(UpdateSfxVolume);
    }
}
