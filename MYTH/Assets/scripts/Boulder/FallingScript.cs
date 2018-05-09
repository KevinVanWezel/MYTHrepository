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
            gameObject.transform.Translate(new Vector2(0, -1));
            _moving = true;
        }
        else if (Neighbour(0, -1).tag == "boulder" || Neighbour(0, -1).tag == "gem")
        {
            if (Neighbour(-1, 0) == null && Neighbour(-1, -1) == null)
            {
                _grid.Move(_grid.findLocation(gameObject) + new Vector2(-1, 0), gameObject);
                gameObject.transform.Translate(new Vector2(-1, 0));
                _grid.Move(_grid.findLocation(gameObject) + new Vector2(0, -1), gameObject);
                gameObject.transform.Translate(new Vector2(0, -1));
                _moving = true;
            }
            else if (Neighbour(1, 0) == null && Neighbour(1, -1) == null)
            {
                _grid.Move(_grid.findLocation(gameObject) + new Vector2(1, 0), gameObject);
                gameObject.transform.Translate(new Vector2(1, 0));
                _grid.Move(_grid.findLocation(gameObject) + new Vector2(0, -1), gameObject);
                gameObject.transform.Translate(new Vector2(0, -1));
                _moving = true;
            }
        }
    }
    //the player can be killed by falling stone
    private void BoulderDeath()
    {
        if (Neighbour(0, -1))
        {

            if (Neighbour(0, -1).tag == "Parent" && _moving)
            {
                print("gameOver()");
                _grid.Move(_grid.findLocation(gameObject) + new Vector2(0, -1), gameObject);
                gameObject.transform.Translate(new Vector2(0, -1));
            }
            if (Neighbour(0, -1).tag == "Parent")
            {
                _boulderKill -= Time.deltaTime;
                if (_boulderKill < 0)
                {
                    print("gameOver()");
                    _grid.Move(_grid.findLocation(gameObject) + new Vector2(0,-1), gameObject);
                    gameObject.transform.Translate(new Vector2(0, -1));
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
        gameObject.transform.Translate(new Vector2(-1, 0));
    }

    public void Right()
    {
        _grid.Move(_grid.findLocation(gameObject) + new Vector2(1, 0), gameObject);
        gameObject.transform.Translate(new Vector2(1, 0));
    }

    public void Move(Vector2 input)
    {
        _grid.Move(_grid.findLocation(gameObject) + input, gameObject);
        gameObject.transform.Translate(input);
    }

}