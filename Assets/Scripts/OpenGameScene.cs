using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 타이틀 씬의 'Start' 버튼에 부착
public class OpenGameScene : MonoBehaviour
{
    public void LoadGameScene()
    {
        GameManager.Instance.LoadGameScene();
        SoundManager.Instance.PlaySFX(ESFXs.SelectSFX);
    }
}
