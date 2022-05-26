using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

//This script is for background and sfx sliders

public class sfxManager : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private static readonly string MasterPref = "MasterPref";
    
    public Slider backgroundSlider, soundEffectsSlider, masterSlider;
    private float backgroundFloat, soundEffectsFloat, masterFloat;
    
    [SerializeField] private AudioMixer mixer;

    void Start()
    {
        if(!PlayerPrefs.HasKey(MasterPref))
        {
            backgroundFloat = 0.75f;
            soundEffectsFloat = 0.75f;
            masterFloat = 0.075f;
            
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);
            PlayerPrefs.SetFloat(MasterPref, masterFloat);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            masterFloat = PlayerPrefs.GetFloat(MasterPref);
        }

        backgroundSlider.value = backgroundFloat;
        soundEffectsSlider.value = soundEffectsFloat;
        masterSlider.value = masterFloat;
    }
    
    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value);
        PlayerPrefs.SetFloat(MasterPref, masterSlider.value);
    }

    public void UpdateSound()
    {
        SaveSoundSettings();
        mixer.SetFloat("MusicVolume", AudioUtility.VolumeToDecibels(backgroundSlider.value));
        mixer.SetFloat("SFXVolume", AudioUtility.VolumeToDecibels(soundEffectsSlider.value));
        mixer.SetFloat("MasterVolume", AudioUtility.VolumeToDecibels(masterSlider.value));
    }

}
