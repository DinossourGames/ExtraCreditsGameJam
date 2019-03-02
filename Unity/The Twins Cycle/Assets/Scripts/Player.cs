using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float movementSpeed;
	public float jumpHeight;

	bool onAir = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float x = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
		float y = Input.GetAxis("Vertical") * jumpHeight * Time.deltaTime;
		transform.position = new Vector2(transform.position.x + x,transform.position.y);

	}
}
