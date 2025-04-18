using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Utils;

public class UI_TextVisibleEffect : MonoBehaviour
{
    private TMP_Text tmPro;
    private RectTransform tmProRect;
    
    [Header("Effect Control")]
    [SerializeField] private float startAnchorPosX = 800f;
    private float anchorPosY;
    [SerializeField] private float effectTime = 0.3f;
    
    
    //Position
    private Vector2 startPos;
    private Vector2 middlePos;
    private Vector2 endPos;

    private void Awake()
    {
        tmPro = GetComponent<TMP_Text>();
        tmProRect = GetComponent<RectTransform>();
        
        anchorPosY = tmProRect.anchoredPosition.y;
        startPos = new Vector2(startAnchorPosX, anchorPosY);
        middlePos = new Vector2(0f, anchorPosY);
        endPos = new Vector2(-startAnchorPosX, anchorPosY);

    }

    private void OnEnable()
    {
        OnEffectEnter();
    }


    private void OnEffectEnter()
    {
        StartCoroutine(Util.Fade(tmPro, 0f, 1f, effectTime));
        tmProRect.DOAnchorPos(middlePos, effectTime).SetEase(Ease.OutExpo).OnComplete(OnEffectExit);
    }

    private void OnEffectExit()
    {
        StartCoroutine(Util.Fade(tmPro, 1f, 0f, effectTime));
        tmProRect.DOAnchorPos(endPos, effectTime).SetEase(Ease.InExpo);
    }
}
