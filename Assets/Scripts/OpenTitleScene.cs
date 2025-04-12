using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임종료 팝업의 'Back to Title' 버튼에 부착
public class OpenTitleScene : MonoBehaviour
{
    public void LoadTitleScene()
    {
        GameManager.Instance.LoadTitleScene();
        Time.timeScale = 1;
    }
}
