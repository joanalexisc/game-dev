using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;

	public GameObject smoke;


	public static int BrickCounter {
		get {
			return brickCounter;
		}
	}

	private static int brickCounter = 0;
	private int maxHit;
	public Sprite[] hitSprites; 
	private LevelManager levelManager;
	private int timeHit = 0;
	// Use this for initialization
	void Start () {
		if (IsBreakable) {
			Brick.brickCounter++;
		}
		maxHit = this.hitSprites.Length + 1;
		this.levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		 
	}

	void OnCollisionEnter2D(Collision2D collision){
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (IsBreakable) {
			ProcessHit ();
		}
	}

	public bool IsBreakable{
		get{return this.tag == "Breakable";}
	}

	public void ProcessHit(){
		this.timeHit++;
		if (this.timeHit >= this.maxHit) {
			this.DestroyBrick();
		} else {
			this.LoadSprite();
		}
		

	}

	private void DestroyBrick(){
		Vector3 position = this.gameObject.transform.position;
		Destroy (this.gameObject);
		Brick.brickCounter--;
		GameObject smokepuf = Instantiate(smoke,position,Quaternion.identity) as GameObject;
		smokepuf.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer> ().color;

		this.levelManager.BrickDestroyed ();
		Debug.Log("Faltantes: " + brickCounter); 
	}

	public void LoadSprite(){
		SpriteRenderer spriteRendere = this.GetComponent<SpriteRenderer> ();
		spriteRendere.sprite = this.hitSprites [this.timeHit - 1];
	}

	public void GoToNextLevel(){
		this.levelManager.LoadNextLevel ();
	}

	public static void ResetCount(){
		brickCounter = 0;
	}
}
