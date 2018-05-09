using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollows : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectToFollow;

    private Vector3 distance;
    // Use this for initialization
    void Start()
    {
        distance = this.transform.position - _objectToFollow.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = distance + _objectToFollow.transform.position;

    }
}