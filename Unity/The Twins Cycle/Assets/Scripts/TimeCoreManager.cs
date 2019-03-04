using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeCoreManager : MonoBehaviour
{
    public GameObject sliderzinho;
    public SpriteRenderer backgroundDay;
    public Slider slider;
    public int timeLeft = 15;
    int defaultMax;
    public Camera cam;
    public Vector3 offset;
    public Vector3 offset2;
    public Vector3 offset3;
    Vector3 velocity;
    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;
    public bool isChangeable = false;
    //bool hasCollided = false;
    string collisionName = "HasCollision";
    int collisionIndex = -1;
    public float smoothTime = .5f;
    public List<Transform> targets;
    public GameObject[] playerPrefabs; // 0 --> moon 1 --> sun
    private Player moon;
    private Player sun;
    bool whoIs; //true --> moon  false --> sun
    ScenesManager sm;
   
    void Awake(){
        PlayerPrefs.DeleteKey(collisionName);
    }
    void Start()
    {
        sliderzinho.gameObject.SetActive(false);
        slider.maxValue = timeLeft;
        slider.minValue = 0;
        defaultMax = timeLeft;
        sun = playerPrefabs[1].GetComponent<Player>();
        moon = playerPrefabs[0].GetComponent<Player>();

        sm = GetComponent<ScenesManager>();
        whoIs = moon.isMain ? true : false;
        moon.animator.SetBool("Sleeping",true);

        if(!isChangeable) 
            targets.Add(sun.transform);
        else   
            foreach (var item in playerPrefabs)
            {
                targets.Add(item.transform);
            }

    }
    void Update()
    {
        collisionIndex =  PlayerPrefs.GetInt(collisionName,-1);

        if(collisionIndex == 0 || isChangeable){
            PlayerPrefs.DeleteKey(collisionName);
            if(targets.Count <= 1)
                targets.Add(moon.transform);
            isChangeable = true;
        }
        if(collisionIndex == 1){
            PlayerPrefs.DeleteKey(collisionName);
            sm.Restart();
        }

        if((Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Space)) && isChangeable)
            SwitchChar();
        if((Input.GetKeyUp(KeyCode.JoystickButton2) || Input.GetKeyUp(KeyCode.Space)) && isChangeable)
            StartTimer();
            
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

    void StartTimer(){
        sliderzinho.gameObject.SetActive(true);
        InvokeRepeating("Countdown",0,1);
        // time -= Time.deltaTime;
        // slider.value = time;
    }

    void Countdown(){
        if(timeLeft>0){
            slider.value = timeLeft;
            timeLeft--;}
        else
            EndGame();
    }

    void EndGame(){
        CancelInvoke("Countdown");
        sm.Restart();
    }
    void SwitchChar(){
        var off = offset;
        offset = offset2;
        offset2 = off;
        CancelInvoke("Countdown");
        timeLeft = defaultMax;
        if(whoIs){
            backgroundDay.sortingOrder = -1;
            whoIs = false;
            moon.isMain = false;
            moon.animator.SetBool("Sleeping",true);
            sun.isMain = true;
            sun.animator.SetBool("Sleeping",false);
        }else{
            backgroundDay.sortingOrder = -4;
            whoIs = true;
            sun.isMain = false;
            sun.animator.SetBool("Sleeping",true);
            moon.isMain = true;
            moon.animator.SetBool("Sleeping",false);
        }
    }


}


