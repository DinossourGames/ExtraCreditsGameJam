using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    public Vector2 startPosition;
    public Vector2 endPosition;
    public float animationSpeed;
    public bool isVertical = false;
    public bool isLooping = false;
    bool locker = false;
    public bool state = false;
    public bool defaultState = true;
    Vector2 position;
    public bool isTriggered = true;
    public string triggerName = "isActive";
    //List<Vector2> positions;

    void Start()
    {
        if(startPosition.x == 0 && startPosition.y == 0)
            startPosition = gameObject.transform.position;
    }

    void Update()
    {
        if(isTriggered)
            state = PlayerPrefs.GetInt(triggerName,0) == 1 ? true : false;
        
        position = gameObject.transform.position;


        if(!isVertical){ 
            if(Math.Round(position.x) == Math.Round(endPosition.x))
                locker = true;
            if(Math.Round(position.x) == Math.Round(startPosition.x))
                locker = false;
        }else{
            if(Math.Round(position.y) == Math.Round(endPosition.y))
                locker = true;
            if(Math.Round(position.y) == Math.Round(startPosition.y))
                locker = false;
        }

        if(state){

            if(!locker){
                GoFoward();
            }else{
                Rewind();
            }

        }else
            if(defaultState)
                Rewind();
            


    }



    private void Rewind()
    {
        if(!isVertical){
            if(position.x < startPosition.x ){
                transform.position = new Vector2(position.x + animationSpeed * Time.deltaTime, position.y);
            }

        }else{
            if(position.y > startPosition.y ){
                transform.position = new Vector2(position.x, position.y - animationSpeed * Time.deltaTime);
            }
            
        }
    }

    private void GoFoward()
    {
        if(!isVertical){
            if(position.x > endPosition.x ){
                transform.position = new Vector2(position.x - animationSpeed * Time.deltaTime, position.y);
            }
            
        }else{
            if(position.y < endPosition.y ){
                transform.position = new Vector2(position.x, position.y + animationSpeed * Time.deltaTime);
            }
            
        }
    }
}
