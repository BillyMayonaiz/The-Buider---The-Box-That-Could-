using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Private variables

    public PlayerManager playerManager;

    private float speed = 12f;
    private float turnSpeed = 60f;
    private float horizontalInput;
    private float forwardInput;

    private float jumpForce = 5f;

    private Rigidbody playerRb;

    private bool isGrounded = true;
    private bool isActive = true;

    

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //Get player input as float values
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (isActive)
        {
            //Move the player forward
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            //Turn the vehicle
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && isActive)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    //Ground Collision Check
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    //enable movement script on selected player, and trigger changeplayer script
    private void OnMouseDown()
    {
        playerManager.ChangePlayer(this.gameObject);
        GetComponent<PlayerController>().enabled = true;
    }
}
