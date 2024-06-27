// See https://aka.ms/new-console-template for more information
// Knight
// 속성: hp, attact
// 기능: Move, Attact, Die

class Knight 
{
    public int hp;
    public int attack;
		
    public void Move()
    {
        Console.WriteLine("Knight Move");
    }
		
    public void Attact()
    {
        Console.WriteLine("Knight Attack");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // knight 객체 생성
        Knight knight = new Knight();

        // knight 객체의 필드에 접근
        knight.hp = 100;
        knight.attack = 10;
				
        // knight 객체의 메서드에 접근
        knight.Move();
        knight.Attack();
    }
}

class Rob
{
    public int hp;
    public int snooze;
    public int attack;

    public void Move()
    {
        Console.WriteLine("Rob moved");
    }

    public void sleep()
    {
        Console.WriteLine("Rob is snoozing");
    }

    public void Attack()
    {
        Console.WriteLine("Rob is angry. He is attacking you.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Rob rob = new Rob();

        rob.hp = 1000;
        rob.snooze = 20;
        
        rob.Move();
        rob.sleep();
    }
}


class Knight
{
    public int hp;
    public int attack;

    // 생성자 버전1
    public Knight()
    {
        hp = 100;
        attack = 10;
    }
		
    // 생성자 버전2
    public Knight(int a)
    {
        hp = a;
        attack = 10;
    }
    
    // 생성자 버전3
    public Rob(int b, int c)
    {
        hp = b;
        attack = c;
    }
    
    public void Move()
    {
        Console.WriteLine("Knight Move");
    }

    public void Attact()
    {
        Console.WriteLine("Knight Attact");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // knight 객체 선언과 동시에 hp, attack 값이 부여됨
        Knight knight1 = new Knight();
        Knight knight2 = new Knight(50);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Rob rob1 = new Rob(10, 3);
    }
}