    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PaperMaskSpriteFollower : MonoBehaviour
    {
        private SpriteRenderer targetSprite;
        private SpriteRenderer selfSprite;
        
        // Start is called before the first frame update
        void Start()
        {
            selfSprite = this.GetComponent<SpriteRenderer>();
            targetSprite = transform.parent.GetComponent<SpriteRenderer>();
        }
        
        //targetImage의 Sprite가 Animation에 의해 바뀌는 시점은 Update()애서 일어나기 때문에 바뀐 후의 Sprite를 따라가려면 LateUpdate()를 사용해야 함.
        //그렇지 않으면 바뀌기 이전의 이미지를 따라게기된다.
        private void LateUpdate()
        {
            selfSprite.sprite = targetSprite.sprite;
            Debug.Log($"selfSprite:{selfSprite.sprite.name},  targetSprite : {targetSprite.sprite.name} " );
        }
    }
