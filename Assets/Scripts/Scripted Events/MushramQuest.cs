using UnityEngine;

public class MushramQuest : MonoBehaviour
{
    public void Complete()
    {
        CommandHandlers.FinishQuest("Mushram's Quest");
        Yarn.Unity.VariableStorage.instance?.SetValue("$mushramQuestFinished", true);
    }
}
