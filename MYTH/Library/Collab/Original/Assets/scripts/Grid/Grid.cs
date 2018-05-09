using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private string up, down, left, right;
    private GameObject[,] _gameArray;
    // Use this for initialization
    public void ManualStart(int width, int height)
    {
         _gameArray = new GameObject[width, height];
    //          for (int x = 0; x < _gameArray.GetLength(0); x++)
    //              {
    //                  for (int y = 0; y < _gameArray.GetLength(1); y++)                                                                                                                                                       //pranked                           
    //                      {
    //                          //_gameArray[x,y] = null;
    //                      }
    //    }
    }

    public int[] findObject(GameObject obj)
    {
        int[] result = { -1, -1 };
        for (int x = 0; x < _gameArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gameArray.GetLength(1); y++)
            {
                if (_gameArray[x,y] == obj)
                {
                    result[0] = x;
                    result[1] = y;
                }
            }
        }
        return result;
    }

    public GameObject CheckTile(int x, int y)
    {
        return _gameArray[x, y];
    }

    public GameObject CheckRelativeTile(GameObject obj, int x, int y)
    {
        int[] location = findObject(obj);
        return _gameArray[location[0] + x, location[1] + y];
    }

    public bool checkIfEmpty(int x, int y)
    {
        return _gameArray[x, y] == null;
    }

    public void addToGrid(GameObject obj, int x, int y)
    {
        _gameArray[x, y] = obj;
    }

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

    public void DirectionCheck(string direction)
    {
        if (direction == "up")
        {
            Up(gameObject);
        }
        else if (direction == "down")
        {
            Down(gameObject);
        }
        else if (direction == "left")
        {
            Left(gameObject);
        }
        else if (direction == "right")
        {
            Right(gameObject);
        }
    }
}
