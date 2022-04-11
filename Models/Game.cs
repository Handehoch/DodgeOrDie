using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Controllers;

namespace WindowsFormsApp1.Models
{
    internal class Game
    {
        public readonly Playground Playground;
        public readonly Movement Movement;

        public Game(Playground playground)
        {
            Playground = playground;
            Movement = new Movement();
        }
    }
}
