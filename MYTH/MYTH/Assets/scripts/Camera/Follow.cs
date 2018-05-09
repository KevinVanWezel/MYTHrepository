using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject _objectToFollow;
    private Vector3 distance;
    
    private void Start()
    {
        distance = new Vector3(0, 0, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        if(_objectToFollow)
        {
            gameObject.transform.position = distance + _objectToFollow.transform.position;
        }

    }
}