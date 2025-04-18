using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [HideInInspector] public float defaultSpeed = 5f; // 기본 이동 속도
    [HideInInspector] public float minSpeed = 0.5f; // 최저 속도
    [HideInInspector] public float breakRate = 2f; // 감속 계수 (클수록 감속이 더 빨라짐)
    [HideInInspector] public float accelerationRate = 2f; // 가속 계수 (클수록 빠르게 원속도로 복귀)

    public GameObject plantPrefab;
    
    private float currentSpeed;
    
    public bool isChecked = false;
    private bool isStop = false;
    public bool isLast;

    public bool hasPriority =  false; // 애니메이터에 스피드 불값을 전달할 때, 하나의 화분에서만 하도록
    
    public int waterAmount = 0;
    private Rigidbody2D _rb;
    
    public Canvas canvas;
    
    // UI 관련
    [SerializeField] private GameObject _dropCount;
    public float dropCountOffsetX;
    public float dropCountOffsetY;
    private GameObject _countText;
    
    public PlantSpawner spawner;
    private WateringGame _game;
    
    public Animator anim;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        spawner = FindObjectOfType<PlantSpawner>();
        _game = spawner.game;
        Debug.Log(_game);
        anim = GetComponent<Animator>();

        canvas = spawner.mainCanvas;
        // defaultSpeed = spawner.defaultSpeed;
        // minSpeed = spawner.minSpeed;
        // breakRate = spawner.breakRate;
        // accelerationRate = spawner.accelerationRate;
        dropCountOffsetX = spawner.dropCountOffsetX;
        dropCountOffsetY = spawner.dropCountOffsetY;
        
        _countText = Instantiate(_dropCount, canvas.transform);
    }

    void Start()
    {
        currentSpeed = defaultSpeed;
    }

    void LateUpdate()
    {
        if (isStop)
        {
            return;
        }

        currentSpeed = _game.lever.curSpeed;
        
        transform.position += Vector3.right * currentSpeed * Time.deltaTime; // 이동
        _countText.transform.position = Camera.main.WorldToScreenPoint(
            new Vector3(transform.position.x + dropCountOffsetX, transform.position.y + dropCountOffsetY,0));
        _countText.GetComponent<TextMeshProUGUI>().text = waterAmount.ToString();
        if (hasPriority)
        {
            spawner.beltAnimator.SetFloat("beltSpeed", currentSpeed);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if  (other.CompareTag("Judges"))
        {
            // Stop();
            if (waterAmount >= _game.minRange && waterAmount <= _game.maxRange) // 성공
            {
                GameManager.Instance.AddScore(waterAmount); // 스코어 직접 변경해도 됨
                _game.SuccessCount++;
            }
            else if (waterAmount < _game.minRange) // 실패1
            {
                GameManager.Instance.Life --;
            }
            else if (waterAmount > _game.maxRange) // 실패2
            {
                anim.SetBool("Rot", true);
                GameManager.Instance.Life --;
            }
            
            isChecked = true;
            Destroy(gameObject, _game.destroyDelay);

            // // 마지막화분의 판정이 완료되었고, 라이프가 남아있다면 게임 종료
            // if (isLast && GameManager.Instance.Life > 0)
            // {
            //     _game.Invoke("EndGame", 1f); 
            // }
        }
    }

    public void WaterReceived()
    {
        waterAmount++;

        // 물을 너무 많이 줘도 시듦
        if (waterAmount == _game.maxRange+1)
        {
            OverWater();
            return;
        }

        // 일정량의 물을 받으면 성장
        if (waterAmount == _game.minRange) 
        {
            Grow();
            SoundManager.Instance.PlaySFX(ESFXs.GrowSFX);
        }
    }

    private void Grow()
    {
        Debug.Log("화분이 성장했습니다!");
        anim.SetBool("Grow", true);
        // 성장에 따른 이미지, 애니메이션 변경 여기서
    }

    private void OverWater()
    {
        anim.SetBool("Fade", true);
        Debug.Log("물을 너무 많이 줘버렸다해!");
        // 과수분에 따른 이미지 등 처리
    }

    public void Stop()
    {
        isStop = true;
        // _rb.velocity = Vector2.zero;
        _rb.constraints = RigidbodyConstraints2D.FreezeAll;
        Destroy(_countText, 1f);
    }
}