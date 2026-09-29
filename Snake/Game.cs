using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Snake
{
    public class Game
    {
        // The size of the game window
        public int WindowWidth = 1000;
        public int WindowHeight = 750;
        // The number of lines in the grid
        int numHorLines = 21;
        int numVertLines = 21;
        // The size of each square on the grid
        public int squareSize = 50;

        World World;
        Snake Snake;
        Food Food;

        public Game()
        {
            // Instances of all the game's objects, passing in instance of this game so they can access the game's fields
            World = new World(this);
            Snake = new Snake(this);
            Food = new Food(this);
        }

        public void Update()
        {
            //check sprite spawn
            Food.Spawn(100, 100);
            Snake.Spawn(500, 500);
            Food.getEaten();
        }

        public void Draw()
        {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            World.DrawGrid();
            Snake.Draw();
            Food.Draw();
            DebugDraw();

            Raylib.EndDrawing();
        }

        // TODO: Implement a debug class for ease of use?
        private void DebugDraw()
        {
            Raylib.DrawText($"Num Vertical Lines: {numVertLines}", 55, 50, 20, Color.Red);
            Raylib.DrawText($"Num Horizontal Lines: {numHorLines}", 55, 75, 20, Color.Red);
        }
    }
}
