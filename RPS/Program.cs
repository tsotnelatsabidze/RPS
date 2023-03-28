
using System.Security.Cryptography;
using System.Text;

namespace RockPaperScissors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool error = false;
            if (args.Length < 3)
            {
                Console.WriteLine("Error: The number of arguments must be greater than or equal to 3.");
                error = true;
            }
            if (args.Length % 2 == 0)
            {
                Console.WriteLine("Error: The number of arguments must be odd.");
                error = true;
            }
            if (args.Distinct().Count() != args.Length)
            {
                Console.WriteLine("Error: The arguments must be non-repeating.");
                error = true;
            }
            if (error)
            {
                Console.WriteLine("Example of correct usage: Rock Paper Scissors ");
                return;
            }

            var moves = args;
            _ = new KeyGenerator();
            var key = KeyGenerator.GenerateKey();

            var gameRules = new GameRules(moves);

            while (true)
            {
                var computerMoveIndex = RandomNumberGenerator.GetInt32(moves.Length);
                var computerMove = moves[computerMoveIndex];

                var hmacGenerator = new HmacGenerator(key);
                var hmac = hmacGenerator.ComputeHmac(computerMove);
                Console.WriteLine("HMAC: " + BitConverter.ToString(hmac).Replace("-", ""));

                int userMoveIndex;
                while (true)
                {
                    Console.WriteLine("Available moves:");
                    for (int i = 0; i < moves.Length; i++)
                    {
                        Console.WriteLine($"{i + 1} - {moves[i]}");
                    }
                    Console.WriteLine("0 - Exit");
                    Console.WriteLine("H - Help");

                    Console.Write("Enter your move: ");
                    var input = Console.ReadLine();
                    if (input.Equals("H", StringComparison.OrdinalIgnoreCase))
                    {
                        HelpTableGenerator.DisplayHelp(moves);
                        continue;
                    }

                    if (!int.TryParse(input, out userMoveIndex) || userMoveIndex < 0 || userMoveIndex > moves.Length)
                    {
                        Console.WriteLine("Invalid input. Please enter a number from 'Available moves' or 'h' for help.");
                        continue;
                    }

                    if (userMoveIndex == 0)
                    {
                        return;
                    }

                    userMoveIndex--;
                    break;
                }

                Console.WriteLine($"Your move: {moves[userMoveIndex]}");
                Console.WriteLine($"Computer move: {computerMove}");

                var result = gameRules.GetResult(userMoveIndex, computerMoveIndex);
                Console.WriteLine(result);
                Console.WriteLine("HMAC Key: " + BitConverter.ToString(key).Replace("-", "") + "\n");
                
            }
        }
    }
}
