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
		public string questName => _questName;

		[Tooltip("The description of this quest.")]
		[TextArea(3,10)]
		[SerializeField] private string _description;
		public string description => _description;

		[Tooltip("Whether this quest is hidden in the quest log.")]
		[SerializeField] private bool _hidden = false;
		public bool hidden => _hidden;

		[Tooltip("The condition to complete this quest.")]
		[SerializeField] private Condition _condition;
		public Condition condition => _condition;

	[Header("Quest Chain")]
		[Tooltip("Subsequent quests and what conditions must be fulfilled to assign them after finishing this quest.")]
		[SerializeField] private ConditionalQuest[] _nextQuests;
		public ConditionalQuest[] nextQuests => _nextQuests;

	public bool IsComplete() => ConditionChecker.Check(condition);

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

	public void Subscribe() => ConditionChecker.Subscribe(condition, Finish);
}