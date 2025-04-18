using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private Rigidbody2D _rb;
    public bool isActive; // 스폰되고, 쌓이기 전까지. 떨어지면 다시 active
    private bool _isOnceStacked;
    
    public float catDropDrag;
    public float catDropGravity;
    public float catStaticDrag;
    public float catStaticGravity;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.WakeUp();
        isActive = false;
    }
    
    private void OnEnable()
    {
        isActive = true;
        FreezeY();
    }

    void Update()
    {
        if (isActive)
        {
            if (_rb != null && Input.GetKeyDown(KeyCode.LeftShift))
            {
                Drop();
            }

            if (transform.position.y < -6)
            {
                SoundManager.Instance.PlaySFX(ESFXs.Cat2SFX);
                LosePoint();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Basket"))
        {
            if (!_isOnceStacked)
            {
                SoundManager.Instance.PlaySFX(ESFXs.Cat1SFX);
            }
            isActive = false;
            _isOnceStacked = true;
            _rb.gravityScale = 3f;
            _rb.drag =  1f;
        }
        
        else if (collision.gameObject.CompareTag("Cat"))
        {
            if (!_isOnceStacked)
            {
                SoundManager.Instance.PlaySFX(ESFXs.Cat1SFX);
            }
            isActive = false;
            _isOnceStacked = true;
            _rb.gravityScale = catStaticGravity;
            _rb.drag = catStaticDrag;
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Basket"))
        {
            isActive = true;
        }
        
        else if (collision.gameObject.CompareTag("Cat"))
        {
            isActive = true;
        }
    }

    public void FreezeY()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public void Drop()
    {
        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.gravityScale = catDropGravity;
        _rb.drag =  catDropDrag;
        _rb.AddForce(Vector2.down * 0.1f, ForceMode2D.Force);
    }

    void LosePoint()
    {
        isActive = false;
        GameManager.Instance.Life--;
    }
    
    // 고양이가 inactive되는 상황 -> 다음 고양이 스폰
    // y pos < -6일때
    // 다른 고양이와 충돌했을 때
    
    // '탑쌓기' 생각해보면, 받침대에 안착하고, 그 위에 떨어지고.... 이런 느낌인데 그럼 콜라이더를 직사각형으로 하면 될까?
}
