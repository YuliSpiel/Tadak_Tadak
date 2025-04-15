using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SignLine : MonoBehaviour
{
    [SerializeField] private float duration;
    [FormerlySerializedAs("ratio")] public float shrinkRatio;
    public void StartShirink()
    {
        StartCoroutine(ShrinkRoutine());
    }

    private IEnumerator ShrinkRoutine()
    {
        float elapsed = 0f;
        Vector3 startScale = transform.localScale;
        Vector3 targetScale = startScale * shrinkRatio;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsed / duration);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
