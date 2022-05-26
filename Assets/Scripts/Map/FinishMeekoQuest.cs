using UnityEngine;

public class FinishMeekoQuest : MonoBehaviour
{
    public void Finish() => CommandHandlers.FinishQuest("Meeko's Quest");
}
