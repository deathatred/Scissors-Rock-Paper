using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Scissors_Rock_Paper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wins = 0;
            int numbersOfRounds = 0;
            float winrate = 0f;
            int age = 0;
            string name = null;


            Authorize(ref name, ref age);
            ShowPlayerStats(name, age, numbersOfRounds, wins, winrate);
            LaunchBattle(name);
        }
        private static void Authorize(ref string name, ref int age)
        {
            Console.WriteLine("Greetings new player! Please, enter your nickname: ");
            name = Console.ReadLine();
            if (name == string.Empty || name.Length > 10)
            {
                while (name == string.Empty || name.Length > 10)
                {
                    Console.WriteLine("Name cant be empty or more than 10 characters long");
                    name = Console.ReadLine();
                }
            }
            Console.WriteLine("Great now enter your age: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                age = value;
                if (age < 12)
                {
                    Console.WriteLine("Sorry lil sir, this game is for 12 and above!");
                    Thread.Sleep(5000);
                    return;
                }
            }
        }
        private static void ShowPlayerStats(string nickname, int age, int numberOfRoundsPlayed, int wins, float winrate)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("           PLAYER STATS              ");
            Console.WriteLine("=====================================");
            Console.WriteLine($" Nickname:              {nickname}");
            Console.WriteLine($" Age:                   {age}");
            Console.WriteLine($" Rounds Played:         {numberOfRoundsPlayed}");
            Console.WriteLine($" Wins:                  {wins}");
            Console.WriteLine($" Winrate:               {winrate:F2}%");
            Console.WriteLine("=====================================");
        }
        private static void LaunchBattle(string name)
        {
            Console.WriteLine("Are you ready to start the battle? 1. Yes. 2. No. ");
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || (value != 1 && value != 2))
            {
                Console.WriteLine("Invalid input. Please enter 1 or 2:");

            }
            if (value == 2)
            {
                Console.WriteLine($"Okay, goodbye {name}!");
            }
            else if (value == 1)
            {
                Battle(name);
            }

        }
        private static void Battle(string nickname) //Add console write lines and win counter, battle logic is okay!
        {
            int roundCount = 0;
            while (true)
            {  
                Console.Clear();
                
                Console.WriteLine($"ROUND {roundCount}\nNow choose your weapon: 1.Scissors 2.Paper 3.Rock");
                int value;
                while (!int.TryParse(Console.ReadLine(), out value) || (value != 1 && value != 2 && value != 3))
                {
                    Console.WriteLine("Invalid input. Please enter 1 or 2 or 3: ");
                }
                Random random = new Random();
                int botChoise = random.Next(1, 4);
                Console.WriteLine($"{value}, {botChoise}");
                Console.WriteLine($"   {nickname}:           VS             BOT:");
                Console.WriteLine(ShowBattleImage((value, botChoise),out bool win));
                Console.ReadLine();
                if (value != botChoise)
                {
                    roundCount++;
                }
            }
        }

        private static string ShowBattleImage((int number, int secondNumber) input, out bool win)
        {
            string scissorsVsScissors = @"
    _______                      _______
---'   ____)____            ____(____   '---
          ______)          (______
       __________)        (__________
      (____)                    (___)__.---
---.__(___)                      (___)__.---
";

            string scissorsVsPaper = @"
    _______                      _______
---'   ____)_______        _____(____   '----
          _________)      (______ 
       ___________)      (_______   
      (____)               (_______      
---.__(___)                   (_________.---  
";

            string scissorsVsRock = @"
    _______                     _______
---'   ____)______          ___(____   '---
        __________)        (_____)
       __________)         (_____)
      (____)                (____)     
---.__(___)                  (___)____.---
";

            string paperVsPaper = @"
     _______                     _______
---'    ____)____           ____(____   '----
           ______)         (_______
          _______)        (________
         _______)           (_______
---.__________)                (_________.---
";

            string paperVsRock = @"
     _______                _______     
---'    ____)____       ___(____   '--- 
           ______)     (_____)  
          _______)     (_____)     
         _______)       (____)      
---.__________)          (___)____.---
";

            string paperVsScissors = @"
     _______                     _______
---'    ____)____         ______(____   '---
           ______)       (______
          _______)      (__________  
         _______)               (____)__.---
---.__________)                  (___)__.--- 
";

            string rockVsRock = @"
    _______              _______
---'   ____)         ___(____   '---
      (_____)       (_____)
      (_____)       (_____)
      (____)         (____)
--.___(___)           (___)____.---
";

            string rockVsScissors = @"
    _______               _______
---'   ____)         ____(____   '---
      (_____)       (______
      (_____)      (__________
      (____)              (___)__.---
---.__(___)                (___)__.---
";

            string rockVsPaper = @"
   ______                 _______  
--'  ____)__         ____(____   '----            
      (_____)      (______
      (_____)     (________ 
      (____)       (_______
---.__(___)          (_________.---
";

            switch (input)
            {
                case (3, 1):
                    win = true;
                    return rockVsScissors;
                case (3, 2):
                    win = false;
                    return rockVsPaper;
                case (3, 3):
                    win = false;
                    return rockVsRock;
                case (1, 3):
                    win = false;
                    return scissorsVsRock;
                case (1, 2):
                    win = true;
                    return scissorsVsPaper;
                case (1, 1):
                    win = false;
                    return scissorsVsScissors;
                case (2, 2):
                    win = false;
                    return paperVsPaper;
                case (2, 3):
                    win = true;
                    return paperVsRock;
                case (2, 1):
                    win = false;
                    return paperVsScissors;
                default:win = false; return rockVsScissors;
            }
        }
    }
}
