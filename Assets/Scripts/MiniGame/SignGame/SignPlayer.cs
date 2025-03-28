using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace MiniGame
{
    public class SignPlayer : MonoBehaviour, IPlayer
    {
        public GameObject paperPrefab;
        private GameObject heldPaper;
        
        
        
        
        
        
        public Dictionary<Define.PlayerAction, Action> GetActionMap()
        {
            return new()
            {
                { Define.PlayerAction.GetPaper, GetPaper },
                { Define.PlayerAction.Sign, Sign }
            };
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

    }
}