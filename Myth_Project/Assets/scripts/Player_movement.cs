using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIRECTION { UP, DOWN, LEFT, RIGHT}

public class Player_movement : MonoBehaviour {
    private bool canMove = true, moving = false;
    private int speed = 5, buttonCooldown = 0;
    private DIRECTION dir = DIRECTION.DOWN;
    private Vector3 pos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        buttonCooldown--;

        if (canMove)
        {
            pos = transform.position;
            move();
        }

        if (moving)
        {
            if(transform.position == pos)
            {
                moving = false;
                canMove = true;

                move();
            }
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        }

      
	}
    private void move()
    {
        if (buttonCooldown <= 0)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (dir != DIRECTION.UP)
                {
                    buttonCooldown = 2;
                    dir = DIRECTION.UP;
                }
                else
                {
                    canMove = false;
                    moving = true;
                    pos += Vector3.up;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (dir != DIRECTION.DOWN)
                {
                    buttonCooldown = 2;
                    dir = DIRECTION.DOWN;
                }
                else
                {
                    canMove = false;
                    moving = true;
                    pos += Vector3.down;
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (dir != DIRECTION.LEFT)
                {
                    buttonCooldown = 2;
                    dir = DIRECTION.LEFT;
                }
                else
                {
                    canMove = false;
                    moving = true;
                    pos += Vector3.left;
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (dir != DIRECTION.RIGHT)
                {
                    buttonCooldown = 2;
                    dir = DIRECTION.RIGHT;
                }
                else
                {
                    canMove = false;
                    moving = true;
                    pos += Vector3.right;
                }
            }
        }
    }
}
