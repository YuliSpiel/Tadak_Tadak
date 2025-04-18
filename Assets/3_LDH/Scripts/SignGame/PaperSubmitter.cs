using System.Collections;
using System.Collections.Generic;
using MiniGame;
using UnityEngine;

/// <summary>
/// 종이를 제출
/// </summary>
public class PaperSubmitter : MonoBehaviour, IExecutable
{
    private GameObject leftHand;
    private Animator anim_leftHand;
    private bool isSubmitting;
    
    void Start()
    {
        leftHand = this.gameObject;
        anim_leftHand = leftHand.GetComponent<Animator>();
        isSubmitting = false;

        SignMiniGame.Manager.OnTurnInit -= OnSubmitEnd;
        SignMiniGame.Manager.OnTurnInit += OnSubmitEnd;
    }

    public void Execute()
    {
        if (isSubmitting)
        {
            Debug.Log("제출 중인 상태입니다.");
            return;
        }
        isSubmitting = true;
        ExecuteSubmission();
        
    }

    private void ExecuteSubmission()
    {
        //왼손 애니메이션 실행
        anim_leftHand.SetTrigger("SubmitPaper");
        
        //종이(현재 종이) 제출 애니메이션 실행
        PaperStatus paperStatus = SignMiniGame.Manager.CurrentPaper.GetComponent<PaperStatus>();
        if (paperStatus.State== PaperState.Signing)
        {
            paperStatus.State = PaperState.Torn;
        }
        paperStatus.GetComponent<Animator>().SetTrigger("Submit");
        
    }
    
    private void OnSubmitEnd()
    {
        isSubmitting = false;
    }
    
    
}
