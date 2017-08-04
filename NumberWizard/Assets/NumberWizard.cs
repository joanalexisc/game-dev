using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	int min;
	int max;
	int guess;
	public int maxGuessesAllowed = 10; 
	public Text guessText;
	// Use this for initialization
	void Start () {
		min = 1;
		max = 101;
		guess = Random.Range (min, max);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			GuessHigher();
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			GuessLower();
		}
		this.guessText.text = guess.ToString();
	}

	public void GuessHigher(){
		min = guess + 1;
		NextGuess ();
	}

	public void GuessLower(){
		max = guess -1;
		NextGuess ();
	}

	void NextGuess(){

		guess = Random.Range (min, max); //(min + max) / 2;
		maxGuessesAllowed--;
		if (maxGuessesAllowed <= 0) {
			Application.LoadLevel("Win");
		}
	}
}
