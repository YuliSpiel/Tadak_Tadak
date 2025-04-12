using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlantSpawner : MonoBehaviour
{
    public WateringGame game;
    
    // [SerializeField] private List<Plant> _plants; // 생성된 화분들의 리스트
    [SerializeField] private Plant plant;

    public int plantCount =5;
    [SerializeField] private Transform _spawnPos; //   불필요. 자기자신거 쓰면 됨
    private float _interval; // 화분 생성 빈도
    [SerializeField] private bool _isOn;
    
    // UI 관련
    public Canvas mainCanvas;
    public float dropCountOffsetX; // 현재 물방울 수에 대한 X방향 오프셋
    public float dropCountOffsetY; // 현재 물방울 수에 대한 Y방향 오프셋
    
    public Animator beltAnimator;
    void Awake()
    {
        game = GetComponentInParent<WateringGame>();
        plantCount = game.plants.Count;
        _interval = game.plantSpawnInterval;
    }

    public void SpawnPlant()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        for (int i = 0; i < plantCount; i++)
        {
            game.plants[i] = Instantiate(plant.gameObject, _spawnPos.position, Quaternion.identity, this.transform).GetComponent<Plant>();
            game.plants[i].canvas  = mainCanvas;
            game.plants[i].spawner = this;
            game.plants[i].hasPriority = true;
            if (i == plantCount - 1)
            {
                break;
            }
            yield return new WaitForSeconds(_interval);
            game.plants[i].hasPriority = false;
        }
        game.plants[plantCount-1].isLast = true;
    }
}
