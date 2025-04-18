using System.Collections;
using System.Collections.Generic;
using MiniGame;
using UnityEngine;

public class KiwiMiniGame : BaseMiniGame
{
    //싱글톤
    public static new KiwiMiniGame Manager => BaseMiniGame.Manager as KiwiMiniGame;
    
    //플레이어
    [SerializeField] private KiwiPlayer kiwiPlayerAction;
    
    //왼쪽 키위, 오른쪽 키위
    [SerializeField] private KiwiController leftKiwi;
    [SerializeField] private KiwiController rightKiwi;
    
    
    
    //정답 판정
    [SerializeField] private bool isSuccess = false;


    private void HandleKiwiState()
    {
        if (!leftKiwi.IsStopped || !rightKiwi.IsStopped) return;

        if (leftKiwi.CurrentSprite == rightKiwi.CurrentSprite)
        {
            Debug.Log("성공");
            isSuccess = true;
        }
    }
    
    
    
    #region GameProcess
    
    public override void Init()
    {
        //플레이어 초기화 (키-액션 맵핑)
        player = kiwiPlayerAction as IPlayer;
        base.Init();
        

    }
    
    public override void StartGame()
    {
        Debug.Log("게임을 시작합니다.");
    }

    public override void UpdateGame()
    {
        player1Config.HandleInput();
        player2Config.HandleInput();
        
        HandleKiwiState();
    }

    public override bool IsGameFinished()
    {
        return false;
    }

    public override void EndGame()
    {
        
    }
    
    #endregion
    
}
