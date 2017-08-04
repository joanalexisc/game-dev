using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance;
	// Use this for initialization
	void Awake () {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (this);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
