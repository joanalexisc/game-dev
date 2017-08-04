using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Text> ().text = "Your Score \n"  + ScoreKeeper.PlayerScore; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
