using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirt_block : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("dirt_block");
    }
	
	//looks if the player and the dirt block collide and than destroys the dirt block
    private void OnTriggerEnter2D(Collider2D Other)
    {

        if (Other.tag == "Player")
        {

            Destroy(gameObject);


        }
    }
}
