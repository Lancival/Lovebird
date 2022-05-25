using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class BirdController : MonoBehaviour
{
    // Components
    protected Rigidbody2D rigidBody;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;

    // Movement Variables
    protected Vector2 movement = new Vector2();
    [SerializeField] protected float speed = 5.0f;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public virtual void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        animator.SetBool("isMoving", movement.magnitude != 0);

        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void FixedUpdate() => rigidBody.velocity = movement * speed;
}
