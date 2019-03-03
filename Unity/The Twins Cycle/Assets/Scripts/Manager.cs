using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {


	public void LoadScene(string scene){
		if(scene == "restart")
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		else
			SceneManager.LoadScene(scene);
	}
}
