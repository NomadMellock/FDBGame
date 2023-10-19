namespace FDBGame.Models
{
    public class Cell
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Cell() { }

        public Cell(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
        }
    }
}
