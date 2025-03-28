using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace MiniGame
{
    public class PlayerInputConfig : MonoBehaviour
    {
        //키를 누르면 어떤 행동이 일어날지 입력/편집하기 위한 리스트
        public List<KeyActionBinding> bindings = new(); 
        
        //내부에서 키-액션 맵핑해주는 딕셔너리
        private Dictionary<KeyCode, Action> keyActionMap = new();
        

        //외부에서 키-액션 등록하기 위한 메소드
        public void RegisterActions(Dictionary<Define.PlayerAction, Action> availableActions)
        {
            keyActionMap.Clear();

            foreach (var bind in bindings)
            {
                //binding에 입력된 키-액션을 내부 키-액션에 저장
                //binding에 있는 액션 이름이 availableActions에 있다면 지정된 키와 액션을 keyActionMap에 저장한다.
                if (availableActions.TryGetValue(bind.playerAction, out var action))
                {
                    if(keyActionMap.ContainsKey(bind.key))
                        keyActionMap[bind.key] += action; // 이미 있으면 체인 추가
                    else
                        keyActionMap[bind.key] = action; // 없으면 최초 등록
                }
                else
                {
                    Debug.LogWarning($"Action '{bind.playerAction}' not found.");
                }
            }
        }



        //게임에서 계속 업데이트
        public void HandleInput()
        {
            foreach (var keyAction in keyActionMap)
            {
                if (Input.GetKeyDown(keyAction.Key))
                {
                    //해당 키가 눌렸으면 맵핑된 action을 호출
                    keyAction.Value?.Invoke();
                }
            }
        }


    }
}