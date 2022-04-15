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
        Size Size { get; set; }
        Point StartPos { get; set; }
        Point EndPos { get; }
        Rectangle Rectangle { get; set; }

        void Update(int width, int height, int x, int y);
    }
}
