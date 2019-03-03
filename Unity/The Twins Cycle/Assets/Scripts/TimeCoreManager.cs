using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeCoreManager : MonoBehaviour
{

    public Camera cam;
    public Vector3 offset;
    public Vector3 offset2;
    public Vector3 offset3;
    Vector3 velocity;
    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;
    bool isChangeable = false;
    bool hasCollided = false;
    public string collisionName= "HasCollision";
    public float smoothTime = .5f;
    public List<Transform> targets;
    public GameObject[] playerPrefabs; // 0 --> moon 1 --> sun
    bool whoIs; //true --> moon  false --> sun
   
    void Awake(){
        PlayerPrefs.DeleteKey(collisionName);
    }
    void Start()
    {
        
        whoIs = playerPrefabs[0].GetComponent<Player>().isMain ? true : false;

        if(!isChangeable) 
            targets.Add(playerPrefabs[1].GetComponent<Player>().transform);
        else   
            foreach (var item in playerPrefabs)
            {
                targets.Add(item.transform);
            }

    }
    void Update()
    {

        hasCollided = PlayerPrefs.GetInt(collisionName,0) == 0 ? false : true;
        if(hasCollided && collisionName == "Level1Trigger"){
            PlayerPrefs.DeleteKey(collisionName);

            if(targets.Count <= 1)
                targets.Add(playerPrefabs[0].GetComponent<Player>().transform);

            isChangeable = true;
        }

        if((Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Space)) && isChangeable)
            SwitchChar();
            
    }

    void LateUpdate(){
        if(targets.Count == 0)
            return;

        Move();
        Zoom();
    }

    private void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom,minZoom,GetGreatestDistance()/zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition;
        if(targets.Count == 1)
            newPosition = centerPoint + offset3;
        else
            newPosition = centerPoint + offset;
        

        cam.transform.position = Vector3.SmoothDamp(cam.transform.position, newPosition, ref velocity, smoothTime);
    }

    Vector3 GetCenterPoint(){
        if(targets.Count == 1){
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
    float GetGreatestDistance(){
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }



    void SwitchChar(){
        var off = offset;
        offset = offset2;
        offset2 = off;
        if(whoIs){
            whoIs = false;
            playerPrefabs[0].GetComponent<Player>().isMain = false;
            playerPrefabs[1].GetComponent<Player>().isMain = true;
        }else{
            whoIs = true;
            playerPrefabs[1].GetComponent<Player>().isMain = false;
            playerPrefabs[0].GetComponent<Player>().isMain = true;
        }
    }
}


