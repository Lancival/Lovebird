using UnityEngine;

public class UpdateTextSpeed : MonoBehaviour
{
    public void UpdateDelay(float newValue) => Settings.TextDelay.Value = newValue;
}
