using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CourseApplicationAI
{
    public partial class GenerateForm : Form
    {
        public GenerateForm()
        {
            InitializeComponent();
            string[] filesname = Directory.GetFiles(основнаяФорма.imagesPath, "*.png").ToArray<string>();
            listBox.DataSource = filesname;
        }

        public основнаяФорма parent;

        private void Button1_Click(object sender, EventArgs e)
        {
            if (основнаяФорма.imagesPath != "")
            {
                Random rand = new Random();
                foreach (Control picture in parent.панельОтображающаяКарту.Controls)
                {
                    if (picture.GetType().ToString() == "System.Windows.Forms.PictureBox")
                    {
                        (picture as PictureBox).Image = Image.FromFile(listBox.SelectedItems[rand.Next(listBox.SelectedItems.Count)] as string);
                    }
                }
            }
            this.Close();
        }
    }
}
