using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGame : MinigameBase
{
    [SerializeField] private CatSpawner _catSpawner;
    public List<Cat> cats; // 스폰된 고양이 리스트 즉, 현재 게임 씬에 있는 고양이들

    public float CatDropDrag;
    public float CatDropGravity;
    public float CatStaticDrag;
    public float CatStaticGravity;
    
    void Start()
    {
        _catSpawner = GetComponentInChildren<CatSpawner>();
        StartGame();
    }

    public override void StartGame()
    {
        _catSpawner.StartSpawnCat();
    }

    public override void EndGame()
    {
        
    }
}
