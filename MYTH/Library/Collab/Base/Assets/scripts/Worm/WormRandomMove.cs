using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormRandomMove : MonoBehaviour
{

    private CollisionStorage _colStorage;


    [SerializeField]
    private Grid _grid;

    private void Start()
    {
        _colStorage = new CollisionStorage();
    }

    public void Move(int _moveDir)
    {
        switch (_moveDir)
        {
            case 1:
                if (Neighbour(0, 1) == null || !_colStorage.CheckTags(Neighbour(0, 1).tag))
                {
                    _grid.Move(_grid.findLocation(gameObject) + new Vector2(0, 1), gameObject);
                }
                return;

            case 2:
                if (Neighbour(-1, 0) == null || !_colStorage.CheckTags(Neighbour(-1, 0).tag))
                {
                    _grid.Move(_grid.findLocation(gameObject) + new Vector2(-1, 0), gameObject);
                }
                return;

            case 3:
                if (Neighbour(1, 0) == null || !_colStorage.CheckTags(Neighbour(1, 0).tag))
                {
                    _grid.Move(_grid.findLocation(gameObject) + new Vector2(1, 0), gameObject);
                }
                return;

            case 4:
                if (Neighbour(0, -1) == null || !_colStorage.CheckTags(Neighbour(0, -1).tag))
                {
                    _grid.Move(_grid.findLocation(gameObject) + new Vector2(0, -1), gameObject);
                }
                return;
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
