using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5f;
    private float gravity = -27f;
    private Vector3 force;
    private CharacterController myCharContro;


    void Start()
    {
        myCharContro = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        myCharContro.Move(move * speed * Time.deltaTime);


        force.y += gravity * Time.deltaTime;
        myCharContro.Move(force * Time.deltaTime);
    }
}
