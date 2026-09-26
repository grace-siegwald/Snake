using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Food : Sprite
    {
        public int Value; //this is the players points
        public bool Eaten; //this does not have to stay as a bool
        public Food()
        { }



        public void getEaten()
        {
                       Eaten = true;
            //make it disappear
            //add a point to the score - add score in drawing logic 
        }
    }
}
