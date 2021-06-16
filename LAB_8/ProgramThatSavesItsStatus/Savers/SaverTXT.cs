using ProgramThatSavesItsStatus.Inerfaces;
using System.Configuration;
using System.Drawing;
using System.IO;

namespace ProgramThatSavesItsStatus.Savers
{
    public class SaverTxt : ISaver
    {
        private readonly string _path;
        public SaverTxt()
        {
            _path = ConfigurationManager.AppSettings["fileTXT"];
        }
        public (bool, bool, string, Size, Point) Get()
        {
            (bool, bool, string, Size, Point) result = (false, false, "", new Size(0, 0), new Point(0,0));
            using (var sr = new StreamReader(_path))
            {
                string fileContent = sr.ReadToEnd();
                if (fileContent != "")
                {
                    string[] saves = fileContent.Split('|');

                    result.Item1 = saves[0] == "True";
                    result.Item2 = saves[1] == "True";

                    result.Item3 = saves[2];

                    result.Item4 = new Size(int.Parse(saves[3]), int.Parse(saves[4]));

                    result.Item5 = new Point(int.Parse(saves[5]), int.Parse(saves[6]));
                }
            }
            return result;
        }

        public void Save(bool first, bool second, string text, Size size, Point location)
        {
            using (var sw = new StreamWriter(_path))
            {
                sw.Write(first +
                    "|" + second +
                    "|" + text +
                    "|" + size.Width +
                    "|" + size.Height +
                    "|" + location.X +
                    "|" + location.Y);
            }
        }
    }
}
