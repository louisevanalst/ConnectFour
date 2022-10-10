
using ConnectFour.Classes.Interfaces;
using System.Data.Common;

namespace ConnectFour.Classes
{
    public class Player : IPlayer
    {
        public bool IsComputer { get; set; }
        public Player(bool isComputer)
        {
            this.IsComputer = isComputer;
        }

        public void PlayerTurn(ref Board board)
        {
            // 1. Ask the player for input
            var input = this.IsComputer ? new Random().Next(1, 7) : AskPlayerInput();
            // The input columns of the user are 1-7, arrays however always start with 0.
            var column = input - 1;

            // 2. Check if there is still place in the column that the user chose:
            if (board.PlayField[0, column] != ' ')
            {
                if (!IsComputer) Console.WriteLine("This column is already full, please choose another column");
                PlayerTurn(ref board);
                return;
            }

            // 3. Add disc to the Board and print the new board
            board.AddDiscToTheBoard(column, IsComputer);
            board.PrintOutBoard(true);
        }

        public static int AskPlayerInput()
        {
            var rowForDisk = 0;
            bool success = false;

            // Keep asking the player to give input until he/she supplied correct input.
            while (!success)
            {
                try
                {
                    Console.WriteLine("In which row would you like to put your disc? (enter a number):");
                    var input = Console.ReadLine();

                    // input validation (integer between 1 and 7)
                    rowForDisk = Int32.Parse(input);
                    if (rowForDisk >= 1 && rowForDisk <= 7)
                    {
                        success = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter an integer between 1 and 7.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a number.");
                }
            }

            // return the input
            return rowForDisk;
        }

    }
}
