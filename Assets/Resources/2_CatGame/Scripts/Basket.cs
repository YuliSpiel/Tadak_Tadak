using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public float speed;
    private int _moveDir;
    private bool _isChecked;
    private bool _isOnLeftBorder;
    private bool _isOnRightBorder;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(_moveDir, 0) * speed;
    }

    void Update()
    {
        CheckBorder();
        GetDirection();
    }

    void GetDirection()
    {
        _moveDir = 0;
        
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            _moveDir = 0;
            return;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (_isOnLeftBorder)
            {
                return;
            }

            _moveDir = -1;
            
            if (_isOnRightBorder)
            {
                _isOnRightBorder = false;
            }

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (_isOnRightBorder)
            {
                return;
            }

            _moveDir = 1;
            
            if (_isOnLeftBorder)
            {
                _isOnLeftBorder = false;
            }

        }

        // if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        // {
        //     _moveDir = 0;
        // }
    }

    void CheckBorder()
    {
        if (_isOnLeftBorder || _isOnRightBorder)
        {
            return;
        }

        if (transform.position.x > 6.25)
        {
            _isOnRightBorder = true;
            _moveDir = 0;
        }
        
        if (transform.position.x < -6.25)
        {
            _isOnLeftBorder = true;
            _moveDir = 0;
        }
    }
}
