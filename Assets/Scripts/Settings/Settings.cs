using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{

    public delegate void MusicVolumeChangeHandler(float volume);
	public static event MusicVolumeChangeHandler onMusicVolumeChanged;
    public static float MusicVolume
    {
    	get
    	{
    		return PlayerPrefs.GetFloat("Music Volume", 1.0f);
    	}

    	set
    	{
    		PlayerPrefs.SetFloat("Music Volume", value);
    		onMusicVolumeChanged?.Invoke(value);
    	}
    }

    public delegate void SfxVolumeChangeHandler(float volume);
    public static event SfxVolumeChangeHandler onSfxVolumeChanged;
    public static float SfxVolume
    {
    	get
    	{
    		return PlayerPrefs.GetFloat("SFX Volume", 1.0f);
    	}

    	set
    	{
    		PlayerPrefs.SetFloat("SFX Volume", value);
    		onSfxVolumeChanged?.Invoke(value);
    	}
    }

    public delegate void TextDelayChangeHandler(float delay);
    public static event TextDelayChangeHandler onTextDelayChanged;
    public static float TextDelay
    {
    	get
    	{
    		return PlayerPrefs.GetFloat("Text Delay", 0.05f);
    	}

    	set
    	{
    		PlayerPrefs.SetFloat("Text Delay", value);
    		onTextDelayChanged?.Invoke(value);
    	}
    }
}
