using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    public void Load(string scene){
        SceneManager.LoadScene(scene);
    }
    public void Load(int index){
        SceneManager.LoadScene(index);
    }

    public void Load(bool nextScene){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart(){
        Load(SceneManager.GetActiveScene().name);
    }

    
    public void Restart(float delaytime){
        StartCoroutine(InvokeRestart(.5f));
    }

    IEnumerator InvokeRestart(float delayTime)
    {
      yield return new WaitForSeconds(delayTime);
      Restart();
    }
}
