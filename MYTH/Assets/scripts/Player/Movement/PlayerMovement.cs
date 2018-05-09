using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    private Grid _grid;
    private FallingScript _boulderFall;
    private SpawnScript _Points;
    private MoveAndTimer moveTimer;
    private float speed = 2.3f;

    void Start()
    {
       _Points = GameObject.FindGameObjectWithTag("LevelSpawner").GetComponent<SpawnScript>();
       moveTimer = gameObject.AddComponent<MoveAndTimer>();
    }
      
    public void SetGrid(Grid grid)
    {
        _grid = grid;
    }
    public void UpDown(string direction)
    {
        if(moveTimer.done)
        {
            Vector2 location = _grid.findLocation(gameObject);
            Vector2 targetLocation;
            switch (direction)
            {
                case "up":
                    targetLocation = new Vector2(0, 1);
                    break;
                case "down":
                    targetLocation = new Vector2(0, -1);
                    break;
                default:
                    targetLocation = new Vector2(1, 1);
                    break;
            }
            GameObject target = _grid.CheckTile(location + targetLocation);
            if (target == null)
            {
                _grid.MoveRelative(targetLocation, gameObject);
                moveTimer.Move(location, location + targetLocation, speed);
            }
            else
            {
                switch (target.tag)
                {
                    case "gem":
                        _Points.AddPoints(1);
                        _grid.MoveRelative(targetLocation, gameObject);
                        moveTimer.Move(location, location + targetLocation, speed);
                        break;
                    case "gem2":
                        _Points.AddPoints(2);
                        _grid.MoveRelative(targetLocation, gameObject);
                        moveTimer.Move(location, location + targetLocation, speed);
                        break;
                    case "gem3":
                        _Points.AddPoints(3);
                        _grid.MoveRelative(targetLocation, gameObject);
                        moveTimer.Move(location, location + targetLocation, speed);
                        break;
                    case "dirt":
                        _grid.MoveRelative(targetLocation, gameObject);
                        moveTimer.Move(location, location + targetLocation, speed);
                        break;
                    case "finish":
                        GameObject.FindGameObjectWithTag("LevelSpawner").GetComponent<SpawnScript>().NextLevel();
                        break;
                    default:
                        break;
                }
            }
        }
    }
    public void LeftRight(string direction)
    {
        if (moveTimer.done)
        {
            Vector2 location = _grid.findLocation(gameObject);
            Vector2 targetLocation;
            switch (direction)
            {
                case "right":
                    targetLocation = new Vector2(1, 0);
                    break;
                case "left":
                    targetLocation = new Vector2(-1, 0);
                    break;
                default:
                    targetLocation = new Vector2(1, 1);
                    break;
            }
            GameObject target = _grid.CheckTile(location + targetLocation);
            if (target == null)
            {
                _grid.MoveRelative(targetLocation, gameObject);
                moveTimer.Move(location, location + targetLocation, speed);
            }
            else
            {
                switch (target.tag)
                {
                    case "gem":
                        _Points.AddPoints(1);
                        _grid.MoveRelative(targetLocation, gameObject);
                        moveTimer.Move(location, location + targetLocation, speed);
                        break;
                    case "gem2":
                        _Points.AddPoints(2);
                        _grid.MoveRelative(targetLocation, gameObject);
                        moveTimer.Move(location, location + targetLocation, speed);
                        break;
                    case "gem3":
                        _Points.AddPoints(3);
                        _grid.MoveRelative(targetLocation, gameObject);
                        moveTimer.Move(location, location + targetLocation, speed);
                        break;
                    case "dirt":
                        _grid.MoveRelative(targetLocation, gameObject);
                        moveTimer.Move(location, location + targetLocation, speed);
                        break;
                    case "finish":
                        GameObject.FindGameObjectWithTag("LevelSpawner").GetComponent<SpawnScript>().NextLevel();
                        break;
                    case "boulder":
                        if (_grid.CheckRelativeTile(gameObject, targetLocation * 2) == null)
                        {
                            target.GetComponent<FallingScript>().Move(targetLocation);
                            _grid.MoveRelative(targetLocation, gameObject);
                            moveTimer.Move(location, location + targetLocation, speed);
                        }

                        break;
                    default:
                        break;
                }
            }
        }
    }
}