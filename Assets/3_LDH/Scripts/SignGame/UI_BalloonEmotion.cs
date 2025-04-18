using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MiniGame;
using UnityEngine.Serialization;
using Utils;

public class UI_BalloonEmotion : MonoBehaviour
{
    private Image balloonUI;
    private Animator anim_emotion;
    private RectTransform balloonRect;
    
    [Header("Effect Control")]
    [SerializeField] private float startAnchorPosX = 800f;
    private float anchorPosY;
    [SerializeField] private float effectTime = 0.3f;
    
    //Position
    private Vector2 startPos;
    private Vector2 middlePos;
    private Vector2 endPos;
    
    
    //animation call back
    private Action onEmotionAnimCompleteCallback;
    
    
    private void Awake()
    {
        balloonUI = GetComponent<Image>();
        balloonRect = GetComponent<RectTransform>();
        anim_emotion = GetComponent<Animator>();
        
        
        anchorPosY = balloonRect.anchoredPosition.y;
        startPos = new Vector2(startAnchorPosX, anchorPosY);
        middlePos = new Vector2(0f, anchorPosY);
        endPos = new Vector2(-startAnchorPosX, anchorPosY);
        
        
    }

    private void Start()
    {
        SignMiniGame.Manager.OnTurnInit -= GuestEnter;
        SignMiniGame.Manager.OnTurnInit += GuestEnter;
        SignMiniGame.Manager.OnPaperSubmitted -= ShowResult;
        SignMiniGame.Manager.OnPaperSubmitted += ShowResult;
        
        
        GuestEnter();
    }

    private void OnDestroy()
    {
        if (SignMiniGame.Manager != null)
        {
            SignMiniGame.Manager.OnTurnInit -= GuestEnter;
            SignMiniGame.Manager.OnPaperSubmitted -= ShowResult;
        }
     

    }

    private void ShowResult(bool isSuccess)
    {
        ChangeEmotion(isSuccess, GuestExit);
    }
    
    

    private void GuestEnter()
    {
        gameObject.SetActive(true);
        //오른쪽 바깥 위치에서 시작
        balloonRect.anchoredPosition = startPos;
        
        //fade effect 시작
        StartCoroutine(Util.Fade(balloonUI, 0f, 1f, effectTime));
        
        //Dotween으로 이동 처리
        balloonRect.DOAnchorPos(middlePos, effectTime).SetEase(Ease.OutExpo); //부드럽게 감속하며 도착
    }

    private void GuestExit()
    {
        //fade effect 시작
        StartCoroutine(Util.Fade(balloonUI, 1f, 0f, effectTime));
        //Dotween으로 이동 처리
        balloonRect.DOAnchorPos(endPos, effectTime).SetEase(Ease.InExpo).OnComplete(() =>
        {
            ResetEmotion();
            gameObject.SetActive(false);
        }); //부드럽게 감속하며 도착, dotween 애니메이션 종료 후 애니메이션 초기화, 비활성화 처리

    }

    public void ChangeEmotion(bool isSuccess, Action onComplete = null)
    {
        onEmotionAnimCompleteCallback = onComplete;
        if (isSuccess)
        {
            anim_emotion.SetInteger("Result", 1);
            SoundManager.Instance.PlaySFX(ESFXs.GrowSFX);
        }
        else
        {
            anim_emotion.SetInteger("Result", -1);
            SoundManager.Instance.PlaySFX(ESFXs.FailSFX);
        }
    }

    public void ResetEmotion()
    {
        anim_emotion.SetInteger("Result", 0);
    }

    private void OnEmotionAnimCompelte()
    {
        onEmotionAnimCompleteCallback?.Invoke();
        onEmotionAnimCompleteCallback = null; //등록 초기화
    }


    
}
