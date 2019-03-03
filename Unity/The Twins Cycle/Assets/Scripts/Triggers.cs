using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public string collisorName = "HasColission";
    void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag == "Player"){
            PlayerPrefs.SetInt(collisorName,1);
		}
	}
}
