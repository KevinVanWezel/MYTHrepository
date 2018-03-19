using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _x;
    private float _y;

    [SerializeField]
    private Rigidbody2D _rb;

    [SerializeField]
    private float _initialMoveSpeed;

    private float _moveSpeed;


    private void Start()
    {
        _moveSpeed = _initialMoveSpeed;
    }

    private void Move(float x, float y)
    {
        _rb.velocity = new Vector2(x, y).normalized * _moveSpeed * Time.deltaTime;
    }

    private void Update()
    {
        _x = Input.GetAxisRaw("Horizontal");
        _y = Input.GetAxisRaw("Vertical");
             
        Move(_x, _y);
      
    }
}