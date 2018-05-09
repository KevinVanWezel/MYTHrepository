using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{
    private WormDirChange _directedMove;
    private WormRandomMove _randomMove;


    private Grid _grid;
    private int _steps;
    private int _moveDir;
    private bool _timerState;

    [SerializeField]
    private int _timerTime;

    private void Start()
    {
        _randomMove = GetComponent<WormRandomMove>();
        _directedMove = GetComponent<WormDirChange>();

    }

    void Update()
    {
        if (_timerState == false)
        {
            StartCoroutine(Randomizer());
        }

    }

    IEnumerator Randomizer()
    {
        _timerState = true;

        _steps = Random.Range(1, 5);
        //_moveDir = Random.Range(1, 4);

        for (int i = 0; i < _steps; i++)
        {
            _randomMove.Move(Random.Range(1, 5));
        }

        yield return new WaitForSeconds(_timerTime);
        _timerState = false;
    }

    public void SetGrid(Grid grid)
    {
        _grid = grid;

    }


    IEnumerator Directed()
    {
        _timerState = true;
        yield return new WaitForSeconds(_timerTime);
        _directedMove.DirectedMove();
        _timerState = false;
    }
}