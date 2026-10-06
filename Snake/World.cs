using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Raylib_cs;
namespace Snake
{
    public class World
    {
        int WindowHeight;
        int WindowWidth;
        public int numHorLines; 
        public int numVertLines;
        public int squareSize = 40;
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