using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    public void Load(string scene){
        SceneManager.LoadScene(scene);
    }
    public void Load(float delayTime){
        Invoke("LoadNextDelayed", delayTime);
    }
    public void Load(int index){
        SceneManager.LoadScene(index);
    }

    public void LoadNextDelayed(){
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex <= SceneManager.sceneCount - 1 ? SceneManager.GetActiveScene().buildIndex + 1 : SceneManager.sceneCount );
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
