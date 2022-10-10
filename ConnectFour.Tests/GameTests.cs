using ConnectFour.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour.Tests
{
    public class GameTests
    {
        [Fact]
        public void IsPartOFFourInARow_Horizontal_Computer()
        {
            // arrange
            var board = new Board()
            {
                PlayField = new char[6, 7]
                {
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', 'Y' },
                    { 'C', 'C', 'C', 'C', 'Y', 'Y', 'Y' }
                }
            };

            // act
            var fourInARow = Game.IsPartOfFourInARow(board, 5, 0, 'C');

            // assert
            Assert.True(fourInARow);
        }

        [Fact]
        public void IsPartOFFourInARow_Vertical_Computer()
        {
            // arrange
            var board = new Board()
            {
                PlayField = new char[6, 7]
                {
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', 'C', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', 'C', ' ', ' ', ' ', ' ' },
                    { 'Y', ' ', 'C', ' ', ' ', 'Y', 'Y' },
                    { 'C', ' ', 'C', 'C', 'Y', 'Y', 'Y' }
                }
            };

            // act
            var fourInARow = Game.IsPartOfFourInARow(board, 2, 2, 'C');

            // assert
            Assert.True(fourInARow);
        }

        [Fact]
        public void IsPartOFFourInARow_DiagonalRight_Computer()
        {
            // arrange
            var board = new Board()
            {
                PlayField = new char[6, 7]
                {
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { 'C', ' ', ' ', ' ', ' ', ' ', 'C' },
                    { 'Y', 'C', ' ', ' ', ' ', ' ', 'C' },
                    { 'Y', 'Y', 'C', ' ', ' ', ' ', 'Y' },
                    { 'C', 'C', 'Y', 'C', 'Y', 'Y', 'Y' }
                }
            };

            // act
            var fourInARow = Game.IsPartOfFourInARow(board, 2, 0, 'C');

            // assert
            Assert.True(fourInARow);
        }

        [Fact]
        public void IsPartOFFourInARow_DiagonalLeft_Computer()
        {
            // arrange
            var board = new Board()
            {
                PlayField = new char[6, 7]
                {
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', 'C', ' ' },
                    { ' ', 'C', ' ', ' ', 'C', 'Y', ' ' },
                    { ' ', 'C', ' ', 'C', 'Y', 'Y', 'Y' },
                    { 'C', 'Y', 'C', 'C', 'Y', 'Y', 'Y' }
                }
            };

            // act
            var fourInARow = Game.IsPartOfFourInARow(board, 2, 5, 'C');

            // assert
            Assert.True(fourInARow);
        }

        [Fact]
        public void IsPartOFFourInARow_Returns_False_For_No_Four_In_A_Row()
        {
            // arrange
            var board = new Board()
            {
                PlayField = new char[6, 7]
                {
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', 'C', ' ' },
                    { ' ', 'C', ' ', ' ', 'C', 'Y', ' ' },
                    { ' ', 'C', ' ', 'C', 'Y', 'Y', 'Y' },
                    { 'C', 'Y', 'Y', 'C', 'Y', 'C', 'Y' }
                }
            };

            // act
            var fourInARow = Game.IsPartOfFourInARow(board, 2, 5, 'C');

            // assert
            Assert.False(fourInARow);
        }

        [Fact]
        public void PlayerHasFourInARow_Horizontal_Computer()
        {
            // arrange
            var player = new Player(true);
            var board = new Board()
            {
                PlayField = new char[6, 7]
                {
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', 'Y' },
                    { 'C', 'C', 'C', 'C', 'Y', 'Y', 'Y' }
                }
            };

            // act
            var fourInARow = Game.PlayerHasFourInARow(player, board);

            // assert
            Assert.True(fourInARow);
        }

        [Fact]
        public void PlayerHasFourInARow_Vertical_Computer()
        {
            // arrange
            var player = new Player(true);
            var board = new Board()
            {
                PlayField = new char[6, 7]
                {
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', 'C', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', 'C', ' ', ' ', ' ', ' ' },
                    { 'Y', ' ', 'C', ' ', ' ', 'Y', 'Y' },
                    { 'C', ' ', 'C', 'C', 'Y', 'Y', 'Y' }
                }
            };

            // act
            var fourInARow = Game.PlayerHasFourInARow(player, board);

            // assert
            Assert.True(fourInARow);
        }

        [Fact]
        public void PlayerHasFourInARow_DiagonalRight_Computer()
        {
            // arrange
            var player = new Player(true);
            var board = new Board()
            {
                PlayField = new char[6, 7]
                {
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { 'C', ' ', ' ', ' ', ' ', ' ', 'C' },
                    { 'Y', 'C', ' ', ' ', ' ', ' ', 'C' },
                    { 'Y', 'Y', 'C', ' ', ' ', ' ', 'Y' },
                    { 'C', 'C', 'Y', 'C', 'Y', 'Y', 'Y' }
                }
            };

            // act
            var fourInARow = Game.PlayerHasFourInARow(player, board);

            // assert
            Assert.True(fourInARow);
        }

        [Fact]
        public void PlayerHasFourInARow_DiagonalLeft_Computer()
        {
            // arrange
            var player = new Player(true);
            var board = new Board()
            {
                PlayField = new char[6, 7]
                {
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', 'C', ' ' },
                    { ' ', 'C', ' ', ' ', 'C', 'Y', ' ' },
                    { ' ', 'C', ' ', 'C', 'Y', 'Y', 'Y' },
                    { 'C', 'Y', 'C', 'C', 'Y', 'Y', 'Y' }
                }
            };

            // act
            var fourInARow = Game.PlayerHasFourInARow(player, board);

            // assert
            Assert.True(fourInARow);
        }

        [Fact]
        public void PlayerHasFourInARow_Returns_False_For_No_Four_In_A_Row()
        {
            // arrange
            var player = new Player(true);
            var board = new Board()
            {
                PlayField = new char[6, 7]
                {
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', 'C', ' ' },
                    { ' ', 'C', ' ', ' ', 'C', 'Y', ' ' },
                    { ' ', 'C', ' ', 'C', 'Y', 'Y', 'Y' },
                    { 'C', 'Y', 'Y', 'C', 'Y', 'C', 'Y' }
                }
            };

            // act
            var fourInARow = Game.PlayerHasFourInARow(player, board);

            // assert
            Assert.False(fourInARow);
        }

    }
}
