using RPS;

public  class HelpTableGenerator
{
    public IPresenter Presenter { get; set; }

    public HelpTableGenerator(IPresenter presenter)
    {
        Presenter = presenter;
    }
    public  void DisplayHelp(string[] moves)
    {
        int half = moves.Length / 2;
        int cellWidth = moves.Max(m => m.Length) + 2;

        Presenter.Write("".PadRight(cellWidth));
        for (int i = 0; i < moves.Length; i++)
        {
            Presenter.Write(moves[i].PadLeft((cellWidth + moves[i].Length) / 2).PadRight(cellWidth));
        }
        Presenter.WriteLine();

        Presenter.Write("".PadRight(cellWidth, '-'));
        for (int i = 0; i < moves.Length; i++)
        {
            Presenter.Write("".PadRight(cellWidth, '-'));
        }
        Presenter.WriteLine();

        for (int i = 0; i < moves.Length; i++)
        {
            Presenter.Write(moves[i].PadRight(cellWidth) + "|");
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
                Presenter.Write(cellColor + cellText.PadLeft((cellWidth + cellText.Length) / 2).PadRight(cellWidth) + "\u001b[0m" + "|");
            }
            Presenter.WriteLine();
            Presenter.Write("".PadRight(cellWidth, '-'));
            for (int j = 0; j < moves.Length; j++)
            {
                Presenter.Write("".PadRight(cellWidth, '-'));
            }
            Presenter.WriteLine();
        }
    }
}