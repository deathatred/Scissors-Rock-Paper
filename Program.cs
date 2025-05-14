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
            ShowPlayerStats(name,age,numbersOfRounds,wins,winrate);
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
    }
}
