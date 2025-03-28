using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace MiniGame
{
    public class SignMiniGame : MonoBehaviour, IMiniGame
    {
        
        public PlayerInputConfig player1Config;
        public PlayerInputConfig player2Config;
        
        public void Init()
        {
            //플레이어 키-액션 설정
            Dictionary<Define.PlayerAction, Action> p1Actions = new Dictionary<Define.PlayerAction, Action>
            {
                { Define.PlayerAction.GetPaper, GetPaper }
            };
            Dictionary<Define.PlayerAction, Action> p2Actions = new Dictionary<Define.PlayerAction, Action>
            {
                { Define.PlayerAction.Sign, Sign }
            };
            
            player1Config.RegisterActions(p1Actions);
            player2Config.RegisterActions(p2Actions);
        }

        public void StartGame()
        {
            Debug.Log("게임을 시작합니다.");
        }

        public void UpdateGame()
        {
           player1Config.HandleInput();
           player2Config.HandleInput();
        }

        public bool IsGameFinished()
        {
            return false;
        }

        public void EndGame()
        {
            
        }


        #region Actions

        public void GetPaper()
        {
            Debug.Log("종이 가져오기!");
        }

        public void Sign()
        {
            Debug.Log("싸인하기!");
        }
        

        #endregion


        private void Start()
        {
            Debug.Log("게임 시작");
            Init();
        }

        private void Update()
        {
            UpdateGame();
        }
    }
}