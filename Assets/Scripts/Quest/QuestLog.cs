using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[DisallowMultipleComponent]
[RequireComponent(typeof(FadeCanvasGroup))]

public class QuestLog : MonoBehaviour
{

	private static QuestLog m_instance = null;
	public static QuestLog instance
	{
		get {return m_instance;}
		private set {m_instance = value;}
	}

	[SerializeField] private TextMeshProUGUI questText;
	private FadeCanvasGroup fader;
	private bool visible = false;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		}
		instance = this;
		fader = GetComponent<FadeCanvasGroup>();
	}

	void OnDestroy()
	{
		instance = null;
	}

	private void UpdateQuestText()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (QuestManager.quests.Count > 0)
		{
			foreach (Quest quest in QuestManager.quests)
			{
				stringBuilder.Append(quest.description);
				stringBuilder.Append('\n');
			}
			stringBuilder.Length = stringBuilder.Length - 1;
		}
		else
		{
			stringBuilder.Append("You have no uncompleted quests!");
		}
		questText.text = stringBuilder.ToString();
	}

	public void ShowQuestLog(float duration = 1f)
	{
		if (!visible)
		{
			visible = true;
			UpdateQuestText();
			fader.FadeIn(duration);
		}
	}

	public void HideQuestLog(float duration = 1f)
	{
		if (visible)
		{
			visible = false;
			fader.FadeOutInactive(duration);
		}
	}
}
