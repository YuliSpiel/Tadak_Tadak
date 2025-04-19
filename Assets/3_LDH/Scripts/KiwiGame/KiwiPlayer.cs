using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace MiniGame
{
    public class KiwiPlayer : MonoBehaviour, IPlayer
    {
        [Header("게임 오브젝트")]
        [SerializeField] private GameObject leftKiwi;
        [SerializeField] private GameObject rightKiwi;
        

        public Dictionary<Define.PlayerAction, Action> GetKeyDownActionMap()
        {
            return new()
            {
                { Define.PlayerAction.LeftKiwiContorl, LeftKiwiControl },
                { Define.PlayerAction.RightKiwiControl,RightKiwiControl }
            };
        }

        public Dictionary<Define.PlayerAction, Action> GetKeyUpActionMap()
        {
            return new()
            {
                { Define.PlayerAction.LeftKiwiContorl, LeftKiwiControl },
                { Define.PlayerAction.RightKiwiControl,RightKiwiControl }
            };
        }


        #region Actions

        public void LeftKiwiControl()
        {
            KiwiDanceControl(leftKiwi);
        }

        public void RightKiwiControl()
        {
            KiwiDanceControl(rightKiwi);
        }

        private void KiwiDanceControl(GameObject kiwi)
        {
            kiwi.GetComponent<IExecutable>().Execute();
        }

      

        #endregion

    }
}