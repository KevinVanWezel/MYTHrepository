using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour {

    private PlayerMovement _playerMove;
    private string up, down, left, right;

    void Start ()
    {
        _playerMove = GetComponent<PlayerMovement>();
    }
	
	void Update ()
    {
        
        if(Input.GetKeyDown(KeyCode.W))
        {
            //_playerMove.UpDown("up");
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            //_playerMove.UpDown("down");
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            //_playerMove.LeftRight("right");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //_playerMove.LeftRight("left");
        }
    }
}
