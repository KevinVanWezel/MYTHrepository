using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirt_block : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("dirt_block");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("test");
        if (other.tag == "Player")
        {

            Destroy(gameObject);


        }
    }
}
