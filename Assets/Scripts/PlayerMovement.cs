using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }
    public void toMovePlayer(InputAction.CallbackContext context)
    {
        Vector2 readVector = context.action.ReadValue<Vector2>();

        rb.velocity = readVector;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 read = playerInput.actions["move"].ReadValue<Vector2>();

        rb.velocity = new Vector3(read.x * 5, rb.velocity.y, read.y * 5);
    }
}
