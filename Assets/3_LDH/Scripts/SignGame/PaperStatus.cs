using System;
using System.Collections;
using System.Collections.Generic;
using MiniGame;
using UnityEngine;

public enum PaperState
{
    Idle,           // 아무것도 안 하는 상태
    Signing,        // 사인 중
    Signed,         // 사인 완료
    Torn            // 찢어짐 처리됨
}


public class PaperStatus : MonoBehaviour
{
    [SerializeField] private PaperState state;
    private Animator anim_paper;
    public PaperState State
    {
        get => state;
        set
        {
            
            switch (value)
            {
                case PaperState.Idle:
                    anim_paper.SetBool("IsSigning", false);
                    break;
                case PaperState.Signing:
                    anim_paper.SetBool("IsSigning", true);
                    break;
                case PaperState.Signed:
                    anim_paper.SetBool("IsSigning", false);
                    break;
                case PaperState.Torn:
                    break;
                
                    
            }

            state = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim_paper = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSubmit()
    {
        foreach (var sign in GetComponentsInChildren<SignLine>())
        {
            if (!sign.IsComplete)
            {
                sign.ForceStopDrawing();
            }
            sign.StartShirink();
        }
        
        //종이 제출이 끝났음을 알림
        SignMiniGame.Manager.HandlePaperSubmission(this);
        
    }

    private void OnDestroy()
    {
        Debug.Log("종이가 삭제됩니다.");
    }
}
