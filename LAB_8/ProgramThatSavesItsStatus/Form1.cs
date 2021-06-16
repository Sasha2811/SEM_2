using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramThatSavesItsStatus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 185;
            this.Height = 300;

            Label selectLabel = new Label()
            {
                Text = "Select save format:",
                Font = new Font("Arial", 10),
                Size = new Size(200, 30),
                Location = new Point(10, 10),
                Visible = true
            };

            Controls.Add(selectLabel);

            for (int i = 0; i < 4; i++)
            {
                Button button = new Button()
                {
                    Text = (SaveType)i + " format",
                    Size = new Size(150, 40),
                    Location = new Point(10, 40 + i * 50),
                    Visible = true
                };

                SaveType type = (SaveType)i;
                button.Click += (s, e) =>
                {
                    ResultForm resForm = new ResultForm(type);
                    resForm.Show();
                    this.Hide();
                    resForm.FormClosed += (sen, ev) => this.Show();
                };

                Controls.Add(button);
            }
        }
    }
}
