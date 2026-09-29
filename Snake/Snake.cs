using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Snake
{
    public class Snake : Sprite
    {
        public Snake(Game game) : base(game)
        {
        } 

        public void Eat()
        {
            // TODO: add eating logic here
        }
        public void Move()
        {
            // TODO: add movement logic here
        }
        public void Grow()
        {
            // TODO: add growing logic here
            // If this snake has just ate food, grow by one square size 
        }
        public override void Draw()
        {
            // TODO: figure out if draw logic for snake needs its own special functionality, implement it here
            base.Draw();
        }
    }
}