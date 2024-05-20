using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    // Input Action Asset�� ���� ���� ����
    private MyInputActions inputActions;

    // �̵� �ӵ� ����
    public float moveSpeed = 5f;

    // �ʱ�ȭ �޼���
    private void Awake()
    {
        // Input Action Asset �ν��Ͻ� ����
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

    // Update �޼��忡�� Move �׼� ���� ó��
    private void Update()
    {
        // Move �׼� �� �б�
        Vector2 moveInput = inputActions.Player.Move.ReadValue<Vector2>();

        // �̵� ���� ���
        Vector3 moveVector = new Vector3(moveInput.x, moveInput.y, 0);

        // �̵� ���� ����
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
    }
}
