using System;
using UnityEngine;
using UnityEngine.UI;

namespace _3_LDH.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class UI_Button : MonoBehaviour
    {
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
        }
        
        
        //외부에서 클릭 이벤트 등록
        public void SetOnClickListener(Action action)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(()=> action?.Invoke());
        }
        
        //리스터 추가
        public void AddOnClickListener(Action action)
        {
            button.onClick.AddListener(()=> action?.Invoke());
        }
    }
}