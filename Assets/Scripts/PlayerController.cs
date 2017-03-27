using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb2d;

	public float speed = 50f;
	public float maxSpeed = 2;
	public float jumpPower = 500f;
	public bool grounded;
	private float temp = 0f;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			rb2d.AddForce (Vector2.up * jumpPower);
		}
	}
		
	bool IsNotDecreasing () {
		if (temp > 0f) {
			if (Input.GetAxis ("Horizontal") < temp) {
				temp = Input.GetAxis ("Horizontal");
				return false;
			}
		}
		else if (temp < 0f) {
			if (Input.GetAxis ("Horizontal") > temp) {
				temp = Input.GetAxis ("Horizontal");
				return false;
			}
		}
		temp = Input.GetAxis ("Horizontal");
		return true;
	}

	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");
		// Move the player
		if (IsNotDecreasing ()) {
			rb2d.AddForce (Vector2.right * speed * h);
		}
		if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D)) {
			rb2d.velocity = new Vector3 (0f, 0f, 0f);
		}
		// Limiting the speed of the player
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}
	}
}
