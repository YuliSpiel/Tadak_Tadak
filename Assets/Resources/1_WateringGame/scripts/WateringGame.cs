using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WateringGame : MinigameBase
{
    public PlantSpawner plantSpawner;
    public Lever lever;
    public WateringCan can;
    public List<Plant> plants; // 생성된 화분들의 리스트
    
    public int minRange; // 성공을 위한 최소점수. 미달시 실패로 판정
    public int maxRange; // 성공을 위한 최대점수. 초과시 실패로 판정
    
    public float plantSpawnInterval;
    public float destroyDelay;
    public override void StartGame()
    {
        plantSpawner.SpawnPlant();
    }

    // 종료조건 : 마지막 화분의 판정이 끝났을 때
    public override void EndGame()
    {
        CompleteGame();
    }
}
