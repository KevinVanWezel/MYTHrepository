using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour {

    private SpawnScript _spawnScript;

	// Use this for initialization
	void Start ()
    {
        _spawnScript = GetComponent<SpawnScript>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            _spawnScript.NextLevel();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            _spawnScript.PreviousLevel();
        }
    }
}
