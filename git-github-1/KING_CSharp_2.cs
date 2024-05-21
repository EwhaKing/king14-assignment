using UnityEngine;

public class KING_CSharp_2 : MonoBehaviour
{
    // 델리게이트
    public delegate void PlayerHPHandler(int hp);

    // 이벤트
    public event PlayerHPHandler OnPlayerHP;

    private int hp;

    public int HP
    {
        get { return hp; }
        set { hp = value; OnPlayerHP?.Invoke(hp); } // 값이 변경될 때마다 OnPlayerHP 이벤트 발생
        // OnPlayerHP?.Invoke(hp);
        // OnPlayerHP가 null이 아닌 경우에만 Invoke 호출 가능

        // 델리게이트와 이벤트는 기본적으로 참조 형식
        // 이벤트의 구독자가 없을 때는 null값이 될 수 있다
        // 이 때 Invoke 호출 시 널 참조 예외 발생 가능 (물음표 추가하면 예외 발생 방지)
    }

    public void DecreaseHP(int hp)
    {
        HP -= hp;
    }
}

// 위 클래스 이벤트 구독
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
