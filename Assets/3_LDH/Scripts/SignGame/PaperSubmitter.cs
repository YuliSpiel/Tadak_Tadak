using System.Collections;
using System.Collections.Generic;
using MiniGame;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
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
    }

    public void Execute()
    {
        OnSubmit();
    }

    private void OnSubmit()
    {
        if (isSubmitting)
        {
            Debug.Log("제출 중인 상태입니다.");
            return;
        }

        isSubmitting = true;
        //왼손 애니메이션 실행
        anim_leftHand.SetTrigger("SubmitPaper");
        
        //종이(현재 종이) 제출 애니메이션 실행
        SignMiniGame.Manager.CurrentPaper.GetComponent<Animator>().SetTrigger("Submit");
        
    }
    
    private void OnSubmitAnimationEnd()
    {
        isSubmitting = false;
    }

}
