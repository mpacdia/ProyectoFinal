using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

interface IInteractable
{
    public void Interact();
}

public class interactor : MonoBehaviour
{

    public Transform InteractorSource;
    public float InteractorRange;

    public float radius;

    bool isRotating = false;

    RaycastHit hitInfo2;

    PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            Vector3 relativePos = hitInfo2.collider.gameObject.transform.position - transform.position;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion targetRotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5.0f);
            Debug.Log(1 - Mathf.Abs(Quaternion.Dot(transform.rotation, targetRotation)));
            
            if (1 - Mathf.Abs(Quaternion.Dot(transform.rotation, targetRotation)) < 0.005f) isRotating = false;
        }
    }

    public void activateInteraction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.SphereCast(r, radius, out RaycastHit hitInfo, InteractorRange))
            {
                Debug.Log(hitInfo.collider.gameObject.name);
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    isRotating = true;
                    hitInfo2 = hitInfo;
                    /*Vector3 relativePos = hitInfo.collider.gameObject.transform.position - transform.position;

                    // the second argument, upwards, defaults to Vector3.up
                    Quaternion targetRotation = Quaternion.LookRotation(relativePos, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5.0f);
                    Debug.Log(Time.deltaTime);*/
                    // INTERPOLACION DE VECTORES / CLAMP/ LERP...
                    interactObj.Interact();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(InteractorSource.position * InteractorRange, radius);
    }
}