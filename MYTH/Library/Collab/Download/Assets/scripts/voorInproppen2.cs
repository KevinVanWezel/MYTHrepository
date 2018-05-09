﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voorInproppen2 : MonoBehaviour
{
    private HandleTextFile _handleTextFile;
    private int _currentLevel;
    private string[] levels;
    private GameObject _grid;
    public static int _Points = 0;

    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private GameObject _wallPrefab;
    [SerializeField]
    private GameObject _boulderPrefab;
    [SerializeField]
    private GameObject _dirtPrefab;
    [SerializeField]
    private GameObject _finishPrefab;
    [SerializeField]
    private GameObject _gemPrefab1;
    [SerializeField]
    private GameObject _gemPrefab2;
    [SerializeField]
    private GameObject _gemPrefab3;
    [SerializeField]
    private GameObject _wormPrefab;
    [SerializeField]
    private Follow _camera;


    // Use this for initialization
    void Start()
    {
        _currentLevel = 0;
        _handleTextFile = GetComponent<HandleTextFile>();
        levels = _handleTextFile.ReadString("Assets/levels/levels.txt").Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        SetLevel(_currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        print(_Points);
    }

    public void SetLevel(int levelNumber)
    {
        GameObject tmp = null;
        string[] level = _handleTextFile.ReadString("Assets/levels/" + levels[levelNumber % levels.Length]).Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        if (_grid)
        {
            _grid.GetComponent<Grid>().SelfDestruct();
        }
        _grid = new GameObject();
        _grid.AddComponent<Grid>();
        _grid.GetComponent<Grid>().ManualStart(level[0].Length, level.Length);

        for (int y = 0; y < level.Length; y++)
        {
            for (int x = 0; x < level[y].Length; x++)
            {
                switch (level[level.Length - 1 - y][x].ToString())
                {
                    case "S":
                        tmp = GameObject.Instantiate(_playerPrefab);
                        tmp.GetComponent<PlayerMovement>().SetGrid(_grid.GetComponent<Grid>());
                        _camera._objectToFollow = tmp;
                        break;
                    case "W":
                        tmp = GameObject.Instantiate(_wallPrefab);
                        break;
                    case "B":
                        tmp = GameObject.Instantiate(_boulderPrefab);
                        tmp.GetComponent<FallingScript>().SetGrid(_grid.GetComponent<Grid>());
                        break;
                    case "D":
                        tmp = GameObject.Instantiate(_dirtPrefab);
                        break;
                    case "F":
                        tmp = GameObject.Instantiate(_finishPrefab);
                        break;
                    case "G":
                        int _RandomGem = UnityEngine.Random.Range(1, 4);
                        if (_RandomGem == 1)
                        {
                            tmp = GameObject.Instantiate(_gemPrefab1);
                            tmp.GetComponent<FallingScript>().SetGrid(_grid.GetComponent<Grid>());
                        }
                        if (_RandomGem == 2)
                        {
                            tmp = GameObject.Instantiate(_gemPrefab2);
                            tmp.GetComponent<FallingScript>().SetGrid(_grid.GetComponent<Grid>());
                        }
                        if (_RandomGem == 3)
                        {
                            tmp = GameObject.Instantiate(_gemPrefab3);
                            tmp.GetComponent<FallingScript>().SetGrid(_grid.GetComponent<Grid>());
                        }
                        break;
                    case "*":
                        tmp = GameObject.Instantiate(_wormPrefab);
                        break;
                    default:
                        tmp = null;
                        break;

                }
                _grid.GetComponent<Grid>().addToGrid(tmp, x, y);
                if (tmp)
                {
                    _grid.GetComponent<Grid>().CheckTile(x, y).transform.Translate(new Vector3(x, y, 0));
                }
            }
        }
    }

    public void NextLevel()
    {
        _currentLevel++;
        _currentLevel %= levels.Length;
        SetLevel(_currentLevel);
    }

    public void PreviousLevel()
    {
        _currentLevel += levels.Length - 1;
        _currentLevel %= levels.Length;
        SetLevel(_currentLevel);
    }
    public void AddPoints(int multiply)
    {
        _Points += multiply;
    }
}
