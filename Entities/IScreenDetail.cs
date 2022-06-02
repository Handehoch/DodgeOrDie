using System.Drawing;

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
