using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public string collisorName = "HasCollision";
    public int collisionIndex;

      void OnTriggerEnter2D(Collider2D collider){
            var col = collider.transform;
		if(col.tag == "Player"){
                  if(collisionIndex !=4)
                        PlayerPrefs.SetInt(collisorName,collisionIndex);
                  else{
                        PlayerPrefs.SetInt(collisorName,collisionIndex);
                        gameObject.SetActive(false);
                  }

            }
	}


}
