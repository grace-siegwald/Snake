using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public class World
    {
        int WindowHeight;
        int WindowWidth;
        int numHorLines = 21;
        int numVertLines = 21;
        public int squareSize = 50;
        public World(Game game)
        {
            WindowHeight = game.WindowHeight;
            WindowWidth = game.WindowWidth;
            numHorLines = game.WindowHeight / squareSize;
            numVertLines = game.WindowWidth / squareSize;
        }
        public void DrawGrid()
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
    }
}