using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float rotationSpeed = 100f; // ȸ�� �ӵ� (Inspector���� ���� ����)

    [SerializeField]
    private float angularDrag = 1f; // ȸ�� ������ ���� �� �巡�� ��

    private enum InPutKey
    {
        None, Left, Right
    }

    void Start()
    {
        // Rigidbody2D ������Ʈ�� �����ɴϴ�.
        rb = GetComponent<Rigidbody2D>();
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
    }

    void FixedUpdate()
    {
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
            // Ű�� ���� ���߷� ����ó�� ȸ���� ���� ����
            rb.angularVelocity *= (1 - angularDrag * Time.fixedDeltaTime);
        }
    }
}