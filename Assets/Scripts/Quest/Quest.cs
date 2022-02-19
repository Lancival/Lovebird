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
		[SerializeField] private string m_questName;
		public string questName
		{
			get {return m_questName;}
			private set {return;}
		}

		[Tooltip("The description of this quest.")]
		[SerializeField] private string m_description;
		public string description
		{
			get {return m_description;}
			private set {return;}
		}

		[Tooltip("The condition to complete this quest.")]
		[SerializeField] private Condition m_condition;
		public Condition condition
		{
			get {return m_condition;}
			private set {return;}
		}

	[Header("Quest Chain")]
		[Tooltip("Subsequent quests and what conditions must be fulfilled to assign them after finishing this quest.")]
		[SerializeField] private ConditionalQuest[] m_nextQuests;
		public ConditionalQuest[] nextQuests
		{
			get {return m_nextQuests;}
			private set {return;}
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