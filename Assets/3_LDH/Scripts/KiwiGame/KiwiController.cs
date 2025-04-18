using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiwiController : MonoBehaviour, IExecutable
{
    private Animator anim_kiwi;
    private SpriteRenderer spriteRenderer;
    public bool IsStopped => anim_kiwi.speed == 0;
    public Sprite CurrentSprite => spriteRenderer.sprite;

    [Header("Animation Start Offset")]
    
    [Range(0,1)] [SerializeField] private float minOffset;
    [Range(0,1)] [SerializeField] private float maxOffset;
    [SerializeField] private float randomOffset;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim_kiwi = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        randomOffset = Random.Range(minOffset, maxOffset);
        randomOffset = Mathf.Round(randomOffset * 100f) / 100f;
        anim_kiwi.Play("Kiwi_Dance", 0, randomOffset);

    }


    public void Execute()
    {
        anim_kiwi.speed = anim_kiwi.speed == 0f ? 1f : 0f;
    }
}
