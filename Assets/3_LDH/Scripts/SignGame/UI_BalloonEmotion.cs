using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BalloonEmotion : MonoBehaviour
{
    private Image UI_BallonEmotion;
    private Animator anim_emotion;
    private void Awake()
    {
        UI_BallonEmotion = GetComponent<Image>();
        anim_emotion = GetComponent<Animator>();
    }


    public void ChangeEmotion(bool isSuccess)
    {
        if (isSuccess)
        {
            anim_emotion.SetInteger("Result", 1);
        }
        else
        {
            anim_emotion.SetInteger("Result", -1);
        }
    }

    public void ResetEmotion()
    {
        anim_emotion.SetInteger("Result", 0);
    }
    
}
