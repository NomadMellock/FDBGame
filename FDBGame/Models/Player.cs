namespace FDBGame.Models
{
    public class Player : Cell
    {
        public int PrevPositionX { get; set; }
        public int PrevPositionY { get; set; }

        public Player()
        {
            
        }

        public Player(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            
            this.PrevPositionX = this.PositionX;
            this.PrevPositionY = this.PositionY;
        }

        public void Accept()
        {
            this.PrevPositionX = this.PositionX;
            this.PrevPositionY = this.PositionY;
        }

        public void Revert()
        {
            this.PositionX = this.PrevPositionX;
            this.PositionY = this.PrevPositionY;
        }

        public void MoveUp()
        {
            PositionY++;
        }
        public void MoveDown()
        {
            PositionY--;
        }
        
        public void MoveLeft()
        {
            PositionX--;
        }

        public void MoveRight()
        {
            PositionX++;
        }
    }
}
