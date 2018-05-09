using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndTimer : MonoBehaviour
{
    private GameObject objectToMove;
    public Vector3 startLocation;
    public Vector3 endLocation;
    public float moveSpeed;
    private float startTime;
    private float journeyLength;

    public bool done
    {
        get;
        private set;
    }
    

    void Start()
    {
        moveSpeed = 200;
        startTime = Time.time;
        startLocation = transform.position;
        endLocation = transform.position;
        journeyLength = 1;
        done = true;
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * moveSpeed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startLocation, endLocation, fracJourney);
        done = fracJourney > 1;
    }

    public void Move(Vector3 start, Vector3 end, float speed)
    {
        done = false;
        startLocation = start;
        endLocation = end;
        moveSpeed = speed;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startLocation, endLocation);
    }
}
