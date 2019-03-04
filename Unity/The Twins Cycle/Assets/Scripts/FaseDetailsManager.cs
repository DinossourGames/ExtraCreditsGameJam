using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseDetailsManager : MonoBehaviour
{
    public int ObjectivesToCollect = 0;
    public int ObjectivesCollected = 0;
    public string triggerName = "objectiveAquired";


    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("ObjectivesToCollect",ObjectivesToCollect);
    }

    void Update(){
        var plus = PlayerPrefs.GetInt(triggerName,-1) == -1 ? false : true;
        if(plus){
            ObjectivesCollected++;
            PlayerPrefs.SetInt("ObjectivesCollected",ObjectivesCollected);
            PlayerPrefs.DeleteKey(triggerName);
        } 
    }

}
