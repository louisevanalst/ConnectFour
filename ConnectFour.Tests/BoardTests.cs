using ConnectFour.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour.Tests
{
    public class BoardTests
    {
        [Fact]
        public void NewBoard_Creates_An_6_to_7_Empty_Playfield()
        {
            // arrange
            var playFieldExpected = new char[6, 7]
            {
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '}
            };

            // act
            var board = new Board();

            // assert
            Assert.Equal(playFieldExpected, board.PlayField);
        }

        [Fact]
        public void AddDiscToBoard_For_HumanPlayer()
        {
            // arrange
            var player = new Player(false);
            var board = new Board();
            var playFieldAfter = new char[6, 7]
            {
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', 'Y', ' ', ' '}
            };

            // act
            board.AddDiscToTheBoard(4, player.IsComputer);

            // assert
            Assert.Equal(playFieldAfter, board.PlayField);

        }

        [Fact]
        public void AddDiscToBoard_For_ComputerPlayer()
        {
            // arrange
            var player = new Player(true);
            var board = new Board();
            var playFieldAfter = new char[6, 7]
            {
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { 'C', ' ', ' ', ' ', ' ', ' ', ' '}
            };

            // act
            board.AddDiscToTheBoard(0, player.IsComputer);

            // assert
            Assert.Equal(playFieldAfter, board.PlayField);

        }
        
    }

}
