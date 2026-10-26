using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Looker : MonoBehaviour
{
    [SerializeField] private InputActionReference lookActionRef;    
    [SerializeField] private Transform mainCamera;
    
    private float _xRotation = 0f;

    void OnEnable()
    {
        // Ensure the action is enabled
        lookActionRef.action.Enable();
    }

    void OnDisable()
    {
        lookActionRef.action.Disable();
    }

    void Update()
    {
        // Read the Vector2 value (X represents horizontal delta, Y represents vertical delta)
        Vector2 lookInput = lookActionRef.action.ReadValue<Vector2>();

        float mouseX = lookInput.x * 0.1f;
        float mouseY = lookInput.y * 0.1f;
        _xRotation -= mouseY;
        mainCamera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        // Rotate the player body left/right
        transform.Rotate(Vector3.up * mouseX);
    }
}
