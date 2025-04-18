using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MiniGame
{
    public abstract class BaseMiniGame : MinigameBase
    {
        //싱글톤 로직 제거
        // #region Singleton
        //
        // //씬 한정 싱글톤
        // public static BaseMiniGame Manager { get; private set; }
        // protected virtual void Awake()
        // {
        //     if (Manager != null && Manager != this)
        //     {
        //         //씬에서 하나만 있도록 한다.
        //         Destroy(this);
        //         return;
        //     }
        //
        //     Manager = this;
        // }
        //
        // private void OnDestroy()
        // {
        //     if (Manager == this) Manager = null;
        // }
        //
        // #endregion
        
        
        //플레이어1, 2 키 바인딩을 위한 변수
        public PlayerInputConfig player1Config;
        public PlayerInputConfig player2Config;

        //플레이어1, 2의 동작(액션) 이름(enum)을 키로하고 함수를 값으로 하는 딕셔너리를 반환하는 인터페이스
        protected IPlayer player;
        
        //액션이 별로 없어서 플레이어 1,2 액션을 굳이 분리하지 않고 스크립트 하나에 다 넣을 수 있을 것 같아서 일단 주석 처리함.
        //필요하면 player1,2로 나눠서 각각 넣어주기
        //protected IPlayer player1;
        //protected IPlayer player2;


        #region Game Flags

        protected bool isFinished = true;
        protected bool isSuccess = false;

        public bool IsSuccess => isSuccess;
        public bool IsFinished => isFinished;
        

        #endregion
       

        //게임 초기화
        public virtual void Init()
        {
            //플레이어 키-액션 설정
            player1Config.RegisterKeyDownActions(player.GetKeyDownActionMap());
            player1Config.RegisterKeyUpActions(player.GetKeyDownActionMap());
            player2Config.RegisterKeyDownActions(player.GetKeyDownActionMap());
            player2Config.RegisterKeyUpActions(player.GetKeyDownActionMap());

            isSuccess = false;
            isFinished = false;
        }
        

        //매 프레임 처리
        public abstract void UpdateGame();

        
        //테스트를 위한 임시 이벤트 함수 (GameManager로 이동 예정
        private void Start()
        {
            //Init();
            // StartGame();
        }

        private void Update()
        {
            if (isFinished)
            {
                return;
            }
            player1Config.HandleInput();
            player2Config.HandleInput();
            UpdateGame();
        }


        public virtual IEnumerator CompleteGameWithDelay(float delay = 0.5f)
        {
            yield return new WaitForSeconds(delay);
            CompleteGame();
        }
        
    }
}
