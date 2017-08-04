using UnityEngine;
using System.Collections;

public class KeepOnScreen : MonoBehaviour {

	//public float padding = 1f;
	//private float xmin,xmax;
	// Use this for initialization
	void Start () {
		/*float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;*/
	}
	
	// Update is called once per frame
	void Update () {
		//float x = Mathf.Clamp (this.transform.position.x, this.xmin, this.xmax);
		//gameObject.transform.position = new Vector3 (x, this.transform.position.y, this.transform.position.z);
	}
}
