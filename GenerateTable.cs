using ConsoleTables;
using System.Collections.Generic;
using static RockPaperScissors.CalcResult;

namespace RockPaperScissors
{
    internal class GenerateTable
    {
        List<string> lCells = new List<string>();

        public GenerateTable(string[] _cells)
        {
            lCells.AddRange(_cells);
        }

        public void PrintTable()
        {
            lCells.Insert(0, "PC \\ User");

            ConsoleTable table = new ConsoleTable(lCells.ToArray());
            CalcResult calcResult = new CalcResult(lCells.Count - 1);

            for (int i = 0; i < lCells.Count - 1; i++)
            {
                var currentRow = new string[lCells.Count];
                currentRow[0] = lCells[i + 1];

                for (int j = 0; j < lCells.Count - 1; j++)
                {
                    currentRow[j + 1] = Enum.GetName(typeof(PossibleResults), calcResult.CalculatingResult(i, j)) ?? string.Empty;
                }

                table.AddRow(currentRow.ToArray());
            }

            table.Write(Format.Alternative);

        }
    }
}
