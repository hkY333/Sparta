using System.Data;
using System.Xml.Linq;

namespace TextRPG
{
    public static class ShortCut
    {
        public static void Clear()
        {
            Console.Clear();
        }

        public static void VoidLine()
        {
            Console.WriteLine("");
        }

        public static void InvalidInput()
        {
            Console.WriteLine($"잘못된 입력입니다.\n");
        }
    }
    

    internal partial class TextRPG
    {

        enum PlayerRole
        {
            전사 = 1,
            도적
        }

        PlayerRole playerRole = new PlayerRole();


        static void Welcome()
        {
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
        }

        public static void InputName()
        {
            bool nameSet = false;
            string name = "";
            do
            {
                Console.WriteLine($"원하시는 이름을 설정해주세요.\n");
                name = Console.ReadLine();
                ShortCut.VoidLine();
                Console.WriteLine($"입력하신 이름은 " + name + " 입니다.\n");
                Console.WriteLine("1. 저장");
                Console.WriteLine($"2. 취소\n");

                bool numberSet = false;
                while (numberSet == false)
                {
                    int nameSave = int.Parse(Console.ReadLine());
                    ShortCut.VoidLine();

                    switch (nameSave)
                    {
                        case 1: nameSet = true;
                            numberSet = true;
                            break;

                        case 2: nameSet = false;
                            numberSet = true;
                            break;

                        default:
                            ShortCut.InvalidInput();
                            numberSet = false;
                            break;
                    }
                }
            }
            while (nameSet == false);
        }

        public static void SelectRole()
        {
            Console.WriteLine($"원하시는 직업을 선택해주세요.\n");
            Console.WriteLine("1. " + PlayerRole.전사);
            Console.WriteLine("2. " + PlayerRole.도적);
            ShortCut.VoidLine();

            bool roleSet = false;
            do
            {
                int Role = int.Parse(Console.ReadLine());
                ShortCut.VoidLine();

                switch (Role)
                {
                    case 1:
                        Role = (int)PlayerRole.전사;
                        //Console.WriteLine($"당신은 전사을(를) 선택하셨습니다.\n");
                        roleSet = true;
                        break;

                    case 2:
                        Role = (int)PlayerRole.도적;
                        //Console.WriteLine($"당신은 도적을(를) 선택하셨습니다.\n");
                        roleSet = true;
                        break;

                    default:
                        ShortCut.InvalidInput();
                        roleSet = false;
                        break;
                }
            }
            while (roleSet == false);
        }
    }

    internal partial class TextRPG
    {
        enum VillageAct
        {
            상태보기 = 1,
            인벤토리,
            상점
        }

        VillageAct villageAct = new VillageAct();

        InvenWindow invenWindow = new InvenWindow();
        ShoppingWindow shoppingWindow = new ShoppingWindow();

        static void Prepare()
        {
            Console.WriteLine("스파르타 마을에 오신 것을 환영합니다.");
            Console.WriteLine($"이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");

            Console.WriteLine("1. " + VillageAct.상태보기);
            Console.WriteLine("2. " + VillageAct.인벤토리);
            Console.WriteLine("3. " + VillageAct.상점);
            ShortCut.VoidLine();

            bool nowActSet = false;
            do
            {
                int nowAct = int.Parse(Console.ReadLine());
                ShortCut.VoidLine();

                switch (nowAct)
                {
                    case 1:
                        nowActSet = true;
                        nowAct = (int)VillageAct.상태보기;
                        //상태창 열기
                        InformWindow.Inform();
                        
                        break;

                    case 2:
                        nowActSet = true;
                        nowAct = (int)VillageAct.인벤토리;
                        //인벤창 열기
                        InvenWindow.Inven();
                        break;

                    case 3:
                        nowActSet = true;
                        nowAct = (int)VillageAct.상점;
                        //상점창 열기
                        ShoppingWindow.Shop();
                        break;

                    default:
                        nowActSet = false;
                        ShortCut.InvalidInput();
                        break;
                }

            }
            while (nowActSet == false);
        }

        

        public static void Main()
        {
            Welcome();
            InputName();
            ShortCut.Clear();
            Welcome();
            SelectRole();
            ShortCut.Clear();
            Prepare();
        }
    }

    public class MyInform
    {
        int level = 1;
        string myName = "";
        string myRole = "";
        int attackPower = 10;
        int defensePower = 5;
        int hp = 100;
        int gold = 1500;


        public void PrintInfo()
        {
            //myName = TextRPG.name

            Console.WriteLine($"Lv. " + level);
            Console.Write(myName);
            Console.WriteLine($" ( " + myRole + " )");
            Console.WriteLine($"공격력 : " + attackPower);
            Console.WriteLine($"방어력 : " + defensePower);
            Console.WriteLine($"체 력 : " + hp);
            Console.WriteLine($"소지금 : " + gold);
        }
    }

    public static class InformWindow
    {
        public static void Inform()
        {
            MyInform myInform = new MyInform();

            ShortCut.Clear();
            myInform.PrintInfo();
        }
    }

    internal class InvenWindow
    {
        public static void Inven()
        {
            Console.WriteLine("hi");
        }
    }

    internal class ShoppingWindow
    {
        public static void Shop()
        {
            Console.WriteLine("hi");
        }
    }
}