using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]

public class BirdController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement = new Vector2();
    [SerializeField] private float speed = 5.0f;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    public void OnMove(InputAction.CallbackContext context) => movement = context.ReadValue<Vector2>();

    void FixedUpdate() => rb.velocity = movement * speed;
}
