using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	
	void Update(){
		if(Input.GetKeyDown(KeyCode.P)){
			GetComponent<LevelData>().State = GetComponent<LevelData>().State == 0 ? 1 : GetComponent<LevelData>().State;
		}
	}
	
	public void SaveGame()
	{

	}

	public void GameOver(){
		
	}
}
