using System;

// 델리게이트 선언
// 몬스터 HP가 변할 때 호출될 메서드를 참조
public delegate void MonsterHPChanged(int newHp);

class Monster
{
    private int hp;
    public event MonsterHPChanged? OnHPChanged;

    public int Hp
    {
        get => hp;
        private set
        {
            hp = value;
            // hp가 변경될 때마다 델리게이트 호출
            OnHPChanged?.Invoke(hp);
        }
    }

    public Monster(int initialHP)
    {
        Hp = initialHP;
    }

    public void TakeDamage(int damage)
    {
        Console.WriteLine($"몬스터가 {damage}만큼 피해를 입었습니다.");
        Hp = (Hp - damage) < 0 ? 0 : (Hp - damage);
    }
}

class Player
{
    //몬스터를 공격하면 점수가 증가한다.
    public int Score { get; private set; }
    public Player()
    {
        Score = 0;
    }

    public void IncreaseScore(int amount)
    {
        Score += amount;
        Console.WriteLine($"점수 증가! : {Score}");
    }

    public void Attack(Monster monster, int damage)
    {
        Console.WriteLine($"플레이어가 몬스터를 공격했습니다!");
        monster.TakeDamage(damage);

    }
}

class Program
{
    static void Main(string[] args)
    {
        // 플레이어와 몬스터 객체 생성
        Player player = new Player();
        Monster monster = new Monster(initialHP: 100);

        // 몬스터 hp 변경 시 호출할 메서드를 델리게이트에 등록
        monster.OnHPChanged += (newHp) =>
        {
            Console.WriteLine($"몬스터 HP: {newHp}");
            if (newHp == 0)
            {
                Console.WriteLine($"몬스터를 처치했습니다.");
                player.IncreaseScore(10); // 점수 증가
            }
        };


        // 테스트 코드 - 플레이어가 몬스터를 공격
        player.Attack(monster, 30);
        player.Attack(monster, 50);
        player.Attack(monster, 40);

        // 프로그램이 종료되지 않고 콘솔 창이 열려 있도록 유지
        Console.ReadLine();
    }
}
