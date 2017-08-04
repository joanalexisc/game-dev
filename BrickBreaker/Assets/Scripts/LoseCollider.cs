﻿using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		this.levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		levelManager.LoadLevel("Lose");
	}

	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log ("Collision");
	}
}
