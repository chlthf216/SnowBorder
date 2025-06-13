using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float rotationSpeed = 100f; // 회전 속도 (Inspector에서 조정 가능)

    [SerializeField]
    private float angularDrag = 1f; // 회전 감속을 위한 각 드래그 값
    [SerializeField]
    private float boostSpeed = 5f;
    [SerializeField]
    private float baseSpeed = 2f; // 기본 속도
    [SerializeField]
    public bool isBoosting = false; // 부스트 상태를 나타내는 변수
    public bool isRunning = true; // 달리는 상태를 나타내는 변수
    
    
    private enum InPutKey
    {
        None, Left, Right
    }

    private SurfaceEffector2D surfaceEffector2D;

    void Start()
    {
        // Rigidbody2D 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D가 이 오브젝트에 없습니다!");
        }
    }

    private InPutKey currentKey = InPutKey.None; // 현재 입력된 키를 저장하는 변수

    private void Update()
    {
        currentKey = Input.GetKey(KeyCode.LeftArrow) ?
            InPutKey.Left :
            Input.GetKey(KeyCode.RightArrow) ? InPutKey.Right : InPutKey.None;
        ;

        isBoosting = Input.GetKey(KeyCode.UpArrow); // 부스트 상태를 업데이트

    }


    void FixedUpdate()
    {
        if (!isRunning) return; // 달리는 상태가 아니면 업데이트하지 않음

        surfaceEffector2D.speed = isBoosting ? boostSpeed : baseSpeed; // 속도 설정
        if (isBoosting)
        {
            // 위쪽 화살표 키를 누르면 부스트 속도를 적용
            surfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            // 위쪽 화살표 키를 떼면 기본 속도로 되돌림
            surfaceEffector2D.speed = baseSpeed;
        }
        switch (currentKey)
        {
            case InPutKey.Left:
                rb.AddTorque(rotationSpeed); // 왼쪽으로 회전
                break;
            case InPutKey.Right:
                rb.AddTorque(-rotationSpeed); // 오른쪽으로 회전
                break;
            default:
                // 키를 떼면 무중력 상태처럼 회전이 점차 감소
                rb.angularVelocity *= (1 - angularDrag * Time.fixedDeltaTime);
                break;
        }






        HandleRotation();
    }

    public void GameOver()
    {
        isRunning = false; // 게임 오버 상태로 설정
    }

    private void HandleRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.angularVelocity = rotationSpeed; // 왼쪽으로 회전
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.angularVelocity = -rotationSpeed; // 오른쪽으로 회전
        }
        else
        {
            //키를 떼면 무중력 상태처럼 회전이 점차 감소
         rb.angularVelocity *= (1 - angularDrag * Time.fixedDeltaTime);
        }
    }
}