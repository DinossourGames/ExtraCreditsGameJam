using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    string collisorName = "HasCollision";
    public int collisionIndex;
    public List<int> restrictedNumbers = new List<int>{-90,-65,-45,2};


      void OnTriggerEnter2D(Collider2D collider){
            var col = collider.transform;
		if(col.tag == "Player" && !restrictedNumbers.Contains(collisionIndex)){
                  PlayerPrefs.SetInt(collisorName,collisionIndex);
            }else{
                  //PUT CODE FOR THOSE WHO USE RESTRICTED CODES
            }
	}


}
