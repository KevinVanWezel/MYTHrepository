using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormDirChange : MonoBehaviour
{
    [SerializeField]
    private int _initalDir;

    private enum _direction {Up, Right, Down, Left};

    private _direction _currentDir;

    private Grid _grid;
    private CollisionStorage _colStorage;


    private void Start()
    {
        _colStorage = new CollisionStorage();

        if (_initalDir == 1) 
        {
            _currentDir = _direction.Up;
            
        }
        else
        {
            _currentDir = _direction.Left;
        }
    }

    public void DirectedMove()
    {
        switch(_currentDir)
        {
            case _direction.Up:
                if (_colStorage.CheckTags(Neighbour(0, 1).tag))
                {
                    _grid.Move(_grid.findLocation(gameObject) + new Vector2(0, 1), gameObject);
                    _currentDir = _direction.Down;
                }
                break;

            case _direction.Down:
                if (_colStorage.CheckTags(Neighbour(0, -1).tag))
                {
                    _grid.Move(_grid.findLocation(gameObject) + new Vector2(0, -1), gameObject);
                    _currentDir = _direction.Up;
                }
                break;

            case _direction.Left:
                if(_colStorage.CheckTags(Neighbour(-1,0).tag))
                {
                    _grid.Move(_grid.findLocation(gameObject) + new Vector2(-1, 0), gameObject);
                    _currentDir = _direction.Right;
                }
                break;

            case _direction.Right:
                if(_colStorage.CheckTags(Neighbour(1,0).tag))
                {
                    _grid.Move(_grid.findLocation(gameObject) + new Vector2(1, 0), gameObject);
                    _currentDir = _direction.Left;
                }
                break;
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


}
