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
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
        
    }
}
