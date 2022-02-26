using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quests", order = 1)]
public class Quest : ScriptableObject
{

	[System.Serializable]
	public struct ConditionalQuest
	{
		public Condition condition;
		public Quest information;
	}

	[Header("Quest Description")]
		[Tooltip("The name of this quest.")]
		[SerializeField] private string _questName;
		public string questName
		{
			get {return _questName;}
		}

		[Tooltip("The description of this quest.")]
		[SerializeField] private string _description;
		public string description
		{
			get {return _description;}
		}

		[Tooltip("The condition to complete this quest.")]
		[SerializeField] private Condition _condition;
		public Condition condition
		{
			get {return _condition;}
		}

	[Header("Quest Chain")]
		[Tooltip("Subsequent quests and what conditions must be fulfilled to assign them after finishing this quest.")]
		[SerializeField] private ConditionalQuest[] _nextQuests;
		public ConditionalQuest[] nextQuests
		{
			get {return _nextQuests;}
		}

	public bool IsComplete()
	{
		return ConditionChecker.Check(condition);
	}

	public void Finish()
	{
		foreach (ConditionalQuest nextQuest in nextQuests)
		{
			if (ConditionChecker.Check(nextQuest.condition))
			{
				QuestManager.Add(nextQuest.information);
			}
		}
		QuestManager.Remove(this);
	}

	public void Subscribe()
	{
		ConditionChecker.Subscribe(condition, Finish);
	}
}