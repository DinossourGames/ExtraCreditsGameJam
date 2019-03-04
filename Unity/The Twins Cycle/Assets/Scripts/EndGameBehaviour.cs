using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameBehaviour : MonoBehaviour
{
    public bool isMoon; 
    SpriteRenderer sprite;
    Color sunColor = Color.yellow;
    Color moonColor = Color.blue;
    Color defaultColor;

      void Start()
    {
        
        sprite = GetComponent<SpriteRenderer>();
        defaultColor = sprite.color;
    }
    
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.name == "Moon" && isMoon){
            sprite.color = moonColor;
            PlayerPrefs.SetInt("MoonCheck",1);
        }
        if(collider.name == "Sun" && !isMoon){
            sprite.color = sunColor;
            PlayerPrefs.SetInt("SunCheck",1);
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.tag == "Player")
            sprite.color = defaultColor;
            PlayerPrefs.SetInt("MoonCheck",0);
            PlayerPrefs.SetInt("SunCheck",0);

    }

}
