using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerController : BirdController
{
    public override void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        animator.SetBool("isMoving", movement.magnitude != 0);

        if (movement.magnitude != 0)
        {
            if (Mathf.Abs(movement.x) < Mathf.Abs(movement.y))
            {
                animator.SetBool("movingHorizontal", false);
                animator.SetBool("movingUp", movement.y > 0);
            }
            else
            {
                animator.SetBool("movingHorizontal", true);
                spriteRenderer.flipX = (movement.x < 0);
            }
        }
    }
}
