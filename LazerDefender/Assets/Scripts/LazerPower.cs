using UnityEngine;
using System.Collections;

public class LazerPower : MonoBehaviour {
	public float Damage { set; get;}
	public void Hit(GameObject hitGameObject){
		Healt healt = hitGameObject.GetComponent<Healt> ();

		if (healt) {
				Destroy (gameObject);
				healt.Damage (Damage);
		}
	}
}
