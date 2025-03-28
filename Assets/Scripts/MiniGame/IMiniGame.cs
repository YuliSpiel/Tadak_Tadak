using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMiniGame
{
    //게임 초기화
    void Init();

    //게임 시작
    void StartGame();

    //매 프레임 처리
    void UpdateGame();

    //완료 여부
    bool IsGameFinished();

    //게임 종료 처리
    void EndGame();
}
