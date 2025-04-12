using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGame : MinigameBase
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("EndGame", 0.5f);
        }
    }

    public override void StartGame()
    {
        Debug.Log("샘플게임 시작했당");
    }

    public override void EndGame()
    {
        CompleteGame();
        Debug.Log("샘플게임 끝났당");
    }
}
