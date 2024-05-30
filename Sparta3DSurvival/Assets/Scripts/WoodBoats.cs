using UnityEngine;

public class WoodBoats : MonoBehaviour
{
    public float startX = -1f; // 시작 지점 X 좌표
    public float endX = -4f;   // 끝나는 지점 X 좌표
    public float speed = 3.0f; // 이동 속도

    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 target;
    private bool isMoving = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // 시작 지점과 끝나는 지점 설정
        startPoint = new Vector3(startX, transform.position.y, transform.position.z);
        endPoint = new Vector3(endX, transform.position.y, transform.position.z);

        // 초기 목표 지점은 끝나는 지점으로 설정
        target = endPoint;

        // 초기 위치를 시작 지점으로 설정
        rb.position = startPoint;
    }

    private void FixedUpdate()
    {
        // 현재 위치를 목표 지점으로 이동
        Vector3 newPosition = Vector3.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        // 목표 지점에 도달하면 목표 지점을 반대쪽으로 변경
        if (Vector3.Distance(rb.position, target) < 0.1f)
        {
            target = target == startPoint ? endPoint : startPoint;
        }
    }

    // 디버그를 위해 기즈모 그리기
    private void OnDrawGizmos()
    {
        // 현재 위치에서의 시작 지점과 끝나는 지점을 그리기 위해 설정
        Vector3 startPointGizmo = new Vector3(startX, transform.position.y, transform.position.z);
        Vector3 endPointGizmo = new Vector3(endX, transform.position.y, transform.position.z);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPointGizmo, endPointGizmo);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 플레이어인 경우 이동을 허용합니다.
        if (collision.gameObject.CompareTag("Player"))
        {
            isMoving = true;
        }
    }
}
