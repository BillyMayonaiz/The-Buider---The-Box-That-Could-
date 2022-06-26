using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    //player control pos/rot values
    [SerializeField] protected float playerSpeed;
    [SerializeField] protected float playerTurnSpeed;

    //player control input values
    private float horizontalInput;
    private float verticalInput;

    //player control jump value
    [SerializeField] protected float jumpForce;
    [SerializeField] protected bool isGrounded = true;
    [SerializeField] protected bool isMoving = false;
    [SerializeField] public bool isGameWon = false;

    protected Rigidbody playerRb;
    protected PlayerManager playerManager;
    protected Animator playerAnimator;

    private float xRangeStart = -105f;
    private float xRangeEnd = 35f;
    private float zRangeStart = -15f;
    private float zRangeEnd = 7f;

    private int isWalkingHash;
    private int isJumpingHash;

    

        // Start is called before the first frame update
        protected virtual void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GameObject.Find("Cat").GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    // Update is called once per frame
    void Update()
    {
        //get player input as float values
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Move, Jump, and Boundary Check
        if (!isGameWon)
        {
            Move();
            Jump();
            BoundaryCheck();
            HandleAnimation();

            //change character on Key Press
            if (Input.GetKeyDown(KeyCode.C))
            {
                playerManager.ChangePlayer();
            }
        }
    }

    protected virtual void Move()
    {
        //Move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed * verticalInput);
        //Turn the vehicle
        transform.Rotate(Vector3.up * Time.deltaTime * playerTurnSpeed * horizontalInput);

        isMoving = verticalInput > 0.1 || verticalInput < -0.1;
    }


    protected virtual void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    protected virtual void BoundaryCheck()
    {
        //keep player within bounds of range variable
        if (transform.position.x > xRangeEnd)
        {
            transform.position = new Vector3(xRangeEnd, transform.position.y, transform.position.z);
        }
        if (transform.position.x < xRangeStart)
        {
            transform.position = new Vector3(xRangeStart, transform.position.y, transform.position.z);
        }
        if (transform.position.z > zRangeEnd)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeEnd);
        }
        if (transform.position.z < zRangeStart)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeStart);
        }
    }

    protected virtual void HandleAnimation()
    {
        bool isWalking = playerAnimator.GetBool(isWalkingHash);
        bool isJumping = playerAnimator.GetBool(isJumpingHash);
        

        if (isMoving && isGrounded) 
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else if (!isMoving && isGrounded)
        {
            playerAnimator.SetBool("isWalking", false);
        }

        if (!isGrounded)
        {
            playerAnimator.SetBool("isJumping", true);
        }
        else if (isGrounded)
        {
            playerAnimator.SetBool("isJumping", false);
        }

    }

    //ground collision check
    protected virtual void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }


}
