using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollows : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectToFollow;

    private Vector3 distacne;
    // Use this for initialization
    void Start()
    {
        distacne = this.transform.position - _objectToFollow.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = distacne + _objectToFollow.transform.position;

    }
}