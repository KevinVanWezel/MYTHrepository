using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    private Grid _grid;
    private FallingScript _boulderFall;   
    private SpawnScript _Points;

    void Start()
    {
       _Points = GameObject.FindGameObjectWithTag("LevelSpawner").GetComponent<SpawnScript>();
    }
      
    public void SetGrid(Grid grid)
    {
    
        _grid = grid;
    }
    /*
    public void UpDown(int offSet, string direction)
    {
        int[] location = _grid.findObject(gameObject);
        print(location[0] + "x y" + location[1]);
        GameObject target = _grid.CheckTile(location[0], location[1] + offSet);
        if (target == null)
        {
            _grid.Up(gameObject);
        }
        else
        {
            switch (target.tag)
            {
                case "gem":
                    _Points.AddPoints(1);
                    _grid.MoveInDirection(direction, gameObject);
                    break;
                case "gem2":
                    _Points.AddPoints(2);
                    _grid.MoveInDirection(direction, gameObject);
                    break;
                case "gem3":
                    _Points.AddPoints(3);
                    _grid.MoveInDirection(direction, gameObject);
                    break;
                case "dirt":
                    _grid.MoveInDirection(direction, gameObject);
                    break;
                case "finish":
                    GameObject.FindGameObjectWithTag("LevelSpawner").GetComponent<SpawnScript>().NextLevel();
                    break;
                default:
                    break;
            }
        }
    }
    public void LeftRight(int offSet, string direction)
    {
        int[] location = _grid.findObject(gameObject);
        GameObject target = _grid.CheckTile(location[0] - offSet, location[1]);
        if (target == null)
        {
            _grid.Left(gameObject);
        }
        else
        {
            switch (target.tag)
            {
                case "gem":
                    _Points.AddPoints(1);
                    _grid.MoveInDirection(direction, gameObject);
                    break;
                case "gem2":
                    _Points.AddPoints(2);
                    _grid.MoveInDirection(direction, gameObject);
                    break;
                case "gem3":
                    _Points.AddPoints(3);
                    _grid.MoveInDirection(direction, gameObject);
                    break;
                case "dirt":
                    _grid.MoveInDirection(direction, gameObject);
                    break;
                case "finish":
                    GameObject.FindGameObjectWithTag("LevelSpawner").GetComponent<SpawnScript>().NextLevel();
                    break;
                case "boulder":
                    if (_grid.CheckTile(location[0] - 2, location[1]) == null)
                    {
                        target.GetComponent<FallingScript>().Left();
                        _grid.Left(gameObject);
                    }

                    break;
                default:
                    break;
            }
        }
    }
    */

    /*
    public void Up()
    {
        int[] location = _grid.findObject(gameObject);
        GameObject target = _grid.CheckTile(location[0], location[1] + 1);
        if (target == null)
        {
            _grid.Up(gameObject);
        }
        else
        {
            switch (target.tag)
            {
                case "gem":
                    _Points.AddPoints(1);
                    _grid.Up(gameObject);
                    break;
                case "gem2":
                    _Points.AddPoints(2);
                    _grid.Up(gameObject);
                    break;
                case "gem3":
                    _Points.AddPoints(3);
                    _grid.Up(gameObject);
                    break;
                case "dirt":
                    _grid.Up(gameObject);
                    break;
                case "finish":
                    GameObject.FindGameObjectWithTag("LevelSpawner").GetComponent<SpawnScript>().NextLevel();
                    break;
                default:
                    break;
            }
        }
    }

    public void Down()
    {
        int[] location = _grid.findObject(gameObject);
        GameObject target = _grid.CheckTile(location[0], location[1] - 1);
        if (target == null)
        {
            _grid.Down(gameObject);
        }
        else
        {
            switch (target.tag)
            {
                case "gem":
                    _Points.AddPoints(1);
                    _grid.Down(gameObject);
                    break;
                case "gem2":
                    _Points.AddPoints(2);
                    _grid.Down(gameObject);
                    break;
                case "gem3":
                    _Points.AddPoints(3);
                    _grid.Down(gameObject);
                    break;
                case "dirt":
                    _grid.Down(gameObject);
                    break;
                case "finish":
                    GameObject.FindGameObjectWithTag("LevelSpawner").GetComponent<SpawnScript>().NextLevel();
                    break;
                default:
                    break;
            }
        }
    }

    public void Left()
    {
        int[] location = _grid.findObject(gameObject);
        GameObject target = _grid.CheckTile(location[0] - 1, location[1]);
        if (target == null)
        {
            _grid.Left(gameObject);
        }
        else
        {
            switch (target.tag)
            {
                case "gem":
                    _Points.AddPoints(1);
                    _grid.Left(gameObject);                   
                    break;
                case "gem2":
                    _Points.AddPoints(2);
                    _grid.Left(gameObject);
                    break;
                case "gem3":
                    _Points.AddPoints(3);
                    _grid.Left(gameObject);
                    break;
                case "dirt":
                    _grid.Left(gameObject);
                    break;
                case "finish":
                    GameObject.FindGameObjectWithTag("LevelSpawner").GetComponent<SpawnScript>().NextLevel();
                    break;
                case "boulder":
                    if(_grid.CheckTile(location[0] - 2, location[1]) == null)
                    {
                        target.GetComponent<FallingScript>().Left();
                        _grid.Left(gameObject);
                    }
                    
                    break;
                default:
                    break;
            }
        }
    }

    public void Right()
    {
        int[] location = _grid.findObject(gameObject);
        GameObject target = _grid.CheckTile(location[0] + 1, location[1]);
        if (target == null)
        {
            _grid.Right(gameObject);
        }
        else
        {
            switch (target.tag)
            {
                case "gem":
                    _Points.AddPoints(1);
                    _grid.Right(gameObject);
                    break;
                case "gem2":
                    _Points.AddPoints(2);
                    _grid.Right(gameObject);
                    break;
                case "gem3":
                    _Points.AddPoints(3);
                    _grid.Right(gameObject);
                    break;
                case "dirt":
                    _grid.Right(gameObject);
                    break;
                case "finish":
                    GameObject.FindGameObjectWithTag("LevelSpawner").GetComponent<SpawnScript>().NextLevel();
                    break;
                case "boulder":
                    if (_grid.CheckTile(location[0] + 2, location[1]) == null)
                    {
                        target.GetComponent<FallingScript>().right();
                        _grid.Right(gameObject);
                    }

                    break;
                default:
                    break;
            }
        }
    }
   */
}

/* grid Up();
 * direction
 * Grid seedirection();
 */