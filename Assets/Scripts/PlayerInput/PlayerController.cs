using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInput;

    private Rigidbody2D rb;

    [SerializeField] private float speed = 10f;
    //call Animator
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = playerInput.Movement.Move.ReadValue<Vector2>();
        rb.velocity = moveInput * speed;

        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        //north/up == 1
        if (vertical > 0)
        {
            animator.SetInteger("Direction", 1);
            Debug.Log("Direction 1");
        }
        //south/down == 3
        else if (vertical < 0)
        {
            animator.SetInteger("Direction", 3);
            Debug.Log("Direction 3");
        }
          //east/right == 2
        else if (horizontal > 0)
        {
            animator.SetInteger("Direction", 2);
            Debug.Log("Direction 2");
        }
      
        //west/left ==4
        else if (horizontal < 0)
        {
            animator.SetInteger("Direction", 4);
            Debug.Log("Direction 4");
        }
        //else idle == 0
        else
        {
            animator.SetInteger("Direction", 0);
            Debug.Log("Direction 0");
        }
    }
}

