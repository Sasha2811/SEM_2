using System;
using System.Drawing;
using System.Windows.Forms;
using ProgramThatSavesItsStatus.Inerfaces;
using ProgramThatSavesItsStatus.Savers;

namespace ProgramThatSavesItsStatus
{
    public partial class ResultForm : Form, IDisposable
    {
        private TextBox textBox = null;
        private CheckBox firstBox = null;
        private CheckBox secondBox = null;
        private readonly ISaver saver;

        public ResultForm(SaveType type)
        {
            InitializeComponent();

            this.FormClosing += SaveData;
            this.StartPosition = FormStartPosition.Manual;

            CreateControls();

            switch (type)
            {
                case SaveType.XML:
                    saver = new SaverXml();
                    break;
                case SaveType.TXT:
                    saver = new SaverTxt();
                    break;
                case SaveType.Binary:
                    saver = new SaverBinary();
                    break;
                case SaveType.Register:
                    saver = new SaverRegister();
                    break;
                default:
                    break;
            }

            GetSavedData();
        }
        private void CreateControls()
        {
            textBox = new TextBox()
            {
                Width = 300,
                Location = new Point(30, 10)
            };

            firstBox = new CheckBox()
            {
                Location = new Point(10, 9)
            };

            secondBox = new CheckBox()
            {
                Location = new Point(334, 9)
            };

            Controls.Add(textBox);
            Controls.Add(firstBox);
            Controls.Add(secondBox);
        }
        private void GetSavedData()
        {
            var savedData = saver.Get();

            firstBox.Checked = savedData.Item1;
            secondBox.Checked = savedData.Item2;
            textBox.Text = savedData.Item3;
            Size = savedData.Item4;
            Location = savedData.Item5;
        }
        private void SaveData(object sender, FormClosingEventArgs e)
        {
            saver.Save(firstBox.Checked, secondBox.Checked, textBox.Text, Size, Location);
        }

        public new void Dispose()
        {
            Dispose(true);
            textBox.Dispose();
            firstBox.Dispose();
            secondBox.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
