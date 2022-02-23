using UnityEngine;

public abstract class Setting<T>
{
	public delegate void SettingChangeHandler(T newValue);
	
	protected T m_defaultValue;
	protected string m_name;
	public event SettingChangeHandler onChange;
	public abstract T Value {get; set;}

	public Setting(string name, T defaultValue)
	{
		m_defaultValue = defaultValue;
		m_name = name;
	}

	protected void InvokeChange(T newValue)
	{
		onChange?.Invoke(newValue);
	}
}

internal class FloatSetting : Setting<float>
{
	public FloatSetting(string name, float defaultValue) : base(name, defaultValue) {}
	public override float Value
	{
		get
		{
			return PlayerPrefs.GetFloat(m_name, m_defaultValue);
		}
		set
		{
			PlayerPrefs.SetFloat(m_name, value);
			InvokeChange(value);
		}
	}
}

internal class IntSetting : Setting<int>
{
	public IntSetting(string name, int defaultValue) : base(name, defaultValue) {}
	public override int Value
	{
		get
		{
			return PlayerPrefs.GetInt(m_name, m_defaultValue);
		}
		set
		{
			PlayerPrefs.SetInt(m_name, value);
			InvokeChange(value);
		}
	}
}

internal class StringSetting : Setting<string>
{
	public StringSetting(string name, string defaultValue) : base(name, defaultValue) {}
	public override string Value
	{
		get
		{
			return PlayerPrefs.GetString(m_name, m_defaultValue);
		}
		set
		{
			PlayerPrefs.SetString(m_name, value);
			InvokeChange(value);
		}
	}
}