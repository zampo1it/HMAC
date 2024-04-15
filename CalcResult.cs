using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    internal class CalcResult
    {
        int howManyMoves;

        public CalcResult(int howManyMoves)
        {
            this.howManyMoves = howManyMoves;
        }

        public enum PossibleResults
        {
            WIN,
            LOSE,
            DRAW
        }

        public PossibleResults CalculatingResult(int aiTurn, int userTurn)
        {

            bool isUserWin = (userTurn > aiTurn && userTurn - aiTurn <= howManyMoves / 2) || (userTurn < aiTurn && aiTurn - userTurn > howManyMoves / 2);

            return aiTurn == userTurn ? PossibleResults.DRAW :
            isUserWin ? PossibleResults.WIN :
            PossibleResults.LOSE;
        }
    }
}
