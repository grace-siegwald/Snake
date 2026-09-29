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
        public int WindowHeight = 1000;
        // Array of x-y start and end positions for drawing the grid
        int[,] gridValues = new int[2, 4];
        int numHorLines = 21;
        int numVertLines = 21;
        // The size of each square on the grid
        int squareSize = 50;
        
        Food food = new Food();
        
        public Game()
        {
            // Defining the "static" values for the grid (Vertical endPosY, Horizontal endPosX)
            // These values will always be the same as the Window width and height
            gridValues[0, 3] = WindowHeight;
            gridValues[1, 2] = WindowWidth;

        }
        
        public void Update()
        {
            //check sprite spawn
            food.Spawn(100, 100);
            food.getEaten();

        }
        
        private void DrawGrid()
        {
            if (numHorLines == numVertLines)
            {
                for (int i = 0; i <= numVertLines; i++)
                {
                    // Line Drawing logic goes here:


                    // This nested for loop is adding an amount (in this case 50) to each element in the gridValues array
                    // This 
                    for (int r = 0; r < gridValues.GetLength(0); r++)
                    {
                        for (int c = 0; c < gridValues.GetLength(1); c++)
                        {
                            gridValues[r, c] += squareSize;
                        }
                    }
                }
            }
            else
            {
                // TODO: Implement logic for drawing different number of vertical and horizontal lines
                throw new Exception("uh what do we do here...");
            }
        }

        public void Draw()
        {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            DrawGrid();
            DebugDraw();

            //vertical lines - this would be good for a utility class 
            Raylib.DrawLine(0, 0, 0, 750, Color.Black);
            Raylib.DrawLine(50, 0, 50, 750, Color.Black);
            Raylib.DrawLine(100, 0, 100, 750, Color.Black);
            Raylib.DrawLine(150, 0, 150, 750, Color.Black);
            Raylib.DrawLine(200, 0, 200, 750, Color.Black);
            Raylib.DrawLine(250, 0, 250, 750, Color.Black);
            Raylib.DrawLine(300, 0, 300, 750, Color.Black);
            Raylib.DrawLine(350, 0, 350, 750, Color.Black);
            Raylib.DrawLine(400, 0, 400, 750, Color.Black);
            Raylib.DrawLine(450, 0, 450, 750, Color.Black);
            Raylib.DrawLine(500, 0, 500, 750, Color.Black);
            Raylib.DrawLine(550, 0, 550, 750, Color.Black);
            Raylib.DrawLine(600, 0, 600, 750, Color.Black);
            Raylib.DrawLine(650, 0, 650, 750, Color.Black);
            Raylib.DrawLine(700, 0, 700, 750, Color.Black);
            Raylib.DrawLine(750, 0, 750, 750, Color.Black);
            Raylib.DrawLine(800, 0, 800, 750, Color.Black);
            Raylib.DrawLine(850, 0, 850, 750, Color.Black);
            Raylib.DrawLine(900, 0, 900, 750, Color.Black);
            Raylib.DrawLine(950, 0, 950, 750, Color.Black);
            Raylib.DrawLine(1000, 0, 1000, 750, Color.Black);



            //horizontal lines
            Raylib.DrawLine(0, 0, 1000, 0, Color.Black);
            Raylib.DrawLine(0, 50, 1000, 50, Color.Black);
            Raylib.DrawLine(0, 100, 1000, 100, Color.Black);
            Raylib.DrawLine(0, 150, 1000, 150, Color.Black);
            Raylib.DrawLine(0, 200, 1000, 200, Color.Black);
            Raylib.DrawLine(0, 250, 1000, 250, Color.Black);
            Raylib.DrawLine(0, 300, 1000, 300, Color.Black);
            Raylib.DrawLine(0, 350, 1000, 350, Color.Black);
            Raylib.DrawLine(0, 400, 1000, 400, Color.Black);
            Raylib.DrawLine(0, 450, 1000, 450, Color.Black);
            Raylib.DrawLine(0, 500, 1000, 500, Color.Black);
            Raylib.DrawLine(0, 550, 1000, 550, Color.Black);
            Raylib.DrawLine(0, 600, 1000, 600, Color.Black);
            Raylib.DrawLine(0, 650, 1000, 650, Color.Black);
            Raylib.DrawLine(0, 700, 1000, 700, Color.Black);
            Raylib.DrawLine(0, 750, 1000, 750, Color.Black);
            Raylib.DrawLine(0, 800, 1000, 800, Color.Black);
            Raylib.DrawLine(0, 850, 1000, 850, Color.Black);
            Raylib.DrawLine(0, 900, 1000, 900, Color.Black);
            Raylib.DrawLine(0, 950, 1000, 950, Color.Black);
            Raylib.DrawLine(0, 1000, 1000, 1000, Color.Black);

            if (food.Eaten == false) //eaten is a bool in food 
            {
                Raylib.DrawRectangle(food.SpawnLocationX, food.SpawnLocationY, food.Width, food.Height, Color.Blue); //can you change these paramters to be the ones in sprite 
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
