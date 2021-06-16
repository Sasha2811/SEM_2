using Microsoft.Win32;
using ProgramThatSavesItsStatus.Inerfaces;
using System.Drawing;
using System.Linq;

namespace ProgramThatSavesItsStatus.Savers
{
    public class SaverRegister : ISaver
    {
        public (bool, bool, string, Size, Point) Get()
        {
            (bool, bool, string, Size, Point) result = (false, false, "", new Size(400, 300), new Point(200, 200));
            if (Registry.CurrentUser.GetSubKeyNames().Contains("homeworkContent"))
            {
                RegistryKey content = Registry.CurrentUser.OpenSubKey("homeworkContent");

                result.Item1 = (string)content.GetValue("first") == "True";
                result.Item2 = (string)content.GetValue("second") == "True";
                result.Item3 = (string)content.GetValue("text");

                result.Item4 = new Size((int)content.GetValue("width"), (int)content.GetValue("height"));

                result.Item5 = new Point(
                    (int)content.GetValue("x"),
                    (int)content.GetValue("y")
                    );
            }
            return result;
        }

        public void Save(bool first, bool second, string text, Size size, Point location)
        {
            if (Registry.CurrentUser.GetSubKeyNames().Contains("homeworkContent"))
                Registry.CurrentUser.DeleteSubKey("homeworkContent");

            RegistryKey content = Registry.CurrentUser.CreateSubKey("homeworkContent");

            content.SetValue("first", first);
            content.SetValue("second", second);
            content.SetValue("text", text);
            content.SetValue("width", size.Width);
            content.SetValue("height", size.Height);
            content.SetValue("x", location.X);
            content.SetValue("y", location.Y);
        }
    }
}
