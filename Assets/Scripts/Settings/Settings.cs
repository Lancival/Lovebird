using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Settings
{

	public static UnityEvent<float> OnMusicVolumeChanged = new UnityEvent<float>();
    public static float MusicVolume
    {
    	get
    	{
    		return PlayerPrefs.GetFloat("Music Volume", 1.0f);
    	}

    	set
    	{
    		PlayerPrefs.SetFloat("Music Volume", value);
    		OnMusicVolumeChanged.Invoke(value);
    	}
    }

    public static UnityEvent<float> OnSfxVolumeChanged = new UnityEvent<float>();
    public static float SfxVolume
    {
    	get
    	{
    		return PlayerPrefs.GetFloat("SFX Volume", 1.0f);
    	}

    	set
    	{
    		PlayerPrefs.SetFloat("SFX Volume", value);
    		OnSfxVolumeChanged.Invoke(value);
    	}
    }

    public static UnityEvent<float> OnTextDelayChanged = new UnityEvent<float>();
    public static float TextDelay
    {
    	get
    	{
    		return PlayerPrefs.GetFloat("Text Delay", 0.05f);
    	}

    	set
    	{
    		PlayerPrefs.SetFloat("Text Delay", value);
    		OnTextDelayChanged.Invoke(value);
    	}
    }
}
