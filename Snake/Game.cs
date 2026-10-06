using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Raylib_cs;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Snake
{
    public class Game
    {
        // The size of the game window
        public int WindowWidth = 800;
        public int WindowHeight = 600;
        // The number of lines in the grid
        public World World;
        public List<Snake> Snakes = new List<Snake>();
        public Food Food;
        public Score Score;


        public Game()
        {
            // Instances of all the game's objects, passing in instance of this game so they can access the game's fields
            World = new World(this);
            Snakes.Add(new Snake(this));
            Food = new Food(this);

        }

        public void LoadContent()
        {
            Food.LoadContent(this);
            foreach (Snake snake in Snakes)
            {
                snake.LoadContent(this);
            }
        }

        public void Update()
        {
            //check sprite spawn
            foreach (Snake snake in Snakes)
            {
                snake.Update(this);
            }
            Food.Update(this);
        }

        public void Draw()
        {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            World.DrawGrid();
            foreach (Snake snake in Snakes)
            {
                snake.Draw();
            }
            Food.Draw();
            DebugDraw();

            Raylib.EndDrawing();
        }

        // TODO: Implement a debug class for ease of use?
        private void DebugDraw()
        {
            Raylib.DrawText($"Num Vertical Lines: {World.numVertLines}", 55, 50, 20, Color.Red);
            Raylib.DrawText($"Num Horizontal Lines: {World.numHorLines}", 55, 75, 20, Color.Red);
        }
    }
}
