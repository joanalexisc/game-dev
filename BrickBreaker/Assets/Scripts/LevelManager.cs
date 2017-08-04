using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public void LoadLevel(string name){
		Application.LoadLevel (name);
	}

	public void LoadNextLevel(){
		Brick.ResetCount ();
		Application.LoadLevel (Application.loadedLevel + 1);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BrickDestroyed(){
		if (Brick.BrickCounter <= 0) {
			this.LoadNextLevel ();
		}
	}
}
