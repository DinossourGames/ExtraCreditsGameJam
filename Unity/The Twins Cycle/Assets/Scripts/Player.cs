using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float movementSpeed;
	public float jumpForce;
	float moveInput;
	Rigidbody2D rb;

	private bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;
	public Animator animator;
	public bool facingRight = true;
	public bool isMain ;


	void Start () {
		rb = GetComponent<Rigidbody2D>();

		rb.freezeRotation = true;
	}
	
	void Update(){
		
		if(isMain){ //EVERYTHING WHAT HAPPENS WHEN PLAYER IS SELECTED NEEDS TO BE PLACED INSIDE THIS IF STATEMENT
			AnimationsChecker();
			
			if((Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded){
				rb.velocity = Vector2.up * jumpForce;
			}
		}
	}

    private void AnimationsChecker()
    {
		if(rb.velocity.y == 0){
			animator.SetBool("Jumping",false);
			animator.SetBool("Falling",false);
		}

		if(rb.velocity.y > 0){
			animator.SetBool("Jumping",true);
		}

		if(rb.velocity.y < 0){
			animator.SetBool("Jumping",false);
			animator.SetBool("Falling",true);
		}
    }

    void FixedUpdate(){

		if(isMain){ //EVERYTHING WHAT HAPPENS WHEN PLAYER IS SELECTED NEEDS TO BE PLACED INSIDE THIS IF STATEMENT

			isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround);
			

			moveInput = Input.GetAxis("Horizontal");
			rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);

			if(!facingRight && moveInput > 0)
				Flip();
			else if(facingRight && moveInput < 0)
				Flip();

		}

	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}
}
