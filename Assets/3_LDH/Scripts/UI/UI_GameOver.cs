using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameOver : MonoBehaviour
{
    public List<Sprite> gameOverBgList;
    private Image ui_gameOverBg;
    
    // Start is called before the first frame update
    void Start()
    {
        ui_gameOverBg = GetComponent<Image>();
    }

    private void OnEnable()
    {
        ui_gameOverBg.sprite = gameOverBgList[GameManager.Instance.CurGameIndex];
    }

   
}
