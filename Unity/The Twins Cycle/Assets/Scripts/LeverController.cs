using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public List<Sprite> states;
    public int isSpecial = 0;
    public bool status = false;
    public string trigger = "activation";
    SpriteRenderer sr;
    bool isValidPlayer = false;
    public GameObject slider;
    public GameObject moon;
    int idiota;


    
    void Start()
    {
        idiota = slider.layer;
		PlayerPrefs.SetInt(trigger,0);
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = states[1];
    }

    void Update()
    {
        if(status){
            slider.layer = moon.layer ;
        }else{
            slider.layer = idiota;
        }


        if((Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.DownArrow)) && isValidPlayer)
            DoStuff();
    }

    private void DoStuff()
    {
        if(!status){
            PlayerPrefs.SetInt(trigger,1);
            sr.sprite = states[2];
            status = true;
        }else{
             PlayerPrefs.SetInt(trigger,0);
            sr.sprite = states[0];
            status = false;
        }
    }


    void OnTriggerEnter2D(Collider2D collider){
        if((collider.name == "Moon" && isSpecial == 1 ) || (collider.name == "Sun" && isSpecial == 2 )){
            isValidPlayer = true;
        }           
    }

    void OnTriggerExit2D(Collider2D collider){
        isValidPlayer = false;
    }

}
