using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ScissorsRockPaper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wins = 0;
            int numbersOfGames = 0;
            int age = 0;
            string name = null;


            Authorize(ref name, ref age);
            ShowPlayerStats(name, age, numbersOfGames, wins);
            LaunchBattle(name, age, ref wins, ref numbersOfGames);
        }
        private static void Authorize(ref string name, ref int age)
        {
            Console.WriteLine("Greetings! Please, enter your nickname: ");
            name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name) || name.Length > 10)
            {
                Console.WriteLine("Name can't be empty or more than 10 characters. Try again:");
                name = Console.ReadLine();
            }

            Console.WriteLine("Great, now enter your age: ");
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid input. Please enter a valid number for your age: ");
            }

            if (value < 12)
            {
                Console.WriteLine("Sorry you must be at least 12 years old to play. The program will close.");
                Environment.Exit(0); 
            }

            age = value;
        }
        private static void ShowPlayerStats(string nickname, int age, int numberOfGames, int wins)
        {
            float winrate;
            if (numberOfGames == 0)
                winrate = 0;
            else
                winrate = (float)wins / numberOfGames * 100;
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
        private static void LaunchBattle(string name, int age, ref int wins, ref int numberOfGames)
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
                Battle(name, age, ref wins, ref numberOfGames);
            }

        }
        private static void Battle(string nickname, int age, ref int wins, ref int numberOfGames) //Add console write lines and win counter, battle logic is okay!
        {
            int roundCount = 1;
            int wonRounds = 0;
            int lostRounds = 0;
            int draws = 0;
            Random random = new Random();


            while (true)
            {
                int value;

                Console.Clear();

                Console.WriteLine($"Stats of this game WINS: {wonRounds}, LOSES: {lostRounds}, DRAWS: {draws}");

                Console.WriteLine($"ROUND {roundCount}\nChoose your weapon: 1.Scissors 2.Paper 3.Rock");

                while (!int.TryParse(Console.ReadLine(), out value) || (value != 1 && value != 2 && value != 3))
                {
                    Console.WriteLine("Invalid input. Please enter 1 or 2 or 3: ");
                }

                int botChoice = random.Next(1, 4);

                Console.WriteLine($"   {nickname}:           VS             BOT:");

                Console.WriteLine(ShowBattleImage(((Weapon)value, (Weapon)botChoice), out bool win));

                DecideWinner(value, botChoice, win);

                GameEnding(ref wins, ref numberOfGames);


            }



            void DecideWinner(int value, int botChoise, bool win)
            {
                if (value != botChoise)
                {
                    switch (win)
                    {
                        case true:
                            Console.WriteLine("                YOU WON!            ");
                            wonRounds++;
                            break;
                        case false:
                            Console.WriteLine("                YOU LOST!           ");
                            lostRounds++;
                            break;
                    }
                    roundCount++;
                    Console.WriteLine(roundCount+"ROUND COUNT");
                } //deciding win
                else
                {
                    draws++;
                    Console.WriteLine("        Draw, try again        ");
                }
            }
            void GameEnding(ref int wins, ref int numberOfGames)
            {
                if (roundCount > 3)
                {
                    if (wonRounds >= 2)
                    {
                        wins++;
                        numberOfGames++;
                        ShowRandomWinMessage();
                    }
                    else
                    {
                        numberOfGames++;
                        ShowRandomLostMessage();
                    }
                    Console.WriteLine(wonRounds + "WON ROUNDS!");
                    wonRounds = 0;
                    lostRounds = 0;
                    Console.WriteLine("Do you want to play one more game? 1.Yes 2. No");

                    int exitChoise;
                    while (!int.TryParse(Console.ReadLine(), out exitChoise) ||
                        (exitChoise != 1 && exitChoise != 2))
                    {
                        Console.WriteLine("Invalid input. Please enter 1(Yes) or 2(No): ");
                    }

                    if (exitChoise == 1)
                    {
                        Console.Clear();
                        ShowPlayerStats(nickname, age, numberOfGames, wins);
                        Console.WriteLine("\nHere are some of your stats! Press enter to continue");
                        Console.ReadLine();
                        roundCount = 1;
                    }
                    if (exitChoise == 2)
                    {
                        Console.Clear();
                        ShowPlayerStats(nickname, age, numberOfGames, wins);
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("To start next round press ENTER!");
                    Console.ReadLine();
                }
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
                default: win = false; return rockVsScissors;
            }
        }
        private static void ShowRandomLostMessage()
        {
            Random rnd = new Random();
            int random = rnd.Next(1, 4);
            string firstMessage = "You lost, you`ll definitelly win next time! Good luck next round";
            string secondMessage = "You lost, but don’t worry, even the best lose sometimes. Let’s go another round!";
            string thirdMessage = "You lost, looks like that one didn’t go your way, but you’ve got this! Ready to bounce back?";
            switch (random)
            {
                case 1:
                    Console.WriteLine(firstMessage);
                    break;
                case 2:
                    Console.WriteLine(secondMessage);
                    break;
                case 3:
                    Console.WriteLine(thirdMessage);
                    break;
            }
        }
        private static void ShowRandomWinMessage()
        {
            Random rnd = new Random();
            int random = rnd.Next(1, 4);
            string firstMessage = "Nice move! You crushed it that round!";
            string secondMessage = "Victory! Looks like you’ve got the winning instincts!";
            string thirdMessage = "Well played! That was a smart choice!";

            switch (random)
            {
                case 1:
                    Console.WriteLine(firstMessage);
                    break;
                case 2:
                    Console.WriteLine(secondMessage);
                    break;
                case 3:
                    Console.WriteLine(thirdMessage);
                    break;
            }
        }
    }
}
