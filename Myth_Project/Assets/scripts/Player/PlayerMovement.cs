using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    [SerializeField]
    private Grid _grid;
    private FallingScript _boulderFall;

    private void Start()
    {
        
    }
    public void SetGrid(Grid grid)
    {
    
        _grid = grid;
    }

    public void Up()
    {
        int[] location = _grid.findObject(gameObject);
        print(location[0] + "x y" + location[1]);
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
                //score++
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
                //score++
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
                //score++
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
                //score++
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
}
