using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public bool autoPlay;

	private Ball ball;
	
	void Start(){
		this.ball = Object.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.autoPlay) {
			this.AutoPlay();
		} else {
			this.MoveWithMouse();
		}
	}

	void AutoPlay(){
		Vector3 ballPosition = this.ball.GetComponent<Transform> ().position;
		Vector3 newPosition = new Vector3 ();
		newPosition.x = ballPosition.x;
		newPosition.y = this.transform.position.y;
		newPosition.z = this.transform.position.z;
		this.transform.position = newPosition;
	}

	void MoveWithMouse(){
		float mousePoInblocks = (Input.mousePosition.x / Screen.width * 16);
		mousePoInblocks = Mathf.Clamp (mousePoInblocks, 0.5F, 15.5F);
		this.transform.position = new Vector3 (mousePoInblocks, this.transform.position.y, 0);
	}
}
