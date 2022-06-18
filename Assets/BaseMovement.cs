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

    protected Rigidbody playerRb;
    protected PlayerManager playerManager;


    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //get player input as float values
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Move and Jump
        Move();
        Jump();

        //change character on Key Press
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerManager.ChangePlayer();
        }

    }

    protected virtual void Move()
    {
        //Move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed * verticalInput);
        //Turn the vehicle
        transform.Rotate(Vector3.up * Time.deltaTime * playerTurnSpeed * horizontalInput);
    }

    
    protected virtual void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    //ground collision check
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
