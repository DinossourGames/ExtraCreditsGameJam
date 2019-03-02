using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour {

	public int LevelNumber;
	public int ObjectivesCollected;
	public int ObjectivesToCollect;
	public int Cycles;
	public int State = 0; // 0--> off 1--> Pause 2--> death

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
