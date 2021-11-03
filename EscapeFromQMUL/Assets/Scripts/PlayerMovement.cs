using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    private CharacterController controller;
    private Rigidbody rb;
    public float jumpHeight = 2.4f;
    public float gravityMultiplier = 1f;
    public Vector3 move;
    public bool isGroundednow=false;
    public float fallMult=2.5f, lowJumpMulti=2f;

    private void Start()
    {
        //controller = GetComponent<CharacterController>(); 
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        Movement();
        Jump();
        
    }

    private void FixedUpdate()
    {

      
    }

    void Movement()
    {
        float curSpeed = speed * Input.GetAxis("Horizontal"); 
        move =(Vector3.right * curSpeed);
        transform.Translate(move);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGroundednow = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGroundednow = false;
        }
    }

    private void Jump()
    {
        // Applying Jump

        if (Input.GetButton("Jump") && isGroundednow)
        {
            rb.AddForce(Vector3.up * jumpHeight * gravityMultiplier, ForceMode.Impulse);

        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMult - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMulti - 1) * Time.deltaTime;

        }
    }
}
