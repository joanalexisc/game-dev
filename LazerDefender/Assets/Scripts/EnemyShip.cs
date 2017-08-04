using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {
	public float shotsPerFrame = 1f;
	void Start(){
			//InvokeRepeating ("Fire", 0.00001F, 100 * Time.deltaTime);
	}

	void Update(){
		float probability = Time.deltaTime * shotsPerFrame;
		if (Random.value < probability) {
			this.Fire ();
		}
	}

	void Fire(){
		this.gameObject.GetComponent<Lazer> ().ShotLazer();
	}

}
