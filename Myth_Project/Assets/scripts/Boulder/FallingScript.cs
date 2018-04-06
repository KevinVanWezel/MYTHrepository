using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingScript : MonoBehaviour
{
    private Grid _grid;
    private bool _moving;

    private void Update()
    {
        _moving = false;
        if (Neighbour(0, -1) == null)
        {
            _grid.Down(gameObject);
            _moving = true;
        }
        else if (Neighbour(0, -1).tag == "boulder" || Neighbour(0, -1).tag == "gem")
        {
            if (Neighbour(-1, 0) == null && Neighbour(-1, -1) == null)
            {
                _grid.Left(gameObject);
                _grid.Down(gameObject);
                _moving = true;
            }
            else if (Neighbour(1, 0) == null && Neighbour(1, -1) == null)
            {
                _grid.Right(gameObject);
                _grid.Down(gameObject);
                _moving = true;
            }
        }
        if (Neighbour(0, -1))
        {
            if (Neighbour(0, -1).tag == "player" && _moving)
            {
                print("gameOver()");
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
        _grid.Left(gameObject);
    }

    public void right()
    {
        _grid.Right(gameObject);
    }

}