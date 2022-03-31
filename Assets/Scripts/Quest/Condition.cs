using System;
using UnityEngine;

[Serializable]
public class Condition
{
	[Tooltip("Type of condition.")]
	[SerializeField] private ConditionType _type;
	public ConditionType type => _type;

	[Tooltip("Condition that must be fulfilled.")]
	[SerializeField] private string _variable;
	public string variable => _variable;

	[Tooltip("Comparison type.")]
	[SerializeField] private Comparison _comparison;
	public Comparison comparison => _comparison;

	[Tooltip("Target value to compare to.")]
	[SerializeField] private int _target;
	public int target => _target;
}
