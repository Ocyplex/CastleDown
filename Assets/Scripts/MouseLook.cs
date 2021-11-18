using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 10f;
    public Transform playerBody;
    float xRotation = 0f;
    private Vector2 inputVector = Vector2.zero;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        xRotation -= inputVector.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerBody.Rotate(Vector3.up * inputVector.x);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }


    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }
}
