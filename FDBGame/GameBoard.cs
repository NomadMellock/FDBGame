using FDBGame.Models;
using System.ComponentModel.Design;
using System.Net.Security;

namespace FDBGame
{
    public class GameBoard
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public List<Cell> BombPositions = new List<Cell>();
        public List<Cell> BombsHit = new List<Cell>();

        public Player PlayerPosition { get; set; } = new Player();

        public GameBoard(int width, int height, int bombCount = 4)
        {
            this.Width = width;
            this.Height = height;
            this.BombsHit = new List<Cell>();
            this.CreateBombPositions(bombCount);
        }

        public bool ValidPosition(int posX, int posY)
        {
            return posX > 0 && posX < Width && posY > 0 && posY < Height;
        }
        public bool HasBomb(int posX, int posY)
        {
            return false;
        }

        public Cell MovePlayerUp()
        {
            PlayerPosition.MoveUp();

            if (!ValidPosition(PlayerPosition))
                PlayerPosition.Revert();
            else
                PlayerPosition.Accept();

            return PlayerPosition;
        }

        public Cell MovePlayerDown()
        {
            PlayerPosition.MoveDown();

            if (!ValidPosition(PlayerPosition))
                PlayerPosition.Revert();
            else
                PlayerPosition.Accept();

            return PlayerPosition;
        }

        public Cell MovePlayerLeft()
        {
            PlayerPosition.MoveLeft();

            if (!ValidPosition(PlayerPosition))
                PlayerPosition.Revert();
            else
                PlayerPosition.Accept();

            return PlayerPosition;
        }

        public Cell MovePlayerRight()
        {
            PlayerPosition.MoveRight();

            if (!ValidPosition(PlayerPosition))
                PlayerPosition.Revert();
            else
                PlayerPosition.Accept();

            return PlayerPosition;
        }

        public void DrawGameBoard()
        {
            for(int y = Height -1; y >= 0; y--)
            {
                for(int x = 0;  x < Width; x++)
                {
                    Console.Write(DrawCell(x, y));
                }
                Console.WriteLine();
            }
        }

        private string DrawCell(int positionX, int positionY)
        {
            Cell cell = new Cell(positionX, positionY);

            string drawCell = " [   ] ";

            bool cellHasBomb = BombPositions.Any(c => c.PositionX == cell.PositionX && c.PositionY == cell.PositionY);
            bool cellHasPlayer = cell.PositionX == PlayerPosition.PositionX && cell.PositionY == PlayerPosition.PositionY;
            bool cellBombHit = BombsHit.Any(c => c.PositionX == cell.PositionX && c.PositionY == cell.PositionY);


            if (cellHasPlayer || cellBombHit)
            {
                if (cellBombHit)
                {
                    if (cellHasPlayer) {
                        drawCell = " [*#*] ";
                    }
                    else
                    {
                        drawCell = " [ # ] ";
                    }
                }
                else
                {
                    if (cellHasBomb && cellHasPlayer)
                    {
                        BombsHit.Add(cell);
                        drawCell = " [*#*] ";
                    }
                    else
                    {
                        drawCell = " [ * ] ";
                    }
                }
            }
            else
                if (cellHasPlayer)
                drawCell = " [ * ] ";

            return drawCell;
        }

        private bool ValidPosition(Cell newPlayerPosition) =>
            newPlayerPosition switch
            {
                _ when newPlayerPosition.PositionX < 0 => false,
                _ when newPlayerPosition.PositionX >= Width => false,
                _ when newPlayerPosition.PositionY < 0 => false,
                _ when newPlayerPosition.PositionY >= Height => false,
                _ => true
            };

        private void CreateBombPositions(int bombCount)
        {

            for (int i = 0; i < bombCount; i++)
            {
                Cell bombPosition = new Cell();
                while (bombPosition.PositionX + bombPosition.PositionY == 0)
                {
                    bombPosition = new Cell(RNGPositionHelper.Next(this.Width -1), RNGPositionHelper.Next(this.Height-1));
                }

                BombPositions.Add(bombPosition);
            }
        }
    }
}