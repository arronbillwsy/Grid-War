﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour {
	private int count;
	public GameObject bomb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float x = Random.Range (5, 5);
		float y = Random.Range (5, 5);
		Vector3 v = new Vector3 (x, y, 0);
		if (count <= 5) {
			GameObject gobj = Instantiate (bomb, v, transform.rotation);
			count++;
		}
	}
}
