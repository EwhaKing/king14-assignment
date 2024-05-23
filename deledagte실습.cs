using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 델리게이트를 쓰는 이유; 순차적으로 코딩한다면 UI에 관련된 로직과 게임 로직 사이에 간섭 및 복잡성이 발생하는 문제
/// 파라미터로 메서드 자체를 입력받게 된다면, ButtonPressed 안에 나열된 순차적으로 실행될 것들에 대한 정의가 필요하지 않게 될 것이다.
/// delegate를 사용하면 메서드 자체를 파라미터로 넘겨줄 수 있게 되는 것이다.
/// </summary>
namespace ConsoleApp1
{
    class Yujin {

        //델리게이트 선언
        delegate void YujinState();
        
        void PrintHead()
        {
            Console.WriteLine("배고프다\n");
        }
        void PrintStom()
        {
            Console.WriteLine("역류성식도염\n");
        }
        void PrintMind()
        {
            Console.WriteLine("응애\n");
        }

        void PrintYujinState(YujinState yujinState)
        {
            Console.WriteLine("★☆★☆유진이상태★☆★☆");
            yujinState();
        }

        static void Main(string[] args)
        {
            Yujin yujin = new Yujin();
            //YujinState yujinState = new YujinState();//안된다.
            YujinState yujinState;
            Console.WriteLine("델리게이트 변수 실행");
            yujinState = yujin.PrintHead;
            yujinState += yujin.PrintMind;
            yujinState += yujin.PrintStom;
            yujinState();//이렇게도 실행가능(직접)
            Console.WriteLine("===============================");
            Console.WriteLine("PrintYujinState() 실행");
            yujin.PrintYujinState(yujinState);//이렇게도실행가능(대리맡겨서)
        }
    }

    //연습클래스 
    class Program
    {
        //[접근 한정자] delegate [반환 타입] [delegate 이름]([매개 변수]);
        delegate int OnClicked();//OnClicked라는 델리게이트를 선언
        //델리게이트를 이용할 함수
        static void ButtonPressed(OnClicked clickedFunction)//메소드의 타입은 delegate가 됨
        {
            Console.WriteLine("버튼이 눌렸습니다! ");
            //델리게이트에 등록된 함수 호출
            clickedFunction();
        }
        /// <summary>
        /// 델리게이트에 등록할 함수
        /// </summary>
        /// <returns></returns>
        static int TestDelegate1()
        {
            Console.WriteLine("delegate1 실행");
            return 0;
        }
        static int TestDelegate2()
        {
            Console.WriteLine("Delegate2 실행");
            return 0;
        }
        static int TestDelegate3()
        {
            Console.WriteLine("Delegate3 실행");
            return 0;
        }
/*        static void Main(string[] args)
        {
            //객체사용방식
            //델리게이트 타입의 clicked를 생성과 동시에 TestDelegate1 등록
            OnClicked clicked = new OnClicked(TestDelegate1);
            clicked += TestDelegate2;//메소드 추가

            //델리게이트 사용1
            //ButtonPressed를 실행시키고 인자로 TestDelegate1을 넘겨준다.
            ButtonPressed(TestDelegate1);
            //델리게이트 사용2 clicked에 TestDelegate2를 추가로 등록
            //ButtonPressed를 실행시키고 인자로 clicked 델리게이트 객체를 넘겨준다
            ButtonPressed(clicked);
            //델리게이트 사용3
            clicked();
            //델리게이트3 사용
            ButtonPressed(TestDelegate3);//델리게이트로 정의한 반환타입, 매개변수만 같으면 넣는거 ㄱㄴ
        }*/
    }


}
