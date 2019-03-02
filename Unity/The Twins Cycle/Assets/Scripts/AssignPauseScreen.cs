using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignPauseScreen : MonoBehaviour {

	public GameObject PauseUI;
	public Text StateText;
	LevelData level;
	public bool status;


	// Use this for initialization
	void Start () {
		level = GetComponent<LevelData>();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.P)){
			status = !status;
			if(status)
				level.State = 1;
			else if (!status)
				level.State = 0;
		}
	}

	void FixedUpdate(){
		switch(level.State){
			case 0:
				PauseUI.SetActive(false);
				break;
			case 1:
				StateText.text = "Game Paused";
				PauseUI.SetActive(true);
				break;
			case 2:
				StateText.text = "Game Over";
				PauseUI.SetActive(true);
				break;
		}
	}
}
