namespace TextRPGAssignment
{
    internal class Program
    {
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }

        struct Player
        {
            public int defaultHp;
            public int hp;
            public int attack;
        }

        struct Potion
        {
            public int number;
            public int amtRecovery;
        }

        

        // ClassType, Player를 참고해 MonsterType과 Monster 구조체를 완성해보세요.
        // 몬스터 종류
        // Slime -> 체력: 20 / 공격력: 2
        // Orc -> 체력: 40 / 공격력: 5
        // Skeleton -> 체력: 30 / 공격력: 7
        enum MonsterType
        {
            // TODO
            None = 0,
            Slime = 1,
            Orc = 2,
            Skeleton = 3
        }

        struct Monster
        {
            // TODO
            public string name;
            public int hp;
            public int attack;
        }

        static void initPotion(Potion potion)
        {
            potion.number = 3;
            potion.amtRecovery = 10;
        }

        // 플레이어 직업 선택 함수
        static ClassType ChooseClass()
        {
            Console.WriteLine("직업을 선택하세요!");
            Console.WriteLine("[1]. 검사");
            Console.WriteLine("[2]. 궁수");
            Console.WriteLine("[3]. 법사");

            ClassType choice = ClassType.None;

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    choice = ClassType.Knight;
                    break;
                case "2":
                    choice = ClassType.Archer;
                    break;
                case "3":
                    choice = ClassType.Mage;
                    break;
            }

