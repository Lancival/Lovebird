using System;
using System.Collections;
using UnityEngine;
using Yarn.Unity;
using TMPro;

public class LineView : DialogueViewBase
{
    [Header("Text Fields")]
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI dialogueText;

    public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
    {
        nameText.gameObject.SetActive(true);
        dialogueText.gameObject.SetActive(true);

        nameText.text = dialogueLine.CharacterName;
        dialogueText.text = dialogueLine.TextWithoutCharacterName.Text;

        onDialogueLineFinished?.Invoke();
    }

    public override void RunOptions(DialogueOption[] dialogueOptions, Action<int> onOptionSelected)
    {
        nameText.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);
    }

    protected static IEnumerator Typewriter(TextMeshProUGUI text, Action onTypewriterFinished)
    {
        text.maxVisibleCharacters = 0;
        int characterCount = text.text.Length;
        yield break;
    }
}
