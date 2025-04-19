using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BonusPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat"))
        {
            SoundManager.Instance.PlaySFX(ESFXs.Cat3SFX);
            SoundManager.Instance.PlaySFX(ESFXs.GrowSFX);

            GameManager.Instance.Score += 5;
            Destroy(gameObject);
        }
    }
}
