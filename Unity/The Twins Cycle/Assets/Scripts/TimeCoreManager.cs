using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCoreManager : MonoBehaviour
{

    public GameObject[] playerPrefabs; // 0 --> moon 1 --> sun

    bool whoIs; //true --> moon  false --> sun
   

    void Start()
    {
        whoIs = playerPrefabs[0].GetComponent<Player>().isMain ? true : false;
    }


    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Space))
            SwitchChar();
    }

    void SwitchChar(){
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


