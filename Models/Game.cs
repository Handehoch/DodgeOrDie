using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DodgeOrDie.Controllers;

namespace DodgeOrDie.Models
{
    internal class Game
    {
        public readonly Playground Playground;

        public Game(Playground playground)
        {
            Playground = playground;
        }
    }
}
