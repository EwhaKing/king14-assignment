using UnityEngine;

public class KING_CSharp_2 : MonoBehaviour
{
    // ��������Ʈ
    public delegate void PlayerHPHandler(int hp);

    // �̺�Ʈ
    public event PlayerHPHandler OnPlayerHP;

    private int hp;

    public int HP
    {
        get { return hp; }
        set { hp = value; OnPlayerHP?.Invoke(hp); } // ���� ����� ������ OnPlayerHP �̺�Ʈ �߻�
        // OnPlayerHP?.Invoke(hp);
        // OnPlayerHP�� null�� �ƴ� ��쿡�� Invoke ȣ�� ����

        // ��������Ʈ�� �̺�Ʈ�� �⺻������ ���� ����
        // �̺�Ʈ�� �����ڰ� ���� ���� null���� �� �� �ִ�
        // �� �� Invoke ȣ�� �� �� ���� ���� �߻� ���� (����ǥ �߰��ϸ� ���� �߻� ����)
    }

    public void DecreaseHP(int hp)
    {
        HP -= hp;
    }
}

// �� Ŭ���� �̺�Ʈ ����
public class SubscribeEvent : MonoBehaviour
{
    public KING_CSharp_2 sbev;

    private void Start()
    {
        sbev.OnPlayerHP += UpdateHP;
    }

    void UpdateHP(int hp)
    {
        Debug.Log("a");
    }
}
