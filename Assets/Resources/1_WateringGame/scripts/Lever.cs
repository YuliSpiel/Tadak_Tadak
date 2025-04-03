using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Lever : MonoBehaviour
{
    public WateringGame game;
    [SerializeField] private GameObject _handle;
    
    // 화분 이동 관련 변수
    public float defaultSpeed = 5f; // 기본 이동 속도
    public float minSpeed = 0.5f; // 최저 속도
    public float breakRate = 2f; // 감속 계수 (클수록 감속이 더 빨라짐)
    public float accelRate = 2f; // 가속 계수 (클수록 빠르게 원속도로 복귀)
    
    private float holdTime = 0f; // Shift 누른 시간
    private float releaseTime = 0f; // Shift 뗀 후 시간
    private float _anglePerSpeed;
    private bool isSlowing = false; // 감속 중인지 체크
    
    public float curSpeed;

    private float minAngle = -84;
    private float maxAngle = -10;
    
    void Awake()
    {
        game = GetComponentInParent<WateringGame>();
    }

    void Start()
    {
        curSpeed = defaultSpeed;
        _anglePerSpeed = Mathf.Abs((maxAngle - minAngle) / (defaultSpeed - minSpeed));
        _handle.transform.rotation = Quaternion.Euler(0, 0, minAngle);

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSlowing = true;
            holdTime += Time.deltaTime;
            releaseTime = 0f; // 감속 중이면 가속 타이머 초기화
            float speedDecrease = Mathf.Exp(holdTime* breakRate);
            curSpeed = Mathf.Max(defaultSpeed - speedDecrease, minSpeed); // minSpeed 이하로 안 내려감
        }
        else
        {
            if (isSlowing) // 감속 후 가속 시작
            {
                isSlowing = false;
                holdTime = 0f;
            }
            releaseTime += Time.deltaTime;
            float speedIncrease = (1 - Mathf.Exp(-releaseTime * accelRate)) * (defaultSpeed - minSpeed);
            curSpeed = minSpeed + speedIncrease; // 지수 함수로 점진적 증가
        }
        SetHandleAngle();
    }

    void SetHandleAngle()
    {
        Debug.Log(_anglePerSpeed * curSpeed);
        _handle.transform.rotation = Quaternion.Euler(0, 0, - _anglePerSpeed * curSpeed);
    }
}
