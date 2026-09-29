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

        Food food;

        public Game()
        {
            // Instance of food object, passing in instance of this game so that food can access its fields
            food = new Food(this);
            numHorLines = WindowHeight / squareSize;
            numVertLines = WindowWidth / squareSize;
        }

        public void Update()
        {
            //check sprite spawn
            food.Spawn(100, 100);
            food.getEaten();
        }

        private void DrawGrid()
        {
            // Draw Vertical Lines
            for (int i = 0; i < numVertLines; i++)
            {
                int x = i * squareSize;
                Raylib.DrawLine(x, 0, x, WindowHeight, Color.Black);
            }
            // Draw Horizontal Lines
            for (int i = 0; i < numHorLines; i++)
            {
                int y = i * squareSize;
                Raylib.DrawLine(0, y, WindowWidth, y, Color.Black);
            }
        }

        public void Draw()
        {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            DebugDraw();
            DrawGrid();

            if (!food.Eaten) //eaten is a bool in food 
            {
                Raylib.DrawRectangle(food.SpawnLocationX, food.SpawnLocationY, food.Width, food.Height, Color.Blue); //can you change these parameters to be the ones in sprite 
            }

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
