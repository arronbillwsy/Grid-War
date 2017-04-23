using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stops : MonoBehaviour {
    public static int count;
    public GameObject stop;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (count <= 4)
        {
            Vector3 position = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0);
            GameObject clone = Instantiate(stop, position, transform.rotation);
            count++;
        }
    }
}
