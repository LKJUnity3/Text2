using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace ConsoleApp1
{
    internal class Program
    {
        public class stat
        {
            public string name { get; set; }
            public int atk { get; set; }
            public int def { get; set; }
            public int hp { get; set; }
            public int lv { get; set; }
            public string job { get; set; }
        }
        
        public class Player : stat
        {
            public int gold { get; set; }

            public Player(string name,int atk,int def, int hp, int lv, string job) 
            {
                this.name = name;
                this.job = job;
                this.atk = atk;
                this.def = def;
                this.hp = hp;
                this.lv = lv;
                gold = 1500;
            }
            public void Victim(int attacker_atk)
            {
                int enemy_atk = attacker_atk;
                int inDamage = enemy_atk - def;
                if (inDamage < 0) 
                { 
                    inDamage = 0;
                }
                hp -= inDamage;
                if (hp < 0)
                {
                    hp = 0;
                }
            }

        }
        public static Player player = new Player("chad", 10, 5, 100, 1, "전사");
        public class Enemy : stat
        {
            public int id { get; set; }

            public Enemy(string name, int lv, int atk, int hp)
            {
                this.name = name;
                this.lv = lv;
                this.hp = hp;
                this.atk = atk;
            }
            public void info()
            {
                Console.WriteLine("LV. " + hp + " " + name + " HP " + hp);
            }
        }

        static void Main(string[] args)
       {
            MainScene();
        }

        static void MainScene()
        {
        mainsecene:
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine("\n[1] 상태 보기\n[2] 전투 시작");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">>>");
            string index = Console.ReadLine();
            int num;
            bool isInt = int.TryParse(index, out num);
            if  (isInt)
            {
                switch (num)
                {
                    case 1: Status(); break;
                    case 2: BattlePage(); break;
                }
            }
            else
            {
                goto mainsecene;
            }
        }
        static void Status()
        {
        Status:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상태 보기");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("LV. " + player.lv);
            Console.WriteLine(player.name + " (" + player.job + ")");
            Console.WriteLine("공격력 : " + player.atk);
            Console.WriteLine("방어력 : " + player.def);
            Console.WriteLine("체 력 : " + player.hp);
            Console.WriteLine("Gold : " + player.gold);
            Console.WriteLine("\n[0] 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>> ");
            string index = Console.ReadLine();
            int num;
            bool isInt = int.TryParse(index, out num);
            if (isInt)
            {
                switch (num)
                {
                    case 0: MainScene(); break;
                    default: goto Status;
                }
            }
            else
            {
                goto Status;
            }
        }
        static void BattlePage()
        {         
            List<Enemy> enemy_ = new List<Enemy>();
            bool attack = false;

            Random random = new Random();
            int enemy_count = random.Next(1, 5);

            for (int i = 0; i < enemy_count; i++)
            {
                int enemy_type = random.Next(1,4);
                switch (enemy_type)
                {
                    case 1: Enemy minion = new Enemy("미니언 ",2,5,15);
                            enemy_.Add(minion); break;
                    case 2:
                        Enemy abyss = new Enemy("공허충", 3, 9,10);
                        enemy_.Add(abyss); break;
                    case 3:
                        Enemy canon_minion = new Enemy("대포 미니언", 5,8,25);
                        enemy_.Add(canon_minion); break;
                }    
            }
        Battle:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Battle\n");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0;i < enemy_count; i++)
            {
                if (attack)
                {
                    Console.Write((i + 1) + " - ");
                }
                Console.WriteLine("Lv." + enemy_[i].lv + " " + enemy_[i].name + " HP " + enemy_[i].hp);
            }

            if (attack)
            {
                Console.WriteLine("\n[0] 다음");
                Console.WriteLine("\n대상을 선택해주세요..");
            }
            else
            {
                Console.WriteLine("\n[1] 공격");
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            }
            
            Console.Write(">>>");
            string index = Console.ReadLine();
            int num;
            bool isInt = int.TryParse(index, out num);
            if (isInt)
            {
                if(attack)
                {
                    
                }
            }
        }
        static void Battle(Enemy enemy_, Player player)
        {
            
        }
    }
}
