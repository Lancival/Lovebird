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

	// Singleton instance
	private static QuestLog _instance = null;
	public static QuestLog instance => _instance;

	// Components
	[SerializeField] private GameObject questEntryPrefab;
	[SerializeField] private Transform content;
	private FadeCanvasGroup fader;

	private List<GameObject> entries;
	private GameObject noQuests;

	// Current visibility state of this QuestLog instance
	private bool _visible = false;
	public bool visible => _visible;

	// Initialize instance on awake
	void Awake()
	{
		if (_instance != null)
		{
			Destroy(gameObject);
			return;
		}
		_instance = this;
		fader = GetComponent<FadeCanvasGroup>();

		entries = new List<GameObject>();
		noQuests = content.GetChild(0).gameObject;
	}

	// Release singleton instance when destroyed
	void OnDestroy()
	{
		if (_instance == this)
		{
			_instance = null;
		}
	}

	// Update the quest log's text based on the current list of quests in QuestManager, if currently visible
	public void UpdateQuestText()
	{
		if (!_visible)
		{
			return; // Update unnecessary if quest log isn't visible
		}

		int usedEntries = 0;
		foreach (Quest quest in QuestManager.quests)
		{
			if (!quest.hidden)
			{
				if (entries.Count <= usedEntries)
				{
					entries.Add(Instantiate(questEntryPrefab, content));
				}
				entries[usedEntries].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = quest.description;
			}
		}

		// No active, not hidden quests available
		noQuests.SetActive(usedEntries == 0);

		// Hide unused entries
		for (; usedEntries < entries.Count; usedEntries++)
		{
			entries[usedEntries].SetActive(false);
		}
	}

	// Show the quest log if it's currently hidden, and update the text
	public void ShowQuestLog(float duration = 1f)
	{
		if (!_visible)
		{
			_visible = true;
			UpdateQuestText();
			fader.FadeIn(duration);
		}
	}

	// Hide the quest log if it's currently visible, and deactivate the gameObject
	public void HideQuestLog(float duration = 1f)
	{
		if (_visible)
		{
			_visible = false;
			fader.FadeOutInactive(duration);
		}
	}
}
