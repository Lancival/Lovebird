using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class Interactable : MonoBehaviour
{
    [SerializeField] new private Collider2D collider;

    void Awake() => collider = GetComponent<Collider2D>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.interactables.Add(this);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.interactables.Remove(this);
            }
        }
    }

    public virtual void Interact() => Debug.Log(string.Format("Interacted with {0}.", this.name));
}
