using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingScript : MonoBehaviour
{
    float _boulderKill = 2.0f;
    private Grid _grid;
    private bool _moving;

    private void Update()
    {
        BoulderFall();
        BoulderDeath();
    }
    //makes the boulder fall if nothing is under it
    private void BoulderFall()
    {
        _moving = false;
        if (Neighbour(0, -1) == null)
        {
            _grid.Move(_grid.findLocation(gameObject) + new Vector2(0, -1), gameObject);
            _moving = true;
        }
        else if (Neighbour(0, -1).tag == "boulder" || Neighbour(0, -1).tag == "gem")
        {
            if (Neighbour(-1, 0) == null && Neighbour(-1, -1) == null)
            {
                _grid.Move(_grid.findLocation(gameObject) + new Vector2(-1, 0), gameObject);
                _grid.Move(_grid.findLocation(gameObject) + new Vector2(0, -1), gameObject);
                _moving = true;
            }
            else if (Neighbour(1, 0) == null && Neighbour(1, -1) == null)
            {
                _grid.Move(_grid.findLocation(gameObject) + new Vector2(1, 0), gameObject);
                _grid.Move(_grid.findLocation(gameObject) + new Vector2(0, -1), gameObject);
                _moving = true;
            }
        }
    }
    //the player can be killed by falling stone
    private void BoulderDeath()
    {
        if (Neighbour(0, -1))
        {

            if (Neighbour(0, -1).tag == "player" && _moving)
            {
                print("gameOver()");
                _grid.Move(_grid.findLocation(gameObject) + new Vector2(0, -1), gameObject);
            }
            if (Neighbour(0, -1).tag == "player")
            {
                _boulderKill -= Time.deltaTime;
                if (_boulderKill < 0)
                {
                    print("gameOver()");
                    _grid.Move(_grid.findLocation(gameObject) + new Vector2(0,-1), gameObject);
                }
            }
            else
            {
                _boulderKill = 2.0f;
            }
        }

    }

    public void SetGrid(Grid grid)
    {
        _grid = grid;
    }

    private GameObject Neighbour(int x, int y)
    {
        return _grid.CheckRelativeTile(gameObject, x, y);
    }

    public void Left()
    {
        _grid.Move(_grid.findLocation(gameObject) + new Vector2(-1,0), gameObject);
    }

    public void right()
    {
        _grid.Move(_grid.findLocation(gameObject) + new Vector2(1, 0), gameObject);
    }

}