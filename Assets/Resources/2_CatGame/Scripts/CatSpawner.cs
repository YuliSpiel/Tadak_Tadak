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
            _game.cats[i] = Instantiate(_cats[i], new Vector3(Random.Range(-4f, 4f), transform.position.y), Quaternion.identity, _game.transform);
            while (_game.cats[i].isActive||_game.cats[i].transform.position.y>0.6)
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
