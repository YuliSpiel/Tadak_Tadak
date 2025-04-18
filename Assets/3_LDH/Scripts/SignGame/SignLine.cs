using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SignLine : MonoBehaviour
{
    [SerializeField] private float duration;
    public float shrinkRatio;

    public bool IsComplete { get; private set; } = false;
    private Animator anim_signLine;

    private void Start()
    {
        anim_signLine = GetComponent<Animator>();
    }

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


    private void OnSignCompelte()
    {
        IsComplete = true;
        PaperStatus paper = GetComponentInParent<PaperStatus>();
        if (paper != null)
        {
            paper.State = PaperState.Signed;
            Debug.Log($"사인 끝났나? : {IsComplete}, paper 상태 : {paper.State.ToString()}");
        }
    }


    public void ForceStopDrawing()
    {
        if (!IsComplete)
        {
            anim_signLine.speed = 0f; // 애니메이션 즉시 정지
        }
    }
}
