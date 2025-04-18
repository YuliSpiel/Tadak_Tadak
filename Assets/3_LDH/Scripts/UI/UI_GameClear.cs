using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UI_GameClear : MonoBehaviour
{
    public List<Sprite> gameClearBgList;

    private Image ui_gameClearBg;
    // Start is called before the first frame update
    void Start()
    {
        ui_gameClearBg = GetComponent<Image>();
    }

    private void OnEnable()
    {
        ui_gameClearBg.sprite = gameClearBgList[Random.Range(0, gameClearBgList.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
