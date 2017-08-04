using UnityEngine;
using System.Collections;

public class Lazer : MonoBehaviour {

	public GameObject shot;
	//public Vector3 position;
	public Vector2 fireSpeed;

	public float power = 50;

	public AudioClip lazerSound;

	public void ShotLazer(){

		GameObject lazer = Instantiate (this.shot, this.transform.position, Quaternion.identity) as GameObject;
		lazer.transform.parent = GameObject.Find ("Lazers").transform;
		LazerPower lp = lazer.GetComponent<LazerPower> ();
		lp.Damage = power;
		lazer.rigidbody2D.velocity = this.fireSpeed;
		if (this.lazerSound) {
			AudioSource.PlayClipAtPoint (lazerSound, lazer.transform.position, 0.2f);
		}
			//lazer.transform.parent = this.transform;
	}
}
