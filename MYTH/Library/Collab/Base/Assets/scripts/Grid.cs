using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private int _width = 10;
    private int _height = 10;
    private GameObject[,] _gameArray;
    // Use this for initialization
    void Start()
    {
        _gameArray = new GameObject[10,10];
        for (int x = 0; x < _gameArray.GetLength(0)/*_gameArray.Length*/; x++)
        {
            for (int y = 0; y < _gameArray.GetLength(1)/*_gameArray[x].Length*/; y++)                                                                                                                                                       //pranked                           
            {
                _gameArray[x,y] = null;
            }
        }
    }
	
	// Update is called once per frame
	void Update()
    {
		
	}

    public int[] findSelf(GameObject self)
    {
        int[] result = { -1, -1 };
        for (int x = 0; x < _gameArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gameArray.GetLength(1); y++)
            {
                if (_gameArray[x,y] == self)
                {
                    result[0] = x;
                    result[1] = y;
                }
            }
        }
        return result;
    }

    //public int findSelfX(GameObject self)
    //{
    //    for (int i = 0; i < _gameArray.Length; i++)
    //    {
    //        for (int j = 0; j < _gameArray[i].Length; j++)
    //        {
    //            if (_gameArray[i][j] == self)
    //            {
    //                return i;
    //            }
    //        }
    //    }
    //    return -1;
    //}
    //
    //public int findSelfY(GameObject self)
    //{
    //    for (int i = 0; i < _gameArray.Length; i++)
    //    {
    //        for (int j = 0; j < _gameArray[i].Length; j++)
    //        {
    //            if (_gameArray[i][j] == self)
    //            {
    //                return j;
    //            }
    //        }
    //    }
    //    return -1;
    //}

    public GameObject checkTile(int x, int y)
    {
        return _gameArray[x,y];
    }
}
