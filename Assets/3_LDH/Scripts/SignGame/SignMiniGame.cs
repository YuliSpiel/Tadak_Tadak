using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using UnityEngine.UI;

namespace MiniGame
{
    public class SignMiniGame : BaseMiniGame
    {
        //씬 한정 싱글톤 - 타입 캐스팅 숨기기
        public static new SignMiniGame Manager => BaseMiniGame.Manager as SignMiniGame;
        
        
        //플레이어(조작 주체)
        [SerializeField] private SignPlayer signPlayerAction;
        //[SerializeField] private SignPlayer signPlayer2Action;
        
        
        #region Paper
        //종이 프리팹
        private GameObject paperPrefab;
        //종이 생성 위치
        [SerializeField] private Transform paperSpawnPosition;
        //현재 종이
        [SerializeField] private GameObject currentPaper;

        public GameObject CurrentPaper
        {
            get
            {
                if (currentPaper == null)
                {
                    //페이퍼 생성
                    SpawnNewPaper();
                }

                return currentPaper;
            }
            private set
            {
                currentPaper = value;
            }
        }
        
        #endregion
        
        //event
        public event Action<bool> OnPaperSubmitted;
        public event Action OnTurnInit;
        
        

        public void HandlePaperSubmission(PaperStatus paper)
        {
            if (currentPaper != paper.gameObject)
            {
                Debug.LogError("오류");
            }
            
            //결과 판단
            PaperStatus curPaperStatus = currentPaper.GetComponent<PaperStatus>();
            Debug.Log($"current papaer state : {curPaperStatus.State.ToString()}");
            
            if (curPaperStatus.State == PaperState.Signed)
            {
                //성공
                isSuccess = true;
            }
            else
            {
                //그 외는 실패
                isSuccess = false;
            }
            
            Debug.Log($"issuccess : {isSuccess}");
            
            OnPaperSubmitted?.Invoke(isSuccess);
       
            //새로운 종이 생성
            SpawnNewPaper();
            
            //기존 종이 파과
            Destroy(paper.gameObject, 0.3f);
            
            
            //게임 턴 init
            Invoke("InitGameTurn",1f);
        }

        private void SpawnNewPaper()
        {
            currentPaper = Instantiate(paperPrefab, paperSpawnPosition);
            currentPaper.transform.localPosition = Vector3.zero;
            currentPaper.transform.localRotation = Quaternion.identity;
            
        }
        
        
        #region GameProcess
        public override void Init()
        {
            //플레이어 초기화 (키-액션 맵핑)
            player = signPlayerAction as IPlayer;
            base.Init();
            
            //프리팹 로드
            paperPrefab = Util.Load<GameObject>("CommonPrefabs/MiniGame/SignGame/Paper");


        }
        
        public override void StartGame()
        {
            Debug.Log("게임을 시작합니다.");
        }

        public override void UpdateGame()
        {
           
        }
        
        public override void EndGame()
        {
            
        }


        public void InitGameTurn()
        {
            OnTurnInit?.Invoke();
        }
        #endregion
   
    }
}