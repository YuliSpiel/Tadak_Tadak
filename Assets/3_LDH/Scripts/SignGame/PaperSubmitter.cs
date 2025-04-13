using System.Collections;
using System.Collections.Generic;
using MiniGame;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 종이를 제출
/// </summary>
public class PaperSubmitter : MonoBehaviour, IExecutable
{
    private GameObject leftHand;
    private Animator anim_leftHand;
    
    void Start()
    {
        leftHand = this.gameObject;
        anim_leftHand = leftHand.GetComponent<Animator>();
    }

    public void Execute()
    {
        OnSubmit();
    }

    private void OnSubmit()
    {
        //왼손 애니메이션 실행
        anim_leftHand.SetTrigger("SubmitPaper");
        
        //종이(현재 종이) 제출 애니메이션 실행
        SignMiniGame.Manager.CurrentPaper.GetComponent<Animator>().SetTrigger("Submit");
        
    }
}
