using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float rotationSpeed = 100f; // ȸ�� �ӵ� (Inspector���� ���� ����)

    [SerializeField]
    private float angularDrag = 1f; // ȸ�� ������ ���� �� �巡�� ��
    [SerializeField]
    private float boostSpeed = 5f;
    [SerializeField]
    private float baseSpeed = 2f; // �⺻ �ӵ�
    [SerializeField]
    public bool isBoosting = false; // �ν�Ʈ ���¸� ��Ÿ���� ����
    public bool isRunning = true; // �޸��� ���¸� ��Ÿ���� ����
    
    
    private enum InPutKey
    {
        None, Left, Right
    }

    private SurfaceEffector2D surfaceEffector2D;

    void Start()
    {
        // Rigidbody2D ������Ʈ�� �����ɴϴ�.
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D�� �� ������Ʈ�� �����ϴ�!");
        }
    }

    private InPutKey currentKey = InPutKey.None; // ���� �Էµ� Ű�� �����ϴ� ����

    private void Update()
    {
        currentKey = Input.GetKey(KeyCode.LeftArrow) ?
            InPutKey.Left :
            Input.GetKey(KeyCode.RightArrow) ? InPutKey.Right : InPutKey.None;
        ;

        isBoosting = Input.GetKey(KeyCode.UpArrow); // �ν�Ʈ ���¸� ������Ʈ

    }


    void FixedUpdate()
    {
        if (!isRunning) return; // �޸��� ���°� �ƴϸ� ������Ʈ���� ����

        surfaceEffector2D.speed = isBoosting ? boostSpeed : baseSpeed; // �ӵ� ����
        if (isBoosting)
        {
            // ���� ȭ��ǥ Ű�� ������ �ν�Ʈ �ӵ��� ����
            surfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            // ���� ȭ��ǥ Ű�� ���� �⺻ �ӵ��� �ǵ���
            surfaceEffector2D.speed = baseSpeed;
        }
        switch (currentKey)
        {
            case InPutKey.Left:
                rb.AddTorque(rotationSpeed); // �������� ȸ��
                break;
            case InPutKey.Right:
                rb.AddTorque(-rotationSpeed); // ���������� ȸ��
                break;
            default:
                // Ű�� ���� ���߷� ����ó�� ȸ���� ���� ����
                rb.angularVelocity *= (1 - angularDrag * Time.fixedDeltaTime);
                break;
        }






        HandleRotation();
    }

    public void GameOver()
    {
        isRunning = false; // ���� ���� ���·� ����
    }

    private void HandleRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.angularVelocity = rotationSpeed; // �������� ȸ��
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.angularVelocity = -rotationSpeed; // ���������� ȸ��
        }
        else
        {
            //Ű�� ���� ���߷� ����ó�� ȸ���� ���� ����
         rb.angularVelocity *= (1 - angularDrag * Time.fixedDeltaTime);
        }
    }
}