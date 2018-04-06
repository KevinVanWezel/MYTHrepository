using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour {

    private PlayerMovement _playerMove;

    void Start ()
    {
        _playerMove = GetComponent<PlayerMovement>();
    }
	
	void Update ()
    {
        
        if(Input.GetKeyDown(KeyCode.W))
        {
            _playerMove.Up();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            _playerMove.Down();
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            _playerMove.Right();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _playerMove.Left();
        }
    }
}
