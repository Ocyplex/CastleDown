using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5f;

    private CharacterController myCharContro;
    private GameMaster myGameMaster;
    private Vector3 forceJump;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.3f;
    private float gravity = -9.8f;
    private float jumpHeight = 2f;
    bool isOnGround;

    void Start()
    {
        myCharContro = GetComponent<CharacterController>();
        myGameMaster = FindObjectOfType<GameMaster>();
        myGameMaster.AddMe(this);
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        myCharContro.Move(move * speed * Time.deltaTime);


        forceJump.y += gravity * Time.deltaTime;
        myCharContro.Move(forceJump * Time.deltaTime);


        isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isOnGround && forceJump.y <0)
        {
            forceJump.y = -1f;
        }

        if(Input.GetKeyDown("space") && isOnGround)
        {
            Debug.Log("Jump");
            forceJump.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.GetComponent<PickAble>())
        {
            hit.gameObject.GetComponent<PickAble>().UseMe(this);
        }

        if(hit.gameObject.GetComponent<Cube>().gravityBool)
        {
            hit.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }

        if(hit.gameObject.GetComponent<Bullet>())
        {
            Destroy(hit.gameObject);
        }
    }

    public void LineUse()
    {
        speed += 3;
        jumpHeight += 2;
    }
}
