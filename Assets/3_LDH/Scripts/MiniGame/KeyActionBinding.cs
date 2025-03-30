using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace MiniGame
{
    [System.Serializable]
    public class KeyActionBinding
    {
        public KeyCode key;
        [FormerlySerializedAs("playerAction")] public Define.PlayerAction playerAction;
    }
}