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

        public event Action<PaperStatus> PaperSubmitted;
        
        #endregion
        //Face UI
        //Canvas Object -> Prefab으로 삽입 처리해야함
        private Image faceImage;


        public void OnPaperSubmitted(PaperStatus paper)
        {
            if (currentPaper != paper.gameObject)
            {
                Debug.LogError("오류");
            }
            //결과 판단
            
            //face ui 설정
            
            //새로운 종이 생성
            SpawnNewPaper();
            //그 외 이벤트 호출
            PaperSubmitted?.Invoke(paper);
            //기존 종이 파과
            Destroy(paper.gameObject, 0.3f);
        }

        private void SpawnNewPaper()
        {
            currentPaper = Instantiate(paperPrefab, paperSpawnPosition);
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
        #endregion
   
    }
}