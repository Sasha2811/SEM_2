using System.Drawing;

namespace ProgramThatSavesItsStatus.Inerfaces
{
    public interface ISaver
    {
        (bool, bool, string, Size, Point) Get();
        void Save(bool first, bool second, string text, Size size, Point location);
    }
}
