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
    public float fallMult=2.5f, lowJumpMulti=2f,currentH=0,jumpH=0;

    private void Start()
    {
        //controller = GetComponent<CharacterController>(); 
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        Movement();
        clampHeight();


    }

    private void FixedUpdate()
    {

      Jump();
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
            currentH = transform.position.y;

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGroundednow = false;
            jumpH = currentH + jumpHeight;
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


    void clampHeight()
    {
        if(transform.position.y> jumpH)
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMult - 1) * Time.deltaTime;
    }
}
