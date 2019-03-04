using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressureController : MonoBehaviour {

	SpriteRenderer spriteRenderer;
	public Sprite[] sprites;
	public string targetName = "isActive";

	void Start(){
		PlayerPrefs.SetInt(targetName,0);
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = sprites[0];

	}
    void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Player"){
			spriteRenderer.sprite = sprites[1];
			PlayerPrefs.SetInt(targetName,1);
		}
	}
	void OnCollisionExit2D(Collision2D collision){
		spriteRenderer.sprite = sprites[0];
		PlayerPrefs.SetInt(targetName,0);
	}
}
