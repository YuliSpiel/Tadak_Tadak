using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class RotatableArm : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed; //초당 회전 각도
        [SerializeField] private float targetAngle;
        private float originAngle;
        private bool isRotating = false;
        private Coroutine rotateCoroutine;

        private void Start()
        {
            originAngle = transform.eulerAngles.z;
            
            Debug.Log(originAngle);
            
        }

        public void PlayCoRotateSeqeuence(Action onMidAction = null)
        {
            if (isRotating) return;
            rotateCoroutine = StartCoroutine(CoRotateSequence(onMidAction));
        }
        

        private IEnumerator CoRotateSequence(Action onMidAction = null)
        {
            isRotating = true;
            
            //origin -> target까지 회전
            yield return CoRoateTo(originAngle, targetAngle);
            
            //종이 생성
            onMidAction?.Invoke();
            
            //target -> origin까지 회전
            yield return new WaitForSeconds(0.2f);
            yield return CoRoateTo(targetAngle, originAngle);
            
            //회전 종료
            isRotating = false;
        }
        
        //target angle까지 회전
        private IEnumerator CoRoateTo(float start, float end)
        {
            float currentZ = start;
            float remaining = Mathf.DeltaAngle(currentZ, end);
            while (true)
            {
                
                if (Mathf.Abs(remaining) < 0.1f) break;

                float step = rotationSpeed * Time.deltaTime;
                float rotateThisFrame = Mathf.Clamp(step, 0, Mathf.Abs(remaining)) * Mathf.Sign(remaining);

                transform.Rotate(0, 0, rotateThisFrame);

                yield return null;

                currentZ = transform.eulerAngles.z;
                remaining = Mathf.DeltaAngle(currentZ, end);


            }

            Vector3 rotation = transform.eulerAngles;
            rotation.z = end;
            transform.eulerAngles = rotation;
        }
        
    }
}