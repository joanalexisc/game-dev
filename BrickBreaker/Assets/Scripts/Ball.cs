using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private Vector3 distanceFromBallToPaddle;
	private bool hasStarted = false;

	// Use this for initialization
	void Awake () {
		this.paddle = GameObject.FindObjectOfType<Paddle> ();
		this.distanceFromBallToPaddle = this.transform.position - this.paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = this.paddle.transform.position + distanceFromBallToPaddle;
		
			if (Input.GetMouseButtonDown (0)) {
				Debug.Log ("Launch the ball");
				this.rigidbody2D.velocity = new Vector2 (3f, 10f);
				this.hasStarted = true;
			}
		}
	}
	void OnCollisionEnter2D(Collision2D collision){
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));

		if (hasStarted) {
			audio.Play ();
			rigidbody2D.velocity += tweak;
		}
	}
}
