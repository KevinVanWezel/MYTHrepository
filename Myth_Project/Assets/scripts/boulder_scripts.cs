using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulder_scripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var _rb = GetComponent<Rigidbody2D>();
        var _constr = _rb.constraints;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D Other)
    {
        print("test");
        if (Other.tag == "Player")
        {
           
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;

        }
    }
}
