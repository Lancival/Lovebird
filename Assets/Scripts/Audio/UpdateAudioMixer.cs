using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[DisallowMultipleComponent]

public class UpdateAudioMixer : MonoBehaviour
{

	[SerializeField] private AudioMixer mixer;
    private static UpdateAudioMixer instance = null;

    void Awake()
    {
        if (mixer == null)
        {
        	Debug.LogWarning("UpdateAudioMixer missing reference to AudioMixer.");
            Destroy(this);
        }
        else if (instance != null)
        {
            Debug.LogWarning("Another instance of UpdateAudioMixer already exists.");
            Destroy(this);
        }
        else
        {
            Settings.MasterVolume.onChange += UpdateMasterVolume;
            Settings.MusicVolume.onChange += UpdateMusicVolume;
            Settings.SfxVolume.onChange += UpdateSfxVolume;
        }
    }

    void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
            Settings.MasterVolume.onChange -= UpdateMasterVolume;
            Settings.MusicVolume.onChange -= UpdateMusicVolume;
            Settings.SfxVolume.onChange -= UpdateSfxVolume;
        }
    }

    private void UpdateMasterVolume(float volume) => mixer.SetFloat("Master Volume", volume);
    private void UpdateMusicVolume(float volume) => mixer.SetFloat("Music Volume", volume);
    private void UpdateSfxVolume(float volume) => mixer.SetFloat("Sfx Volume", volume);
}
