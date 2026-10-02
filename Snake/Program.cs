using Raylib_cs;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            // Initialize a window with a width, height, and title
            Raylib.InitWindow(game.WindowWidth, game.WindowHeight, "Snake!");
            Raylib.SetTargetFPS(60);

            // Main game loop
            while (!Raylib.WindowShouldClose())
            {
                // 1. Update logic
                game.Update();

                // 2. Drawing logic
                game.Draw();
            }
        }
    }
}



/*
 TO DO:
Una
-make points show up and update in upper corner
-Do we want a player class to store points in?
-We might want a utility class as well to store drawing formats 
 


NOTES: 
right now if you press enter the square disappears and the eaten bool is true

 */













/*
 Sources:
https://www.tutorialsteacher.com/articles/generate-random-numbers-in-csharp used for randoms 
https://stackoverflow.com/questions/2019417/how-to-access-random-item-in-list used for acessing randoms from a list 
 
 */