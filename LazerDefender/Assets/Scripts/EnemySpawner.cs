using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float heigth = 10f;
	public float width = 5f;
	public float xSpeed = 5f;
	public float ySpeed = 1f;

	private float xmin, xmax;
	private bool moveToRigth = true;

	// Use this for initialization
	void Start () {
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		xmin = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)).x;
		xmax = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance)).x;
		this.SpawnEnemies ();
	}

	void SpawnEnemies(){
		//foreach (Transform child in this.transform) {
		//	this.CreateEnemy(child);
		//}
		Transform childPosition = this.NextFreePosition ();
		if (childPosition) {
			this.CreateEnemy (childPosition);
		}
		if (this.NextFreePosition ()) {
			Invoke("SpawnEnemies",0.5f);
		}
	}

	void CreateEnemy(Transform parent){
		GameObject enemy = Instantiate (enemyPrefab, parent.position, Quaternion.identity) as GameObject;
		enemy.transform.parent = parent;
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube (this.transform.position, new Vector3 (this.width,this.heigth));
	}

	// Update is called once per frame
	void Update () {
		if (this.moveToRigth) {
			this.transform.position += Vector3.right * this.xSpeed * Time.deltaTime;
		} else {
			this.transform.position += Vector3.left * this.xSpeed * Time.deltaTime;
		}
		float rightEdge = this.transform.position.x + (0.5f * this.width);
		float leftEdget = this.transform.position.x - (0.5f * this.width);

		if (leftEdget <= this.xmin) {
			this.moveToRigth = true;
		}else if (rightEdge >= this.xmax) {
			this.moveToRigth = false;
		}

		if (AreAllEnemiesDead ()) {
			Debug.Log("They Are Dead");
			this.SpawnEnemies();
		}


		//float x = Mathf.Clamp (this.transform.position.x, this.xmin, this.xmax);
		//this.transform.position = new Vector3 (x, this.transform.position.y, this.transform.position.z);

	
	}

	Transform NextFreePosition(){
		foreach (Transform childTrans in transform) {
			if(childTrans.childCount == 0){
				return childTrans;
			}
		}
		return null;
	}

	bool AreAllEnemiesDead(){
		foreach (Transform childTrans in transform) {
			if(childTrans.childCount > 0){
				return false;
			}
		}
		return true;
	}
}
