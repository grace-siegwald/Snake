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
    public enum GameState
    {
        MainMenu,
        Playing,
        GameOver
    }

    public class Game
    {
        // The size of the game window
        public int WindowWidth = 800;
        public int WindowHeight = 600;
        // The number of lines in the grid
        public World World;
        public List<Snake> Snakes = new List<Snake>(); // Settup for multiplayer perhaps? for now, only one snake in the list lol
        public Food Food;
        public Score Score;
        public float moveTimer = 0f; // number of seconds since the last steps
        public float moveInterval = .1f; // number of seconds between steps

        public GameState State = GameState.MainMenu; // The current state of the game

        public Game()
        {
            // Instances of all the game's objects, passing in instance of this game so they can access the game's fields
            World = new World(this);
        }

        private void StartGame() // Sets up the game to be played, resets all variables and loads content
        {
            Snakes.Clear();
            Snakes.Add(new Snake(this));
            Food = new Food(this);
            Score = new Score(this);

            LoadContent();

            State = GameState.Playing;
        }

        public void LoadContent() // Exactly as it sounds, loads the content for all the game's objects
        {
            Food.LoadContent(this);
            foreach (Snake snake in Snakes)
            {
                snake.LoadContent(this);
            }
        }

        public void Update()
        {   
            switch(State)
            {
                // Switches between the different states of the game and calls the corresponding update method for each state
                case GameState.MainMenu:
                    if (Raylib.IsKeyPressed(KeyboardKey.Enter))
                    {
                        StartGame();
                    }
                    break;
                case GameState.Playing:
                    UpdatePlaying();
                    break;
                case GameState.GameOver:
                    if (Raylib.IsKeyPressed(KeyboardKey.Enter))
                    {
                        StartGame();
                    }
                    break;  
            }
        }

        private void UpdatePlaying() // Main update loop while the game is being played
        {
            foreach (Snake snake in Snakes)
            {
                snake.Update(this);
            }
            Food.Update(this);
            Score.Update(this);
            if (Snakes[0].isDead)
            {
                State = GameState.GameOver;
            }
        }

        public void Draw()
        {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            switch (State)
            {
                case GameState.MainMenu:
                    Raylib.DrawText("Press Enter to Start", WindowWidth / 3, WindowHeight / 3, 40, Color.Black);
                    break;
                case GameState.Playing:
                    DrawPlaying();
                    break;
                case GameState.GameOver:
                    DrawPlaying(); //  Frozen play state behid the game over screen
                    Raylib.DrawText("YOU DIED", WindowWidth / 3, WindowHeight / 3, 40, Color.Red);
                    Raylib.DrawText("Press Enter to Retry", WindowWidth / 3, WindowHeight / 3 + 50, 40, Color.Black);
                    break;
            }
            Raylib.EndDrawing();
        }

        private void DrawPlaying() // Main draw loop while the game is being played
        {
            World.DrawGrid();
            foreach (Snake snake in Snakes)
            {
                snake.Draw(this);
            }
            Food.Draw(this);
            Score.Draw(this);
            //DebugDraw();
        }

        // TODO: Implement a debug class for ease of use?
        private void DebugDraw()
        {
            Raylib.DrawText($"Num Vertical Lines: {World.numVertLines}", 55, 50, 20, Color.Red);
            Raylib.DrawText($"Num Horizontal Lines: {World.numHorLines}", 55, 75, 20, Color.Red);
            Raylib.DrawText($"Snake Length: {Snakes[0].Length}", 55, 100, 20, Color.Red);
            Raylib.DrawText($"Snake Body: {Snakes[0].Body.Count}", 55, 125, 20, Color.Red);
        }
    }
}
