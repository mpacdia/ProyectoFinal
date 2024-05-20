using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    PlayerInput playerInput;

    Animator animatorController;

    public Vector2 read;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        animatorController = GetComponent<Animator>();
    }
    public void toMovePlayer(InputAction.CallbackContext context)
    {
        Vector2 readVector = context.action.ReadValue<Vector2>();

        rb.velocity = readVector;
    }
    // Update is called once per frame
    void Update()
    {
        read = playerInput.actions["move"].ReadValue<Vector2>();
        
        rb.velocity = new Vector3(read.x * 5, rb.velocity.y, read.y * 5);

        if (rb.velocity.magnitude > 0.5f)
        {
            animatorController.SetBool("moving", true);
        }
        else
        {
            animatorController.SetBool("moving", false);
        }

        if (playerInput.actions["smoke"].enabled)
        {
            animatorController.SetTrigger("smoke");
        }
    }
}
