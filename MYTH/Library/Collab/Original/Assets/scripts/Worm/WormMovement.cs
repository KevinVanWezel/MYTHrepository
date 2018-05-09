using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour {

    private CollisionStorage _colStorage;

    private int _steps;
    private int _moveDir;
    private bool _timerState;


    [SerializeField]
    private Grid _grid;

    [SerializeField]
    private int _timerTime;


    private void Start()
    {
        _colStorage = new CollisionStorage();
    }

    public void SetGrid(Grid grid)
    {
        _grid = grid;
    }       

    void Update ()
    {
        if (_timerState == false)
        {
            StartCoroutine(Randomizer());
        }
       
	}

    private void Move(int _moveDir)
    {
        switch (_moveDir)
        {
            case 1:
            if (Neighbour(0, 1) == null || !_colStorage.CheckTags(Neighbour(0, 1).tag))
                {
                    _grid.Up(gameObject);
                }
                return;

            case 2:
                if (Neighbour(-1, 0) == null || !_colStorage.CheckTags(Neighbour(-1, 0).tag))
                {
                    _grid.Left(gameObject);
                }
            return;

            case 3:
                if (Neighbour(1, 0) == null || !_colStorage.CheckTags(Neighbour(1, 0).tag))
                {
                    _grid.Right(gameObject);
                }
            return;

            case 4:
                if (Neighbour(0, -1) == null || !_colStorage.CheckTags(Neighbour(0, -1).tag))
                {
                    _grid.Down(gameObject);
                }
            return;
        } 
    }

    IEnumerator Randomizer()
    {
        _timerState = true;

        _steps = Random.Range(1, 5);
        //_moveDir = Random.Range(1, 4);

        for (int i = 0; i < _steps; i++)
        {
            Move(Random.Range(1, 5));
        }

        yield return new WaitForSeconds(_timerTime);
        _timerState = false;
    }


    private GameObject Neighbour(int x, int y)
    {
        return _grid.CheckRelativeTile(gameObject, x, y);
    }
}