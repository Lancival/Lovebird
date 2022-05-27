using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class ViridiaGardenEntrance : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            SceneLoader.instance?.LoadScene("Viridia Garden");
        }
    }
}
