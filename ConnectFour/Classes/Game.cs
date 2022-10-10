using ConnectFour.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour.Classes
{
    public static class Game
    {

        public static void PlayGame()
        {
            // Initiate game
            Console.WriteLine("Welcome to connect four!");
            Console.WriteLine("This is the board:");
            Console.WriteLine("");
            var board = new Board();
            board.PrintOutBoard(withLegend: false);

            // Create players and static variables 
            var humanPlayer = new Player(isComputer: false);
            var computerPlayer = new Player(isComputer: true);
            var turns = 0;
            var turnsBeforeBoardIsFull = board.PlayField.GetLength(1) * board.PlayField.GetLength(0) * 0.5;
            var gameIsWon = false;

            // Play the game until someone has won or the board is full. 
            while (turns < turnsBeforeBoardIsFull && !gameIsWon)
            {
                humanPlayer.PlayerTurn(ref board);
                gameIsWon = PlayerHasFourInARow(humanPlayer, board);
                if (gameIsWon)
                {
                    Console.WriteLine("You have won this game, Well done!");
                    return;
                }
                computerPlayer.PlayerTurn(ref board);
                gameIsWon = PlayerHasFourInARow(computerPlayer, board);
                if (gameIsWon)
                {
                    Console.WriteLine("You have lost this game, the computer was better than you :D");
                    return;
                }
                turns++;
            }

            // The board is full:
            Console.WriteLine("There is a draw, nobody wins :(");
            return;
        }

        public static bool PlayAgain()
        {
            bool userWillPlayAgain = false;
            bool correctInput = false;
            while (!correctInput)
            {
                Console.WriteLine("Would you like to play again? (y/n):");
                var input = Console.ReadLine();
                if (input?.ToLower() == "y"|| input?.ToLower() == "yes")
                {
                    userWillPlayAgain = true;
                    break;
                }
                else if (input?.ToLower() == "n" || input?.ToLower() == "no")
                {
                    userWillPlayAgain = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter y/yes/n/no");
                }
            }
            return userWillPlayAgain;

        }

        public static bool PlayerHasFourInARow(IPlayer player, IBoard board)
        {
            var fourInARow = false;
            var discName = player.IsComputer ? 'C' : 'Y';

            // Loop through all the cells in the board to check if there is four in a row.
            for (int row = 0; row < board.PlayField.GetLength(0); row++)
            {
                for (int column = 0; column < board.PlayField.GetLength(1); column++)
                {
                    if (board.PlayField[row, column] == discName)
                    {

                        if (IsPartOfFourInARow(board, row, column, discName))
                        {
                            fourInARow = true;
                            break;
                        }
                    }
                }
            }
            return fourInARow;
        }

        public static bool IsPartOfFourInARow(IBoard board, int row, int column, char discName)
        {          
            var fourInARow = false;

            // check horizontal for four aligning cells, we will always find the most left one first because of the the direction of the for loop. 
            if (column < 4 &&
                board.PlayField[row, column + 1] == discName &&
                board.PlayField[row, column + 2] == discName &&
                board.PlayField[row, column + 3] == discName) { fourInARow = true; }

            // check vertical for four aligning cells, we will always find the most upper one first because of the direction of the for loop.
            else if (row < 3 &&
                board.PlayField[row + 1, column] == discName &&
                board.PlayField[row + 2, column] == discName &&
                board.PlayField[row + 3, column] == discName) { fourInARow = true; }

            // check for diagonal down to the right, we will always find the upper one first because of the direction the for loop.
            else if (row < 3 &&
                column < 4 &&
                board.PlayField[row + 1, column + 1] == discName &&
                board.PlayField[row + 2, column + 2] == discName &&
                board.PlayField[row + 3, column + 3] == discName) { fourInARow = true; }

            // check for diagonal down to the left, we will always find the upper one first because of the direction of the for loop.
            else if (row < 3 &&
                column < 7 &&
                column > 2 &&
                board.PlayField[row + 1, column - 1] == discName &&
                board.PlayField[row + 2, column - 2] == discName &&
                board.PlayField[row + 3, column - 3] == discName) { fourInARow = true; }

            return fourInARow;
        }
    }
}
