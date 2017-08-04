using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {
	public float speed = 10f;
	public float padding = 1f;
	public float fireRate = 0.2f;

	private float xmin,xmax;
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		this.MoveShip ();
	
	}

	void MoveShip(){
		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.position += Vector3.right * speed * Time.deltaTime;
		} 
		string ShotMethod = "ShotLazer";
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating(ShotMethod,0.00002f,this.fireRate);
		} else if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke(ShotMethod);
		}
		float x = Mathf.Clamp (this.transform.position.x, this.xmin, this.xmax);
		gameObject.transform.position = new Vector3 (x, this.transform.position.y, this.transform.position.z);
	}

	void ShotLazer(){
		Lazer lazer = GetComponent<Lazer> ();
		lazer.ShotLazer ();
	}

	void OnDestroy(){
		LevelManager.Load ("WinScreen");
	}
}
