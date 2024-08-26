using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _floatingJoysitck;
    [SerializeField] private float _speed = 1;
    [SerializeField] private PlayerAnimationController _playerAnimation;
    private Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Math.Abs(_floatingJoysitck.Horizontal) > Math.Abs(_floatingJoysitck.Vertical))
        {
            _rb.velocity = new Vector2(_floatingJoysitck.Horizontal * Time.deltaTime * _speed, 0);
            if (_floatingJoysitck.Horizontal > 0)
            {
                _playerAnimation.RightWalk();
            }
            else if (_floatingJoysitck.Horizontal < 0)
            {
                _playerAnimation.LeftWalk();
            }
            else
            {
                _playerAnimation.Idle();
            }
        }
        else if (Math.Abs(_floatingJoysitck.Horizontal) < Math.Abs(_floatingJoysitck.Vertical))
        {
            _rb.velocity = new Vector2(0, _floatingJoysitck.Vertical * Time.deltaTime * _speed);
            if (_floatingJoysitck.Vertical > 0)
            {
                _playerAnimation.UpWalk();
            }
            else if (_floatingJoysitck.Vertical < 0)
            {
                _playerAnimation.DownWalk();
            }
            else
            {
                _playerAnimation.Idle();
            }
        }
        else
        {
            _rb.velocity = Vector2.zero;
            _playerAnimation.Idle();
        }

    }
}
