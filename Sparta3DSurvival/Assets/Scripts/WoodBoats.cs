using UnityEngine;

public class WoodBoats : MonoBehaviour
{
    public float startX = -1f; // ���� ���� X ��ǥ
    public float endX = -4f;   // ������ ���� X ��ǥ
    public float speed = 3.0f; // �̵� �ӵ�

    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 target;
    private bool isMoving = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // ���� ������ ������ ���� ����
        startPoint = new Vector3(startX, transform.position.y, transform.position.z);
        endPoint = new Vector3(endX, transform.position.y, transform.position.z);

        // �ʱ� ��ǥ ������ ������ �������� ����
        target = endPoint;

        // �ʱ� ��ġ�� ���� �������� ����
        rb.position = startPoint;
    }

    private void FixedUpdate()
    {
        // ���� ��ġ�� ��ǥ �������� �̵�
        Vector3 newPosition = Vector3.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        // ��ǥ ������ �����ϸ� ��ǥ ������ �ݴ������� ����
        if (Vector3.Distance(rb.position, target) < 0.1f)
        {
            target = target == startPoint ? endPoint : startPoint;
        }
    }

    // ����׸� ���� ����� �׸���
    private void OnDrawGizmos()
    {
        // ���� ��ġ������ ���� ������ ������ ������ �׸��� ���� ����
        Vector3 startPointGizmo = new Vector3(startX, transform.position.y, transform.position.z);
        Vector3 endPointGizmo = new Vector3(endX, transform.position.y, transform.position.z);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPointGizmo, endPointGizmo);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� �÷��̾��� ��� �̵��� ����մϴ�.
        if (collision.gameObject.CompareTag("Player"))
        {
            isMoving = true;
        }
    }
}
