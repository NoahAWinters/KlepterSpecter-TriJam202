using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody2D _rb;
    Controls _controls;
    [SerializeField] float _moveSpeed;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _controls = Controls.GetInstance();
    }


    void FixedUpdate()
    {
        Vector2 movement = new Vector2(_controls.MoveX, _controls.MoveY) * _moveSpeed;
        _rb.velocity = (movement).normalized * _moveSpeed;
    }
}
