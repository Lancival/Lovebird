using UnityEngine;

public abstract class Setting<T>
{
	public delegate void SettingChangeHandler(T newValue);
	
	protected T _defaultValue;
	protected string _name;
	public event SettingChangeHandler onChange;
	public abstract T Value {get; set;}

	public Setting(string name, T defaultValue)
	{
		_defaultValue = defaultValue;
		_name = name;
	}

	protected void InvokeChange(T newValue) => onChange?.Invoke(newValue);
}

internal class FloatSetting : Setting<float>
{
	public FloatSetting(string name, float defaultValue) : base(name, defaultValue) {}
	public override float Value
	{
		get => PlayerPrefs.GetFloat(_name, _defaultValue);
		set
		{
			PlayerPrefs.SetFloat(_name, value);
			InvokeChange(value);
		}
	}
}

internal class IntSetting : Setting<int>
{
	public IntSetting(string name, int defaultValue) : base(name, defaultValue) {}
	public override int Value
	{
		get => PlayerPrefs.GetInt(_name, _defaultValue);
		set
		{
			PlayerPrefs.SetInt(_name, value);
			InvokeChange(value);
		}
	}
}

internal class StringSetting : Setting<string>
{
	public StringSetting(string name, string defaultValue) : base(name, defaultValue) {}
	public override string Value
	{
		get => PlayerPrefs.GetString(_name, _defaultValue);
		set
		{
			PlayerPrefs.SetString(_name, value);
			InvokeChange(value);
		}
	}
}