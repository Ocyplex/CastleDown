using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour
{
    private PlayerInputHandler playerInputHandler;
    public GameObject myBody;


    private float speed = 5f;

    private CharacterController myCharContro;
    private GameMaster myGameMaster;
    private Vector3 forceJump;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.3f;
    private float gravity = -9.8f;
    private float jumpHeight = 2f;
    [SerializeField] private bool isOnGround = false;
    [SerializeField] private MouseLook myMouseLook;
    private Vector2 moveInput = Vector2.zero;
    [SerializeField] private bool jump = false;
    [SerializeField]
    public int index = 0;
    private Camera myCam;



    void Start()
    {
        myGameMaster = FindObjectOfType<GameMaster>();
        playerInputHandler = FindObjectOfType<PlayerInputHandler>();
        myCharContro = GetComponent<CharacterController>();
        myGameMaster.AddMe(this);
        myMouseLook = GetComponentInChildren<MouseLook>();
        myCam = GetComponentInChildren<Camera>();
        index = playerInputHandler.AddMe();
        SetCamera();
        gameObject.SetActive(false);
    }


    void Update()
    {

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        myCharContro.Move(move * speed * Time.deltaTime);


        forceJump.y += gravity * Time.deltaTime;
        myCharContro.Move(forceJump * Time.deltaTime);


        isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isOnGround && forceJump.y < 0)
        {
            forceJump.y = -1f;
        }

        if (jump && isOnGround)
        {
            Debug.Log("Jump");
            forceJump.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jump = context.action.triggered;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        myMouseLook.SetInputVector(context.ReadValue<Vector2>());
    }

    public int GetIndex()
    {
        return index;
    }

    public void SetCamera()
    {
        if (index == 1)
        {
            myCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
        }
        else
        {
            myCam.rect = new Rect(0f, 0f, 0.5f, 1f);
        }
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.GetComponent<PickAble>())
        {
            hit.gameObject.GetComponent<PickAble>().UseMe(this);
        }

        if (hit.gameObject.GetComponent<Cube>().gravityBool == true)
        {
            hit.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }

        if (hit.gameObject.GetComponent<Bullet>())
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
