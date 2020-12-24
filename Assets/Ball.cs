using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private float maxSpeed = 40f;

    private float _direction;
    float _power = -2f;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void GetSmash()
    {

        _rigidbody2D.AddForce(new Vector2(_power,_direction) * 40, ForceMode2D.Impulse);
    }

    public void SmashIntensity(SmashDirection direction, SmashPower power)
    {
        switch (direction)
        {
            case SmashDirection.North:
                _direction = 20f;
                break;
            case SmashDirection.South:
                _direction = -20f;
                break;
        }
        
        switch (power)
        {
            case SmashPower.Weak:
                _power = -1f;
                break;
            case SmashPower.Medium:
                _power = -20f;
                break;
            case SmashPower.Strong:
                _power = -40f;
                break;
        }
        
        GetSmash();
    }

    private void FixedUpdate()
    {
        if(_rigidbody2D.velocity.magnitude > 40f)
        {
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * maxSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        /*if (_rigidbody2D.velocity.x > - 10)
            _rigidbody2D.velocity += new Vector2(-10, _rigidbody2D.velocity.y);*/
    }
}