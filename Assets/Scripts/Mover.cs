using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
   [SerializeField] private InputActionReference moveActionRef;    
    [SerializeField] private Transform playerCamera;
    private float interactionDistance = 3f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private InputActionReference fireActionRef;    
    
    private float _xRotation = 0f;

    void OnEnable()
    {
        // Ensure the action is enabled
        moveActionRef.action.Enable();
        fireActionRef.action.Enable();
    }

    void OnDisable()
    {
        moveActionRef.action.Disable();
        fireActionRef.action.Disable();
    }

    void Update()
    {
        // Read the Vector2 value (X represents horizontal delta, Y represents vertical delta)
        Vector2 moveInput = moveActionRef.action.ReadValue<Vector2>();

        float mouseX = moveInput.x;
        float mouseY = moveInput.y;
        // Rotate the player body left/right
        transform.Translate(Vector3.forward * mouseY * 5 * Time.deltaTime);
        transform.Translate(Vector3.right * mouseX * 5 * Time.deltaTime);
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
            
            if (fireActionRef.action.WasPressedThisFrame())
                {
                    interactable.Interact();
                }
            }
    }
    }
}
