using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace MiniGame
{
    public class SignPlayer : MonoBehaviour, IPlayer
    {
        [Header("게임 오브젝트")]
        [SerializeField] private GameObject leftHand;
        [SerializeField] private GameObject rightHand;

        private GameObject paper;


        [SerializeField] private Transform paperPosition;
        
        

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
            leftHand.GetComponent<IExecutable>().Execute();

        }

        private void SpawnPaper()
        {
            if (paper != null)
            {
                Debug.Log("기존 종이 치우기!");
                Destroy(paper);
            }
            
            //새 종이 생성
            paper = Util.Instatiate("MiniGame/SignGame/Paper", paperPosition.position);
            if(paper==null) Debug.LogError("종이 생성 오류!");

        }
        public void Sign()
        {
            Debug.Log("싸인하기!");
            rightHand.GetComponent<IExecutable>().Execute();

        }
        

        #endregion

    }
}