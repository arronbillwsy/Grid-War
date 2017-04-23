using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour {
	public int count;
	public GameObject bomb;
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (count <= 5) {
			float x = Random.Range (-50, 50);
			float y = Random.Range (-50, 50);
			Vector3 v = new Vector3 (x, y, 0);
			if (Vector2.Distance (v, player.transform.position) > 10f) {
				GameObject gobj = Instantiate (bomb, v, transform.rotation);
				count++;
			}
		}
	}
}
