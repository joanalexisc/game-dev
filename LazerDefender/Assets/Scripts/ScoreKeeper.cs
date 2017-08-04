using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	public static int PlayerScore { get; private set;}
	private static Text scoreText;

	void Start(){
		scoreText = GetComponent<Text> ();
	}
	void ResetScore(){
		Reset ();
	}
	public static void Reset(){
		PlayerScore = 0;
		ScoreChanged ();
	}

	public static void Score(int points){
		PlayerScore += points;
		ScoreChanged ();
	}

	private static void ScoreChanged(){
		if (scoreText) {
			scoreText.text = PlayerScore.ToString ().PadLeft (9, '0');
		}
	}
	
}
