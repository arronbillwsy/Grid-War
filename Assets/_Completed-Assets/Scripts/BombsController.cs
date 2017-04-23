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
			status = "random";
			Vector2 pointA = new Vector2 (transform.position.x-10f, transform.position.y-10f);
			Vector2 pointB = new Vector2 (transform.position.x+10f, transform.position.y+10f);
			Collider2D[] obj_near = Physics2D.OverlapAreaAll(pointA, pointB);

			foreach (Collider2D obj in obj_near) {
				if (obj.tag == "Player" || obj.tag == "AI_player") {
					status = "chase";
					Debug.Log ("chase");
					if (Vector2.Distance (transform.position, obj.transform.position) <= 4.4f) {
						Debug.Log ("explosion");
						obj.gameObject.SetActive (false);
						gameObject.SetActive (false);
					} else {
						var targetPosition = obj.transform.position;
						var distance = Vector2.Distance (transform.position, targetPosition);
						Debug.Log ("distance");
						Debug.Log (transform.position);
						Debug.Log (obj.transform.position);

						float r_dir = Random.Range (-1.0f, 1.0f);
						if (r_dir >= 0) {
							if (transform.position.x < targetPosition.x) {
								rb2d.velocity = speed * Vector3.right;
							} else {
								rb2d.velocity = speed * Vector3.left;
							}
						} else {
							if (transform.position.y < targetPosition.y) {
								rb2d.velocity = speed * Vector3.up;
							} else {
								rb2d.velocity = speed * Vector3.down;
							}
						}
						break;
					}
				}
			}

			if (status == "random") {
				Debug.Log ("random");
				int rand_index = Random.Range (0, 4);
				Vector3[] move = { Vector3.up, Vector3.right, Vector3.down, Vector2.left };
				rb2d.velocity = speed * move [rand_index];
			}

			timeleft = 2f;
		}
	}
}
