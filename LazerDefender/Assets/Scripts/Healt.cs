using UnityEngine;
using System.Collections;

public class Healt : MonoBehaviour {
	public float lp = 100;
	public int scorePoints = 0;
	public AudioClip deadSound;
	// Use this for initialization
	public void Damage(float amount) {
		lp -= amount;
		if (lp <= 0) {
			if(this.deadSound){
				AudioSource.PlayClipAtPoint(deadSound,this.transform.position,1f);
			}
			ScoreKeeper.Score(this.scorePoints);
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		LazerPower lp = collider.gameObject.GetComponent<LazerPower> ();
		if (lp) {
			lp.Hit(gameObject);
		}
	}
}
