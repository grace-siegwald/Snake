using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Snake
{
    public class Score
    {
        public int score;
        public Score(Game game) 
        { 
            
        }

        public void Draw(Game game)
        {
            Raylib.DrawText($"Score: {score}", 55, 50, 20, Raylib_cs.Color.Red);
        }

        public void Update(Game game) 
        { 

        }

        public void AddPoint()
        {
            score++;
        }

    }
}
