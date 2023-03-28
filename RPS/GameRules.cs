using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classic_RPS
{
    public class GameRules
    {
        private readonly string[] _moves;

        public GameRules(string[] moves)
        {
            _moves = moves;
        }

        public string GetResult(int userMoveIndex, int computerMoveIndex)
        {
            if (userMoveIndex == computerMoveIndex)
            {
                return "Draw!";
            }
            else
            {
                int half = _moves.Length / 2;
                int[] winningMoves = Enumerable.Range(1, half).Select(i => (computerMoveIndex + i) % _moves.Length).ToArray();
                if (winningMoves.Contains(userMoveIndex))
                {
                    return "You win!";
                }
                else
                {
                    return "Computer wins!";
                }
            }
        }
    }
}
