using Raylib_cs;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();
            // Initialize a window with a width, height, and title
            Raylib.InitWindow(800, 480, "Hello Raylib C#");
            Raylib.SetTargetFPS(60);

            // Main game loop
            while (!Raylib.WindowShouldClose())
            {
                // 1. Update logic goes here (e.g., checking input)
                game.updateLogic();

                // 2. Drawing logic
                game.Draw();



            }

            // Close the window and clear resources
            Raylib.CloseWindow();




            
           
        }
    }
}



/*
 TO DO:
Una
-write getEaten fucntion
-make food be able to disappear
-make the grid 
- make points show up and update in upper corner
-
 
 */