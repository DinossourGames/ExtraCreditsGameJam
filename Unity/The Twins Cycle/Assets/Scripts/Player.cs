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



	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
	}
	
	void Update(){


		if((Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded){

			rb.velocity = Vector2.up * jumpForce;
		}

	}

	void FixedUpdate(){

		isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround);

		moveInput = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);
	}
}
