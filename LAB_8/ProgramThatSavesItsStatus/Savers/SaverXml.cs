using ProgramThatSavesItsStatus.Inerfaces;
using System.Configuration;
using System.Drawing;
using System.Xml;

namespace ProgramThatSavesItsStatus.Savers
{
    public class SaverXml : ISaver
    {
        private readonly string _path;

        public SaverXml()
        {
            _path = ConfigurationManager.AppSettings["fileXml"];
        }
        public (bool, bool, string, Size, Point) Get()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(_path);

            XmlElement xRoot = xDoc.DocumentElement;

            (bool, bool, string, Size, Point) result;

            result.Item1 = xRoot.ChildNodes[0].Attributes["first"].Value == "True";
            result.Item2 = xRoot.ChildNodes[0].Attributes["second"].Value == "True";

            result.Item3 = xRoot.ChildNodes[0].FirstChild.InnerText;

            result.Item4 = new Size(int.Parse(xRoot.ChildNodes[1].Attributes["width"].Value),
                     int.Parse(xRoot.ChildNodes[1].Attributes["height"].Value));

            result.Item5 = new Point(
                int.Parse(xRoot.ChildNodes[2].Attributes["x"].Value),
                int.Parse(xRoot.ChildNodes[2].Attributes["y"].Value)
                );

            return result;
        }

        public void Save(bool first, bool second, string text, Size size, Point location)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(_path);

            XmlElement xRoot = xDoc.DocumentElement;

            XmlElement content = xDoc.CreateElement("content");
            XmlAttribute firstBoxChecked = xDoc.CreateAttribute("first");
            XmlAttribute secondBoxChecked = xDoc.CreateAttribute("second");
            XmlElement textBoxText = xDoc.CreateElement("text");

            XmlElement formSize = xDoc.CreateElement("size");
            XmlAttribute width = xDoc.CreateAttribute("width");
            XmlAttribute height = xDoc.CreateAttribute("height");

            XmlElement formLocation = xDoc.CreateElement("location");
            XmlAttribute x = xDoc.CreateAttribute("x");
            XmlAttribute y = xDoc.CreateAttribute("y");

            XmlText firstText = xDoc.CreateTextNode(first.ToString());
            XmlText secondText = xDoc.CreateTextNode(second.ToString());
            XmlText textNode = xDoc.CreateTextNode(text);

            XmlText widthText = xDoc.CreateTextNode(size.Width.ToString());
            XmlText heightText = xDoc.CreateTextNode(size.Height.ToString());

            XmlText xText = xDoc.CreateTextNode(location.X.ToString());
            XmlText yText = xDoc.CreateTextNode(location.Y.ToString());

            firstBoxChecked.AppendChild(firstText);
            secondBoxChecked.AppendChild(secondText);
            textBoxText.AppendChild(textNode);

            width.AppendChild(widthText);
            height.AppendChild(heightText);

            x.AppendChild(xText);
            y.AppendChild(yText);

            content.Attributes.Append(firstBoxChecked);
            content.Attributes.Append(secondBoxChecked);
            content.AppendChild(textBoxText);

            formSize.Attributes.Append(width);
            formSize.Attributes.Append(height);

            formLocation.Attributes.Append(x);
            formLocation.Attributes.Append(y);

            xRoot.RemoveAll();

            xRoot.AppendChild(content);
            xRoot.AppendChild(formSize);
            xRoot.AppendChild(formLocation);

            xDoc.Save(ConfigurationManager.AppSettings["fileXml"]);
        }
    }
}
