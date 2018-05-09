using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private GameObject[,] _gameArray;
    // Use this for initialization
    public void ManualStart(int width, int height)
    {
         _gameArray = new GameObject[width, height];
    }

    public Vector2 findLocation(GameObject obj)
    {
        Vector2 result = new Vector2(-1, -1);
        for (int x = 0; x < _gameArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gameArray.GetLength(1); y++)
            {
                if (_gameArray[x,y] == obj)
                {
                    result.x = x;
                    result.y = y;
                }
            }
        }
        return result;
    }

    public GameObject CheckTile(int x, int y)
    {
        return _gameArray[x, y];
    }

    public GameObject CheckTile(Vector2 loc)
    {
        return _gameArray[(int)loc.x, (int)loc.y];
    }

    public GameObject CheckRelativeTile(GameObject obj, int x, int y)
    {
        Vector2 location = findLocation(obj);
        return _gameArray[(int)location.x + x, (int)location.y + y];
    }

    public bool checkIfEmpty(int x, int y)
    {
        return _gameArray[x, y] == null;
    }

    public void addToGrid(GameObject obj, int x, int y)
    {
        _gameArray[x, y] = obj;
    }

    //moves the GameObject obj to _gameArray[x,y]
    public bool Move(int x, int y, GameObject obj)
    {
        if (0 < x && x < _gameArray.GetLength(0) && 0 < y && y < _gameArray.GetLength(1))
        {
            Vector2 location = findLocation(obj);
            Destroy(CheckTile(x, y));
            _gameArray[x, y] = obj;
            _gameArray[(int)location.x, (int)location.y] = null;
            return true;
        }
        return false;
    }
    public bool Move(Vector2 loc, GameObject obj)
    {
        if (0 < loc.x && loc.x < _gameArray.GetLength(0) && 0 < loc.y && loc.y < _gameArray.GetLength(1))
        {
            Vector2 location = findLocation(obj);
            Destroy(CheckTile(loc));
            _gameArray[(int)loc.x, (int)loc.y] = obj;
            _gameArray[(int)location.x, (int)location.y] = null;
            return true;
        }
        return false;
    }

    public bool InArray(int x, int y)
    {
        return 0 < x && x < _gameArray.GetLength(0) && 0 < y && y < _gameArray.GetLength(1);
    }

    public bool InArray(Vector2 loc)
    {
        return 0 < loc.x && loc.x < _gameArray.GetLength(0) && 0 < loc.y && loc.y < _gameArray.GetLength(1);
    }
    /*
    public void Up(GameObject obj)
    {
        print("does it work");
        int[] location = findObject(obj);
        Destroy(CheckTile(location[0], location[1] + 1));
        _gameArray[location[0], location[1] + 1] = obj;
        _gameArray[location[0], location[1]] = null;
        obj.transform.Translate(0, 1, 0);
    }

    public void Down(GameObject obj)
    {
        int[] location = findObject(obj);
        Destroy(CheckTile(location[0], location[1] - 1));
        _gameArray[location[0], location[1] - 1] = obj;
        _gameArray[location[0], location[1]] = null;
        obj.transform.Translate(0, -1, 0);
    }
    
    public void Left(GameObject obj)
    {
        int[] location = findObject(obj);
        Destroy(CheckTile(location[0] - 1, location[1]));
        _gameArray[location[0] - 1, location[1]] = obj;
        _gameArray[location[0], location[1]] = null;
        obj.transform.Translate(-1, 0, 0);
    }

    public void Right(GameObject obj)
    {

        int[] location = findObject(obj);
        Destroy(CheckTile(location[0] + 1, location[1]));
        _gameArray[location[0] + 1, location[1]] = obj;
        _gameArray[location[0], location[1]] = null;
        obj.transform.Translate(1, 0, 0);
    }
    */

    // destroy array and every thing in it
    public void SelfDestruct()
    {
        for(int x = 0; x < _gameArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gameArray.GetLength(1); y++)
            {
                Destroy(CheckTile(x, y));
            }
        }

        Destroy(gameObject);
    }
    /*
    public void MoveInDirection(string direction, GameObject obj)
    {
        switch(direction)
        {
            case "up":
                Up(obj);
                break;
            case "down":
                Down(obj);
                break;
            case "left":
                Left(obj);
                break;
            case "right":
                Right(obj);
                break;
            default:
                break;
        }
    }
    */
}
