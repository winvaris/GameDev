using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb2d;

	public float speed = 50f;
	public float maxSpeed = 2.2f;
	public float jumpPower = 500f;
	public bool grounded;

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

	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");

		// Move the player
		rb2d.AddForce (Vector2.right * speed * h);

		Debug.Log (h);

		// Limiting the speed of the player
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}
	}
}
