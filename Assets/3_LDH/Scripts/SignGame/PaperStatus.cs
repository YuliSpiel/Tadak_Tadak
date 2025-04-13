using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperStatus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroyPaper()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("종이가 삭제됩니다.");
    }
}