            return choice;
        }

        // 플레이어 생성 함수
        static void CreatePlayer(ClassType choice, out Player player)
        {
            switch (choice)
            {
                case ClassType.Knight:
                    player.defaultHp = 100;
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Archer:
                    player.defaultHp = 85;
                    player.hp = 85;
                    player.attack = 12;
                    break;
                case ClassType.Mage:
                    player.defaultHp = 60;
                    player.hp = 60;
                    player.attack = 15;
                    break;
                default:
                    player.defaultHp = 0;
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
        }

        // 플레이어 생성 함수 (CreatePlayer)를 참고해 몬스터 랜덤 생성 함수 (CreateRandomMonster)를 완성해보세요.
        // 1. 1~3 중 랜덤으로 수를 하나 뽑습니다. 
        // 2. 뽑은 숫자가 1일 경우에는 슬라임, 2일 경우에는 오크, 3일 경우에는 스켈레톤을 생성하는 코드를 짭니다. (CreatePlayer 참고)
        //    default의 경우 몬스터의 체력을 0, 공격력을 0이로 초기화만 해줍니다.
        // 2-1. 이 때 공격력과 체력을 초기화해주는 코드가 case 실행문에 반복적으로 나타납니다. 함수로 따로 빼서 구현해봅시다.
        // 3. "(몬스터 이름)이 생성되었습니다."라는 문구를 출력해줍니다. (default의 경우 생략)

        // 몬스터 종류
        // Slime -> 체력: 20 / 공격력: 2
        // Orc -> 체력: 40 / 공격력: 5
        // Skeleton -> 체력: 30 / 공격력: 7

        // 몬스터 랜덤 생성 함수
        static void CreateRandomMonster(out Monster monster)
        {
            Random random = new Random();

            int rando = random.Next(1, 4);

            switch (rando)
            {
                case 1:
                    monster.name = "Slime";
                    monster.hp = 20;
                    monster.attack = 2;
                    break;
                case 2:
                    monster.name = "Ork";
                    monster.hp = 40;
                    monster.attack = 5;
                    break;
                case 3:
                    monster.name = "Skeleton";
                    monster.hp = 30;
                    monster.attack = 7;
                    break;
                default:
                    monster.name = "";
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }

            Console.WriteLine("{0}이 생성되었습니다.", monster.name);
        }

        // 게임 접속 함수
        static void EnterGame(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("마을에 접속했습니다!");
                Console.WriteLine("[1]. 필드로 간다");
                Console.WriteLine("[2]. 로비로 돌아가기");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        EnterField(ref player);
                        break;
                    case "2":
                        return;
                }
            }
        }


        // 필드 접속 함수
        static void EnterField(ref Player player)
        {
            Console.WriteLine("필드에 접속했습니다!");

            while (true)
            {
                // 랜덤 몬스터 등장
                Monster monster;
                CreateRandomMonster(out monster);

                Console.WriteLine("[1]. 전투 모드로 돌입");
                Console.WriteLine("[2]. 일정 확률로 마을로 도망");

                // 사용자 입력을 받아 input에 저장
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Fight(ref player, ref monster, ref potion);

                    //continue를 이용해 플레이어가 사망상태가 아니라면 루프를 계속 돌고 ,
                    //사망한 상태라면 break로 EnterField를 빠져나가 마을로 가게 함.
                    if (player.hp > 0)
                        continue;
                    break;
                }
                else
                {
                    // 30퍼센트 확률로 도망에 성공
                    Random rand = new Random();
                    int randValue = rand.Next(0, 101);
                    if (randValue <= 33)
                    {
                        Console.WriteLine("도망쳤습니다!");
                        break;
                    }
                    // 도망에 실패했다면 전투에 돌입한다.
                    else
                    {
                        Console.WriteLine("도망치지 못합니다!");
                        Fight(ref player, ref monster, ref potion);
                        if (player.hp > 0)
                            continue;
                        break;
                    }
                }
            }
        }

        static void ConsoleDIs(Player player, Monster monster)
        {
            Console.WriteLine();
            Console.WriteLine("===========================");
            Console.WriteLine("                   {0}", monster.name);
            Console.WriteLine("              hp : {0}", monster.hp);
            Console.WriteLine("                      ");
            Console.WriteLine("player                ");
            Console.WriteLine("hp : {0}              ", player.hp);
            Console.WriteLine("===========================");
            Console.WriteLine();
        }

        // 무한루프 안을 채워 플레이어 vs 몬스터 전투 함수를 완성해보세요.
        // 1. 플레이어가 먼저 몬스터를 공격한 뒤, 몬스터가 플레이어를 공격합니다. 플레이어가 몬스터를 공격할 경우, 몬스터의 체력에서 플레이어의 공격력 수치만큼을 뺍니다. 몬스터가 플레이어를 공격할 경우, 플레이어의 체력에서 몬스터의 공격력 수치만큼을 뺍니다.
        // 2. 플레이어가 몬스터를 공격했을 때, 몬스터의 체력이 0 이하가 된다면 
        //        1. "적을 무찔렀습니다!" 라는 문구를 출력합니다
        //        2. 플레이어의 남은 체력을 출력해줍니다 (ex. 남은 체력: 87)
        //        3. 무한루프를 빠져나갑니다.
        // 3. 몬스터가 플레이어를 공격했을 때, 플레이어의 체력이 0 이하가 된다면 "Game Over... 마을로 돌아갑니다..."를 출력한 뒤 무한루프를 빠져나갑니다.

        // 플레이어 vs 몬스터 전투 함수
        static void Fight(ref Player player, ref Monster monster, ref Potion potion)
        {
            ConsoleDIs(player, monster);

            while (true)
            {
                potion.amtRecovery = 10;

                Console.WriteLine("[1]. 공격");
                Console.WriteLine("[2]. 회복");
                Console.WriteLine("[3]. 도망");

                string input = Console.ReadLine();

                if(input == "1")
                {
                    monster.hp -= player.attack;

                    ConsoleDIs(player, monster);

                    Console.WriteLine("{0}에게 {1}의 피해를 입혔습니다.", monster.name, player.attack);

                    if (monster.hp <= 0)
                    {
                        Console.WriteLine("{0}을(를) 쓰러뜨렸습니다.", monster.name);
                        Console.WriteLine("남은 체력 : {0}", player.hp);
                        break;
                    }

                    Console.ReadLine();

                    player.hp -= monster.attack;

                    ConsoleDIs(player, monster);

                    Console.WriteLine("{0}의 피해를 입었습니다.", monster.attack);

                    if (player.hp <= 0)
                    {
                        Console.WriteLine("Game Over... 마을로 돌아갑니다...");
                        break;
                    }
                }
                else if(input == "2")
                {
                    player.hp += 10;
                    potion.number -= 1;

                    if(player.hp > player.defaultHp)
                    {
                        player.hp = player.defaultHp;
                        potion.amtRecovery = 10 - (player.hp - player.defaultHp);
                    }
                    
                    ConsoleDIs(player, monster);
                    Console.WriteLine("{0}의 체력을 회복했습니다.", potion.amtRecovery);
                    Console.WriteLine("남은 물약의 개수 : {0}", potion.number);

                    Console.ReadLine();

                    player.hp -= monster.attack;

                    ConsoleDIs(player, monster);

                    Console.WriteLine("{0}의 피해를 입었습니다.", monster.attack);

                    if (player.hp <= 0)
                    {
                        Console.WriteLine("Game Over... 마을로 돌아갑니다...");
                        break;
                    }
                }
                else
                {
                    Random rand = new Random();
                    int randValue = rand.Next(0, 101);
                    if (randValue <= 33)
                    {
                        Console.WriteLine("도망쳤습니다!");
                        break;
                    }
                    
                    else
                    {
                        Console.WriteLine("도망치지 못합니다!");
                        
                    }

                    Console.ReadLine();

                    player.hp -= monster.attack;

                    ConsoleDIs(player, monster);

                    Console.WriteLine("{0}의 피해를 입었습니다.", monster.attack);

                    if (player.hp <= 0)
                    {
                        Console.WriteLine("Game Over... 마을로 돌아갑니다...");
                        break;
                    }
                }
            }
        }

        // 메인 함수
        static void Main(string[] args)
        {
            ClassType choice = ClassType.None;

            

            while (true)
            {
                // 플레이어의 직업을 선택
                choice = ChooseClass();

                // continue 이용해 ClassType선택이 완료되지 않은 상태라면 이후 코드로 넘어가지 않도록 함.
                if (choice == ClassType.None)
                    continue;

                // 플레이어 생성 (체력과 공격력 정보 초기화)
                Player player;
                Potion potion;
                CreatePlayer(choice, out player);
                initPotion(potion);
                Console.WriteLine($"HP:{player.hp} Attack:{player.attack} Potion:{potion.number}");

                // 게임 시작
                EnterGame(ref player);
            }
        }
    }
}