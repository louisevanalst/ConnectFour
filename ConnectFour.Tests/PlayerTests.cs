using ConnectFour.Classes;
using Xunit;

namespace ConnectFour.Tests
{
    public class PlayerTests
    {

        [Fact]
        public void PlayerTurnComputer_Adds_C_Disc_To_Board()
        {
            // arrange
            var player = new Player(true);
            var board = new Board();
            var amountOfComputerDiscsExpected = 1;
            var amountOfComputerDiscsActual = 0;

            // act
            player.PlayerTurn(ref board);
            for (int row = 0; row < board.PlayField.GetLength(0); row++)
            {
                for (int column = 0; column < board.PlayField.GetLength(1); column++)
                {
                    if (board.PlayField[row, column] == 'C') amountOfComputerDiscsActual++;
                }
            }

            // assert
            Assert.Equal(amountOfComputerDiscsActual, amountOfComputerDiscsExpected);
        }
    }
}