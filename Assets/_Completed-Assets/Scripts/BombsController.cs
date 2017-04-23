using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombsController : MonoBehaviour {

	private Vector3 pos;
	private float speed;
	private Rigidbody2D rb2d;
	private float timeleft;
	private string status;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		speed = 1f;
		timeleft =2f;
		status = "random";
	}

	// Update is called once per frame
	void Update () {
		timeleft -= Time.deltaTime;
		//renderer.enabled = !renderer.enabled;
		if (timeleft <= 0) {
			if (status == "random") {
				int rand_index = Random.Range ((int)0, (int)4);
				Vector3[] move = { Vector3.up, Vector3.right, Vector3.down, Vector2.left };
				rb2d.velocity = speed * move [rand_index];
			} else {
				Vector2 pointA = new Vector2 (transform.position.x-3.5, transform.position.y-3.5);
				Vector2 pointB = new Vector2 (transform.position.x+3.5, transform.position.y+3.5);
				Collider2D[] obj_near = Physics2D.OverlapAreaAll(pointA, pointB);

				foreach (Collider2D obj in obj_near) {
					if (obj.tag == "player" || obj.tag == "AI_player") {
						if (Vector2.Distance (transform.position, obj) <= 1.5f) {
							obj.gameObject.SetActive (false);
						} else {
							Debug.Log ('temp');
						}
					}
				}
			}
			timeleft = 2f;
		}
	}
}
