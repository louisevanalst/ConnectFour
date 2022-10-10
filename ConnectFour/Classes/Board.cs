using ConnectFour.Classes.Interfaces;
using ConsoleTables;
using System.Data.Common;

namespace ConnectFour.Classes
{
    public class Board : IBoard
    {
        public char[,] PlayField { get; set; }
        public Board()
        {
            this.PlayField = new char[6, 7];

            // Create an empty board
            for (int row = 0; row < PlayField.GetLength(0); row++)
            {
                for (int column = 0; column < PlayField.GetLength(1); column++)
                {
                    PlayField[row, column] = ' ';
                }
            }
        }

        public void AddDiscToTheBoard(int column, bool IsComputer)
        {
            // Insert the disc via looping through the rows, starting downwards, to get the first empty spot. 
            for (var landingRow = PlayField.GetLength(0) - 1; landingRow >= 0; landingRow--)
            {
                if (PlayField[landingRow, column] == ' ')
                {
                    PlayField[landingRow, column] = IsComputer ? 'C' : 'Y';
                    break;
                }
            }
        }

        public void PrintOutBoard(bool withLegend)
        {
            var table = new ConsoleTable("1", "2", "3", "4", "5", "6", "7");
            for (int row = 0; row < PlayField.GetLength(0); row++)
            {
                var rowTable = Enumerable.Range(0, PlayField.GetLength(1))
                .Select(x => PlayField[row, x])
                .ToArray();
                table.AddRow(rowTable[0], rowTable[1], rowTable[2], rowTable[3], rowTable[4], rowTable[5], rowTable[6]);
            }
            table.Write(format: Format.Alternative);
            if (withLegend) Console.WriteLine("Legend: C = Computer, Y = You");
        }
    }
}
