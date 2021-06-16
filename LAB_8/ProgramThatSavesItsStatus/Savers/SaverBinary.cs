using ProgramThatSavesItsStatus.Inerfaces;
using System.Configuration;
using System.Drawing;
using System.IO;

namespace ProgramThatSavesItsStatus.Savers
{
    public class SaverBinary : ISaver
    {
        private readonly string _path;
        public SaverBinary()
        {
            _path = ConfigurationManager.AppSettings["fileBinary"];
        }
        public (bool, bool, string, Size, Point) Get()
        {
            (bool, bool, string, Size, Point) result = (false, false, "", new Size(0, 0), new Point(0, 0));
            using (BinaryReader binaryReader = new BinaryReader(
               File.Open(_path, FileMode.Open)))
            {
                result.Item1 = binaryReader.ReadString() == "True\n";
                result.Item2 = binaryReader.ReadString() == "True\n";
                result.Item3 = binaryReader.ReadString();

                result.Item4 = new Size(int.Parse(binaryReader.ReadString()), int.Parse(binaryReader.ReadString()));

                result.Item5 = new Point(
                    int.Parse(binaryReader.ReadString()),
                    int.Parse(binaryReader.ReadString())
                    );
            }
            return result;
        }

        public void Save(bool first, bool second, string text, Size size, Point location)
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(
                File.Open(_path, FileMode.OpenOrCreate)))
            {
                binaryWriter.Write(first + "\n");
                binaryWriter.Write(second + "\n");
                binaryWriter.Write(text + "\n");
                binaryWriter.Write(size.Width + "\n");
                binaryWriter.Write(size.Height + "\n");
                binaryWriter.Write(location.X + "\n");
                binaryWriter.Write(location.Y + "\n");
            }
        }
    }
}
