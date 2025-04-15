using System;
using System.Collections;
using System.Collections.Generic;
using MiniGame;
using UnityEngine;
using Utils;

public class PaperSigner : MonoBehaviour, IExecutable
{
    private GameObject rightHand;
    private Animator anim_rightHand;
    private bool isSigning;

    [SerializeField] private Transform signLineSpawnPosition;
    private GameObject signLinePrefab;
    private GameObject signLine;


    private void Start()
    {
        rightHand = gameObject;
        anim_rightHand = rightHand.GetComponent<Animator>();
        isSigning = false;

        signLinePrefab = Util.Load<GameObject>("CommonPrefabs/MiniGame/SignGame/SignLine");

    }

    public void Execute()
    {
        if (isSigning)
        {
            Debug.Log("사인 중인 상태입니다.");
            return;
        }
        isSigning = true;
        
        
        ExecuteSigning();
    }

    private void ExecuteSigning()
    {
        //종이에 종속되지 않은 사인은 삭제시킨다.
        for (int i = 1; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        //사인 애니메이션 재생하기
        anim_rightHand.SetTrigger("Sign");
    }


    private void OnSignAnimationEnd()
    {
        isSigning = false;
    }


    private void SpawnSignLine()
    {
        //사인을 생성
        signLine = Instantiate(signLinePrefab, signLineSpawnPosition.position, Quaternion.identity);
        
        //사인 계층 구조..? 계층 종속성 관리....???????
        GameObject paper = SignMiniGame.Manager.CurrentPaper;
        if (paper == null)
        {
            signLine.transform.SetParent(transform,true);
            signLine.transform.SetAsLastSibling();
        }
        else
        {
            signLine.transform.SetParent(paper.transform,true);
            
        }
    }
}
