using System.Collections;
using System.Collections.Generic;
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
            Interact();
        }
    }

    public virtual void Interact()
    {
        Debug.Log(string.Format("Interacted with {0}.", this.name));
    }
}
