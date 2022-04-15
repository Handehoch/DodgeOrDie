using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeOrDie.Entities
{
    public interface IScreenDetail
    {
        Pen Pen { get; set; }
        Size Size { get; set; }
        Point StartPos { get; set; }
        Point EndPos { get; }
        Rectangle Rectangle { get; set; }

        void Update();
    }
}
