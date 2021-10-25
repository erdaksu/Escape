using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(CharacterController))]
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

    private void Start()
    {
        controller = GetComponent<CharacterController>(); 
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        Movement();
        
    }

    private void FixedUpdate()
    {

       // Applying Jump
        if (rb.velocity.y < 0.1f)
            if (Input.GetButtonDown("Jump"))
            {

                rb.AddForce(Vector3.up * jumpHeight * gravityMultiplier, ForceMode.Impulse);

            }
    }

    void Movement()
    {
        float curSpeed = speed * Input.GetAxis("Horizontal");
         

        if (rb.velocity.y < 0.1f)
        {
            isGroundednow=true;
        }


        move =(Vector3.right * curSpeed);
        //if (isGroundednow && Input.GetButtonDown("Jump"))
        //{
        //    move.y += Mathf.Sqrt(jumpHeight  * gravityMultiplier);
        //    isGroundednow = false;
        //}

        //move.y += gravityMultiplier * Time.deltaTime;
        controller.Move(move * Time.deltaTime);
    }
}
