using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 플레이어 이동 속도
    private bool isColliding = false; // 충돌 상태를 나타내는 변수

    [SerializeField]
    private GameObject moveObject; // Circle GameObject

    private Rigidbody2D rb;
    
    void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // 중력 영향 받지 않도록 설정
    }

    void Update()
    {
        // 플레이어 이동 처리
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(1, 0, 0) * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-1, 0, 0) * moveSpeed;
        }
    }

    // 충돌 발생 시 호출되는 함수
    void OnCollisionEnter2D(Collision2D collision)
    {
        isColliding = true;
        moveObject.GetComponent<SpriteRenderer>().color = Color.red;
        Debug.Log("네모와 충돌했다!");
    }

    // 트리거 진입 시 호출되는 함수
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 두 obj가 떨어져서 충돌 종료시
        moveObject.GetComponent<SpriteRenderer>().color = Color.white;
        Debug.Log("세모를 지나갔다!");
        isColliding = false;
    }
}
