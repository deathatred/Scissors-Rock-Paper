namespace Scissors_Rock_Paper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Authorize();
        }
        private static void Authorize()
        {
            Console.WriteLine("Greetings new player! Please, enter your nickname: ");
            string name = Console.ReadLine();
            if (name == string.Empty || name.Length > 10)
            {
                while (name == string.Empty || name.Length > 10)
                {
                    Console.WriteLine("Name cant be empty or more than 10 characters long");
                    Console.ReadLine();
                }
            }
        }
    }
}
