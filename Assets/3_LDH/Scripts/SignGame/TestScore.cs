using System;
using System.Collections;
using System.Collections.Generic;
using MiniGame;
using UnityEngine;

public class TestScore : MonoBehaviour
{
    public static int Score = 0;

    private void Start()
    {
        SignMiniGame.Manager.OnPaperSubmitted -= SetScore;
        SignMiniGame.Manager.OnPaperSubmitted += SetScore;
    }

    public void SetScore(bool isSuccess)
    {
        Score += isSuccess ? 1 : 0;
        Debug.Log($"결과 : {isSuccess}, 스코어 : {Score}");
    }
}
