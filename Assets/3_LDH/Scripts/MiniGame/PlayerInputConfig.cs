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
        private Dictionary<KeyCode, Action> keyDownActionMap = new();
        private Dictionary<KeyCode, Action> keyUpActionMap = new();
        

        //외부에서 키-액션 등록하기 위한 메소드
        public void RegisterKeyDownActions(Dictionary<Define.PlayerAction, Action> availableActions)
        {
            keyDownActionMap.Clear();

            foreach (var bind in bindings)
            {
                //binding에 입력된 키-액션을 내부 키-액션에 저장
                //binding에 있는 액션 이름이 availableActions에 있다면 지정된 키와 액션을 keyActionMap에 저장한다.
                if (availableActions.TryGetValue(bind.playerAction, out var action))
                {
                    if(keyDownActionMap.ContainsKey(bind.key))
                        keyDownActionMap[bind.key] += action; // 이미 있으면 체인 추가
                    else
                        keyDownActionMap[bind.key] = action; // 없으면 최초 등록
                }
                else
                {
                    Debug.LogWarning($"Action '{bind.playerAction}' not found.");
                }
            }
        }

        
        public void RegisterKeyUpActions(Dictionary<Define.PlayerAction, Action> actions)
        {
            keyUpActionMap.Clear();
            foreach (var bind in bindings)
            {
                if (actions.TryGetValue(bind.playerAction, out var action))
                {
                    if (keyUpActionMap.ContainsKey(bind.key))
                        keyUpActionMap[bind.key] += action;
                    else
                        keyUpActionMap[bind.key] = action;
                }
            }
        }



        //게임에서 계속 업데이트
        public void HandleInput()
        {
            foreach (var kv in keyDownActionMap)
            {
                if (Input.GetKeyDown(kv.Key))
                {
                    kv.Value?.Invoke();
                }
            }

            foreach (var kv in keyUpActionMap)
            {
                if (Input.GetKeyUp(kv.Key))
                {
                    kv.Value?.Invoke();
                }
            }
        }


    }
}