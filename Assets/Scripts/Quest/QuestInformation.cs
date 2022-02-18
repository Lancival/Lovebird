using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quests", order = 1)]

public class QuestInformation : ScriptableObject
{
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

	[Header("Quest Conditions")]
		[Tooltip("Type of condition must be fulfilled to finish this quest.")]
		[SerializeField] private ConditionType m_type;
		public ConditionType type
		{
			get {return m_type;}
			private set {return;}
		}

		[Tooltip("Condition that must be fulfilled to finish this quest.")]
		[SerializeField] private string m_condition;
		public string condition
		{
			get {return m_condition;}
			private set {return;}
		}

		[Tooltip("Number of steps or amount of the condition required to complete this quest.")]
		[SerializeField] private int m_maxProgress;
		public int maxProgress
		{
			get {return m_maxProgress;}
			private set {return;}
		}

		#nullable enable
		[Tooltip("Next quest in this quest chain, if there is one.")]
		[SerializeField] private QuestInformation? m_nextQuest;
		public QuestInformation? nextQuest
		{
			get {return m_nextQuest;}
			private set {return;}
		}
		#nullable disable

}