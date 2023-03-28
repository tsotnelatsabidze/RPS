using Classic_RPS;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RockPaperScissors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 3 || args.Length % 2 == 0 || args.Distinct().Count() != args.Length)
            {
                Console.WriteLine("Error: Invalid number of arguments. Please provide an odd number of non-repeating strings greater than or equal to 3.");
                Console.WriteLine("Example: dotnet run Rock Paper Scissors Lizard Spock");
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
