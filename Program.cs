using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ScissorsRockPaper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wins = 0;
            int numbersOfGames = 0;
            float winrate = 0f;
            int age = 0;
            string name = null;
            

            Authorize(ref name, ref age);
            ShowPlayerStats(name, age, numbersOfGames, wins, winrate);
            LaunchBattle(name, ref wins, ref numbersOfGames);
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
        private static void ShowPlayerStats(string nickname, int age, int numberOfGames, int wins, float winrate)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("           PLAYER STATS              ");
            Console.WriteLine("=====================================");
            Console.WriteLine($" Nickname:              {nickname}");
            Console.WriteLine($" Age:                   {age}");
            Console.WriteLine($" Games Played:          {numberOfGames}");
            Console.WriteLine($" Wins:                  {wins}");
            Console.WriteLine($" Winrate:               {winrate:F2}%");
            Console.WriteLine("=====================================");
        }
        private static void LaunchBattle(string name,ref int wins,ref int numberOfGames)
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
                Battle(name,ref wins,ref numberOfGames);
            }

        }
        private static void Battle(string nickname, ref int wins, ref int numberOfGames) //Add console write lines and win counter, battle logic is okay!
        {
            int roundCount = 0;
            Random random = new Random();
            while (true)
            {  
                Console.Clear();
                
                Console.WriteLine($"ROUND {roundCount}\n Choose your weapon: 1.Scissors 2.Paper 3.Rock");
                int value;
                while (!int.TryParse(Console.ReadLine(), out value) || (value != 1 && value != 2 && value != 3))
                {
                    Console.WriteLine("Invalid input. Please enter 1 or 2 or 3: ");
                }
                int botChoise = random.Next(1, 4);
                Console.WriteLine($"{(Weapon)value}, {(Weapon)botChoise}");
                Console.WriteLine($"   {nickname}:           VS             BOT:");
                Console.WriteLine(ShowBattleImage(((Weapon)value, (Weapon)botChoise),out bool win));
                if (value != botChoise)
                {
                    switch (win)
                    {
                        case true:
                            Console.WriteLine("You won!");
                            wins++;
                            break;
                        case false:
                            {
                                Console.WriteLine("You lost!");
                            }
                            break;
                    }
                    roundCount++;
                }
                else
                {
                    Console.WriteLine("Draw, try again");
                }
                Console.ReadLine();
            }
        }

        private static string ShowBattleImage((Weapon firstChoise, Weapon secondChoise) input, out bool win)
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
                case (Weapon.Rock, Weapon.Scissors):
                    win = true;
                    return rockVsScissors;
                case (Weapon.Rock, Weapon.Paper):
                    win = false;
                    return rockVsPaper;
                case (Weapon.Rock, Weapon.Rock):
                    win = false;
                    return rockVsRock;
                case (Weapon.Scissors, Weapon.Rock):
                    win = false;
                    return scissorsVsRock;
                case (Weapon.Scissors, Weapon.Paper):
                    win = true;
                    return scissorsVsPaper;
                case (Weapon.Scissors, Weapon.Scissors):
                    win = false;
                    return scissorsVsScissors;
                case (Weapon.Paper, Weapon.Paper):
                    win = false;
                    return paperVsPaper;
                case (Weapon.Paper, Weapon.Rock):
                    win = true;
                    return paperVsRock;
                case (Weapon.Paper, Weapon.Scissors):
                    win = false;
                    return paperVsScissors;
                default:win = false; return rockVsScissors;
            }
        }
    }
}
