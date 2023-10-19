using FDBGame.Models;
using FDBGameTests.TestData;

namespace FDBGameTests
{
    public class FDBGameTests
    {
        [Theory]
        [InlineData(8, 8)]
        public void CreateGameBoard_ThenCheckWidthandHeight(int width, int height)
        {
            GameBoard gameBoard = new GameBoard(width, height);

            gameBoard.Width.Should().Be(width);
            gameBoard.Height.Should().Be(height);
        }

        [Theory]
        [InlineData(7, 7)]
        public void GivenAPosition_ReturnIfPositionIsValid(int posX, int posY)
        {
            GameBoard gameBoard = new GameBoard(8, 8);

            bool validPosition = gameBoard.ValidPosition(posX, posY);

            validPosition.Should().Be(true);
        }

        [Theory]
        [InlineData(4)]
        public void GivenANewBoard_ReturnACountOfBombPositions(int bombCount)
        {
            GameBoard gameBoard = new GameBoard(8, 8, bombCount);

            List<Cell> bombPositions = gameBoard.BombPositions;

            bombPositions.Count().Should().Be(bombCount);
        }

        [Theory]
        [InlineData(7, 7)]
        public void GivenAPosition_ReturnPositionHasBomb(int posX, int posY)
        {
            GameBoard gameBoard = new GameBoard(8, 8);

            bool hasBomb = gameBoard.HasBomb(posX, posY);

            hasBomb.Should().Be(false);
        }


        [Theory]
        [ClassData(typeof(PlayerTestData))]
        public void GivenAPosition_ReturnNewPositionWhenMoved_Up(Player player)
        {
            GameBoard gameBoard = new GameBoard(8, 8);

            Player currentPlayerPosition = new Player(player.PositionX, player.PositionY);

            gameBoard.PlayerPosition = player;

            Cell newPosition = gameBoard.MovePlayerUp();

            newPosition.PositionY.Should().Be(currentPlayerPosition.PositionY + 1);

        }

        [Theory]
        [ClassData(typeof(PlayerTestData))]
        public void GivenAPosition_ReturnNewPositionWhenMoved_Down(Player player)
        {
            GameBoard gameBoard = new GameBoard(8, 8);

            Player currentPlayerPosition = new Player(player.PositionX, player.PositionY);

            gameBoard.PlayerPosition = player;

            Cell newPosition = gameBoard.MovePlayerDown();

            newPosition.PositionY.Should().Be(currentPlayerPosition.PositionY - 1);

        }

        [Theory]
        [ClassData(typeof(PlayerTestData))]
        public void GivenAPosition_ReturnNewPositionWhenMoved_Left(Player player)
        {
            GameBoard gameBoard = new GameBoard(8, 8);

            Player currentPlayerPosition = new Player(player.PositionX, player.PositionY);

            gameBoard.PlayerPosition = player;

            Cell newPosition = gameBoard.MovePlayerLeft();

            newPosition.PositionX.Should().Be(currentPlayerPosition.PositionX - 1);
        }

        [Theory]
        [ClassData(typeof(PlayerTestData))]
        public void GivenAPosition_ReturnNewPositionWhenMoved_Right(Player player)
        {
            GameBoard gameBoard = new GameBoard(8, 8);

            Player currentPlayerPosition = new Player(player.PositionX, player.PositionY);

            gameBoard.PlayerPosition = player;

            Cell newPosition = gameBoard.MovePlayerRight();

            newPosition.PositionX.Should().Be(currentPlayerPosition.PositionX + 1);

        }
    }
}