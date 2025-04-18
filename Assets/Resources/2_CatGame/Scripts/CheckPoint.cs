using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private CatGame _game;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Cat"))
        {
            Debug.Log("충돌햇서요");
            Destroy(gameObject);
            GameManager.Instance.Score += 10;
            _game.Invoke("EndGame", 2f);
        }
    }
}
