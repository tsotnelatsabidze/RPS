public static class HelpTableGenerator
{
    public static void DisplayHelp(string[] moves)
    {
        int half = moves.Length / 2;
        int cellWidth = moves.Max(m => m.Length) + 2;

        Console.Write("".PadRight(cellWidth));
        for (int i = 0; i < moves.Length; i++)
        {
            Console.Write(moves[i].PadLeft((cellWidth - moves[i].Length) / 2).PadRight(cellWidth));
        }
        Console.WriteLine();

        Console.Write("".PadRight(cellWidth, '-'));
        for (int i = 0; i < moves.Length; i++)
        {
            Console.Write("".PadRight(cellWidth, '-'));
        }
        Console.WriteLine();

        for (int i = 0; i < moves.Length; i++)
        {
            Console.Write(moves[i].PadRight(cellWidth) + "|");
            for (int j = 0; j < moves.Length; j++)
            {
                string cellText;
                string cellColor;
                if (i == j)
                {
                    cellText = "Draw";
                    cellColor = "\u001b[33m"; // Yellow
                }
                else
                {
                    int[] winningMoves = Enumerable.Range(1, half).Select(k => (i + k) % moves.Length).ToArray();
                    if (winningMoves.Contains(j))
                    {
                        cellText = "Win";
                        cellColor = "\u001b[32m"; // Green
                    }
                    else
                    {
                        cellText = "Lose";
                        cellColor = "\u001b[31m"; // Red
                    }
                }
                Console.Write(cellColor + cellText.PadLeft((cellWidth - cellText.Length) / 2).PadRight(cellWidth) + "\u001b[0m" + "|");
            }
            Console.WriteLine();
            Console.Write("".PadRight(cellWidth, '-'));
            for (int j = 0; j < moves.Length; j++)
            {
                Console.Write("".PadRight(cellWidth, '-') + "+");
            }
            Console.WriteLine();
        }
    }
}