using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	public AudioClip startSound;
	public AudioClip gameSound;
	public AudioClip endSound;

	private AudioSource music;

	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			this.music = GetComponent<AudioSource>();
			this.music.clip = startSound;
			this.music.loop = true;
			this.music.Play();
		}
		
	}

	void OnLevelWasLoaded(int level){
		Debug.Log ("Music Player Level: " + 1);
		if (music) {
			music.Stop ();
			music.clip = GetClip (level);
			music.loop = true;
			music.Play ();
		}
	}

	AudioClip GetClip(int index){
		switch (index) {
		case 0:
			return startSound;
		case 1:
			return gameSound;
		case 2:
			return endSound;
		}
		return null;
	}
}
