using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressureController : MonoBehaviour {

	SpriteRenderer spriteRenderer;
	public Sprite[] sprites;

	void Start(){
		PlayerPrefs.SetInt("isActive",0);
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = sprites[0];

	}
    void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Player"){
			spriteRenderer.sprite = sprites[1];
			PlayerPrefs.SetInt("isActive",1);
		}
	}
	void OnCollisionExit2D(Collision2D collision){
		spriteRenderer.sprite = sprites[0];
		PlayerPrefs.SetInt("isActive",0);
	}
}
