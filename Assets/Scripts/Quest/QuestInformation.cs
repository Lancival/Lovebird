using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quests", order = 1)]

public class QuestInformation : ScriptableObject
{

	[Tooltip("Number of steps required to complete this quest.")]
	[SerializeField] private int m_maxProgress;
	public int maxProgress
	{
		get {return m_maxProgress;}
		private set{return;}
	}

	[Tooltip("The description of this quest.")]
	[SerializeField] private string m_description;
	public string description
	{
		get {return m_description;}
		private set {return;}
	}

	[Tooltip("The name of this quest.")]
	[SerializeField] private string m_name;
	new public string name
	{
		get {return m_name;}
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
