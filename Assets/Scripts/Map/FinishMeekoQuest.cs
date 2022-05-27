using UnityEngine;
using Yarn.Unity;

public class FinishMeekoQuest : MonoBehaviour
{
    public void Finish()
    {
        CommandHandlers.FinishQuest("Meeko's Quest");
        VariableStorage.instance?.SetValue("$meekoQuestFinished", true);
    }
}
