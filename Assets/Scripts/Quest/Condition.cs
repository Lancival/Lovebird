using System;
using UnityEngine;

[Serializable]
public class Condition
{
	[Tooltip("Type of condition.")]
	[SerializeField] private ConditionType m_type;
	public ConditionType type
	{
		get {return m_type;}
		private set {return;}
	}

	[Tooltip("Condition that must be fulfilled.")]
	[SerializeField] private string m_variable;
	public string variable
	{
		get {return m_variable;}
		private set {return;}
	}

	[Tooltip("Comparison type.")]
	[SerializeField] private Comparison m_comparison;
	public Comparison comparison
	{
		get {return m_comparison;}
		private set {return;}
	}

	[Tooltip("Target value to compare to.")]
	[SerializeField] private int m_target;
	public int target
	{
		get {return m_target;}
		private set {return;}
	}
}
