using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour {

	PlayerController player;
	Rigidbody2D rb2d;

	public float speed = 50f;
	public float maxSpeed = 1.8f;
	public float jumpPower = 500f;
	public bool grounded;
	public GameObject playerObj;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		player = playerObj.GetComponent<PlayerController> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		float h = 0;
		if (player.transform.position.x > this.transform.position.x) {
			h = 0.25f;
		}
		else {
			h = -0.25f;
		}

		// Move the player
		rb2d.AddForce (Vector2.right * speed * h);

		// Limiting the speed of the player
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}
	}
}
