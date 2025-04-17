using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    private CatGame _game;
    private int _catCount;
    [SerializeField] private List<Cat> _cats; // 스폰할 고양이 리스트(개수가 아닌 종류)
    
    void Start()
    {
        _game = GetComponentInParent<CatGame>();        
        _catCount = _game.cats.Capacity; 
        SetRB();
    }

    public void StartSpawnCat()
    {
        StartCoroutine(SpawnCats());
    }

    IEnumerator SpawnCats()
    {
        for (int i = 0; i < _catCount; i++)
        {
            Debug.Log("Spawning cat");
            _game.cats[i] = Instantiate(_cats[Random.Range(0, _cats.Count)], transform.position, Quaternion.identity);
            while (_game.cats[i].isActive)
            {
                yield return null;
            }
        }
    }

    void SetRB()
    {
        foreach (Cat cat in _cats)
        {
            cat.catDropGravity = _game.CatDropGravity;
            cat.catStaticGravity = _game.CatStaticGravity;
            cat.catDropDrag = _game.CatDropDrag;
            cat.catStaticDrag = _game.CatStaticDrag;
        }
    }
}
