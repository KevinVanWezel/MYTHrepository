using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float _startTime
    {
        get { return _startTime; }
        private set { _startTime = value; }
    }
    private float _endTime;

    void Start()
    {
        Restart();
    }

    public void Restart()
    {
        _startTime = Time.time;
    }

    public void SetTimer(float time)
    {
        Restart();
        _endTime = _startTime + Mathf.Abs(time);
    }

    public float GetPercentile()
    {
        return Mathf.Min((Time.time - _startTime) / (_endTime - _startTime), 1);
    }

    public bool done()
    {
        return _endTime < Time.time;
    }

    public float timeLeft()
    {
        return _endTime - Time.time;
    }
}
