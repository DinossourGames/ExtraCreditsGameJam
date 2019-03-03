using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressureController : MonoBehaviour {

	bool isActive = false;
	SpriteRenderer spriteRenderer;
	public Sprite[] sprites;
	Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = sprites[0];

	}

	void Update(){

	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Player"){
			spriteRenderer.sprite = sprites[1];
			isActive = true;
		}
	}
	void OnCollisionExit2D(Collision2D collision){
		spriteRenderer.sprite = sprites[0];
		isActive = false;
	}
}
