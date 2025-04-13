using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitPaper : MonoBehaviour, IExecutable
{
    private GameObject currentPaper;
    


    private Animator paper_anim;
    
    
    private GameObject leftHand;
    private Animator anim_leftHand;
    
    void Start()
    {
        leftHand = this.gameObject;
        anim_leftHand = leftHand.GetComponent<Animator>();
    }

    public void Execute()
    {
        //종이 제출
        //종이 상태 -> 그려지는 중이면 -> throw tear
        //종이 상태 -> 그 외 -> throw
        
        ThrowPaper();
        
        
        
    }

    private void ThrowPaper()
    {
        
        
        anim_leftHand.SetTrigger("ThrowPaper");
        
    }
}
