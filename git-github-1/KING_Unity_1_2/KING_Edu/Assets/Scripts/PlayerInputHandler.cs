using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    // Input Action Asset을 담을 변수 선언
    private MyInputActions inputActions;

    // 이동 속도 변수
    public float moveSpeed = 5f;

    // 초기화 메서드
    private void Awake()
    {
        // Input Action Asset 인스턴스 생성
        inputActions = new MyInputActions();
    }

    // Enable input actions
    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    // Disable input actions
    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    // Update 메서드에서 Move 액션 값을 처리
    private void Update()
    {
        // Move 액션 값 읽기
        Vector2 moveInput = inputActions.Player.Move.ReadValue<Vector2>();

        // 이동 벡터 계산
        Vector3 moveVector = new Vector3(moveInput.x, moveInput.y, 0);

        // 이동 로직 적용
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
    }
}
