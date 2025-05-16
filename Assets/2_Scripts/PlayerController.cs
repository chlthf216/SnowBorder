using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float rotationSpeed = 100f; // 회전 속도 (Inspector에서 조정 가능)

    [SerializeField]
    private float angularDrag = 1f; // 회전 감속을 위한 각 드래그 값

    private enum InPutKey
    {
        None, Left, Right
    }

    void Start()
    {
        // Rigidbody2D 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody2D>();
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
    }

    void FixedUpdate()
    {
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
            // 키를 떼면 무중력 상태처럼 회전이 점차 감소
            rb.angularVelocity *= (1 - angularDrag * Time.fixedDeltaTime);
        }
    }
}