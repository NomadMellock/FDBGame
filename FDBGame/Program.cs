using FDBGame;

//Create the game board
GameBoard gameBoard = new GameBoard(8, 8);

string key = string.Empty;
while (key != null && key.ToLower() != "q")
{
    Console.Clear();

    // Welcome Message
    Console.WriteLine(" *********************************************** ");
    Console.WriteLine(" ****          Welcome to FDG Game          **** ");
    Console.WriteLine(" *********************************************** ");
    Console.WriteLine(" *                                             * ");
    Console.WriteLine(" * Try to get your player marked as an [ * ]   * ");
    Console.WriteLine(" * to the top row of the game board            * ");
    Console.WriteLine(" * You may only hit 2 bombs                    * ");
    Console.WriteLine(" *********************************************** ");

    // Draw the game boardm
    gameBoard.DrawGameBoard();

    Console.WriteLine("Use u,d,l,r to move your player");

    // Results
    if (gameBoard.BombsHit.Count > 2)
    {
        Console.WriteLine("****** BOOOOOOOM!!!! ******");
        Console.WriteLine("Game Over. You have been blown up.");
        break;
    }
    else
    {
        Console.WriteLine($"You have Found: {gameBoard.BombsHit.Count()} bomb(s).");
    }

    // Game Complete
    if (gameBoard.PlayerPosition.PositionY >= gameBoard.Height -1)
    {
        Console.WriteLine(" *********************************************** ");
        Console.WriteLine($"*       C O N G R A T U L A T I O N S         * ");
        Console.WriteLine($"*                 You Have Won                * ");
        Console.WriteLine(" *********************************************** ");
        break;
    }

    key = Console.ReadLine();

    if (key != null)
    {
        switch (key.ToLower())
        {
            case "u":
                gameBoard.MovePlayerUp();
                break;
            case "d":
                gameBoard.MovePlayerDown(); 
                break;
            case "l":
                gameBoard.MovePlayerLeft();
                break;
            case "r":
                gameBoard.MovePlayerRight();
                break;
            case "q":
                break;
        }
    }
}

Console.WriteLine("Thank you for playing");

Console.ReadLine();
