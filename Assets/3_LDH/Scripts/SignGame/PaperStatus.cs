using System;
using System.Collections;
using System.Collections.Generic;
using MiniGame;
using UnityEngine;

public class PaperStatus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSubmit()
    {
        foreach (var sign in GetComponentsInChildren<SignLine>())
        {
            sign.StartShirink();
        }
        
        //종이 제출이 끝났음을 알림
        SignMiniGame.Manager.OnPaperSubmitted(this);
        
    }

    private void OnDestroy()
    {
        Debug.Log("종이가 삭제됩니다.");
    }
}
