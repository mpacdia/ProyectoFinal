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

    bool rotating;

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

    
    

    public void smoke(InputAction.CallbackContext context)
    {
        if(context.started) animatorController.SetTrigger("smoke");
    }
    // Update is called once per frame
    void Update()
    {
        read = playerInput.actions["move"].ReadValue<Vector2>();

        Vector3 fwd = Camera.main.transform.forward * read.y * 5; /// eje z ajustado a la camara
        Vector3 right = Camera.main.transform.right * read.x * 5; /// eje x ajustado a la camara
        Vector3 final = fwd + right;
        final.y = 0;
        rb.velocity = new Vector3(final.x, rb.velocity.y, final.z);

        if (rb.velocity.magnitude > 0.5f)
        {
            animatorController.SetBool("moving", true);
        }
        else
        {
            animatorController.SetBool("moving", false);
        }

        rotating = playerInput.actions["rotate"].IsPressed();
        if (rotating) transform.Rotate(Vector3.up * playerInput.actions["rotate"].ReadValue<float>(), 24 * Time.deltaTime);
    }
}
