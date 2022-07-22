using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class RunPlayer : NetworkBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator animations;
    public float movementSpeed;



    void Start()
    {
        animations = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

   public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FloorMap"))
        {
            //rb.MovePosition(collision.gameObject.transform.position);
            transform.parent = collision.gameObject.transform;
        }
       
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FloorMap"))
        {
            transform.parent = null;
        }
    }

    void FixedUpdate()
    {
        if (isClient && isLocalPlayer) 
        {
            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            movementSpeed = Mathf.Clamp(moveInput.magnitude, 0.0f, 1.0f);
            moveVelocity = moveInput * speed;

            if (moveInput != Vector2.zero)
            {   
                animations.SetFloat("Horizontal", moveVelocity.x);
                animations.SetFloat("Vertical", moveVelocity.y);
            }
            animations.SetFloat("Speed", movementSpeed);
            //transform.position += (Vector3)(moveVelocity * Time.fixedDeltaTime);
            //rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
            rb.velocity = moveVelocity;
        }
        
    }
}
