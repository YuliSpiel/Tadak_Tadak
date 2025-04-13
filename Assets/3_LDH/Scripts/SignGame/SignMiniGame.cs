using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace MiniGame
{
    public class SignMiniGame : BaseMiniGame
    {
        [SerializeField] private SignPlayer signPlayerAction;
        //[SerializeField] private SignPlayer signPlayer2Action;
        
        public override void Init()
        {
            player = signPlayerAction as IPlayer;
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
        }

        public override bool IsGameFinished()
        {
            return false;
        }

        public override void EndGame()
        {
            
        }

   
    }
}