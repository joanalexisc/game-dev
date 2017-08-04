using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public static LevelManager instance = null;

	public void Start(){
		if (!instance) {
			instance = this;
		} else {
			Destroy(this);
		}
	}

	public static void Load(string name){
		instance.LoadLevel (name);
	}

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void OnLevelWasLoaded(int level){
		Debug.Log ("Joanaaaaaaaa");
		if (level == 0) {
			ScoreKeeper.Reset ();
		}
	}
}
