using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFaseManager : MonoBehaviour
{
    bool a;
    bool b;
    ScenesManager d;
    public string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("SunCheck");
        PlayerPrefs.DeleteKey("MoonCheck");
        d = GetComponent<ScenesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        a = PlayerPrefs.GetInt("SunCheck",0) == 1 ? true : false;
        b = PlayerPrefs.GetInt("MoonCheck",0) == 1 ? true : false;

        var c = CheckData();

        if(a && b && c){
            d.Load(sceneToLoad);
        }
    }

    private bool CheckData()
    {
        var otc = PlayerPrefs.GetInt("ObjectivesToCollect",0);
        var oc = PlayerPrefs.GetInt("ObjectivesCollected",0);

        if(oc == otc){
            return true;
        }
        return false;
    }
}
