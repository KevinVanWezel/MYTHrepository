using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour {


    /*
     * Handles all the input of the player
     */
    private AnimatePlayer _Move;
    private PlayerMovement _playerMove;

    void Start ()
    {
        _playerMove = GetComponent<PlayerMovement>();
        _Move = GetComponent<AnimatePlayer>();
    }
	
	void Update ()
    {
        
        if(Input.GetKeyDown(KeyCode.W))
        {
            _playerMove.UpDown("up");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            
            _playerMove.LeftRight("left");
            _Move.Animate(true);
            _Move.Look(false);
           
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _playerMove.UpDown("down");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _playerMove.LeftRight("right");
            _Move.Animate(true);
            _Move.Look(true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
           _Move.Animate(false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            _Move.Animate(false);
        }
    }
}
