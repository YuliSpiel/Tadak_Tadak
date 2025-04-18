using System.Collections;
using System.Collections.Generic;
using MiniGame;
using UnityEngine;
using DG.Tweening;
public class KiwiMiniGame : BaseMiniGame
{
    //싱글톤
    public static KiwiMiniGame Manager => GameManager.Instance.minigameManager.CurMinigame.GetComponent<KiwiMiniGame>();
    
    //플레이어
    [SerializeField] private KiwiPlayer kiwiPlayerAction;
    
    //왼쪽 키위, 오른쪽 키위
    [SerializeField] private KiwiController leftKiwi;
    [SerializeField] private KiwiController rightKiwi;
    
    
    //플래그
    private bool canJudge = true;
    
    //ui
    [SerializeField] private GameObject successPanel;

    [SerializeField] private int rewardScore = 10;
    
    
    
    private void CheckSuccessCondition()
    {
        if (!leftKiwi.IsStopped || !rightKiwi.IsStopped) return;

        if (canJudge)
        {
            if (leftKiwi.CurrentSprite == rightKiwi.CurrentSprite)
            {
                Debug.Log("성공");
                SoundManager.Instance.PlaySFX(ESFXs.GrowSFX);
                GameManager.Instance.AddScore(rewardScore);
                EndGame();
            }
            else
            {
                Debug.Log("실패");
                SoundManager.Instance.PlaySFX(ESFXs.FailSFX);
                GameManager.Instance.Life--;
            }

            canJudge = false;

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
        Init();
    }

    public override void UpdateGame()
    {
        
        if (!leftKiwi.IsStopped || !rightKiwi.IsStopped)
        {
            Debug.Log("판정 가능해짐");
            canJudge = true; // 다시 시도 가능해짐
        }
        
        CheckSuccessCondition();
    }



    public override void EndGame()
    {
        isSuccess = true;
        isFinished = true;
        
        successPanel?.SetActive(true);
        StartCoroutine(CompleteGameWithDelay(1f));

    }
        
    #endregion
    
}
