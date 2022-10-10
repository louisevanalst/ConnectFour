using ConnectFour.Classes;

public class Program
{
    static void Main()
    {
        var userIsPlaying = true;

        // Play the ConnectFour game after one another as long as the user wants to keep playing.
        while (userIsPlaying)
        {
            Game.PlayGame();
            userIsPlaying = Game.PlayAgain();
        }

        Console.WriteLine("THE END - Thank you for playing :D");
    }
    
}

