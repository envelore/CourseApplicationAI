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
    public partial class MapSettingForm : Form
    {

        public PictureBox parentImageBox;

        public MapSettingForm()
        {
            InitializeComponent();
            if (основнаяФорма.imagesPath != "")
            {
                string[] files2 = Directory.GetFiles(основнаяФорма.imagesPath, "*.png");
                List<string> filesname = Directory.GetFiles(основнаяФорма.imagesPath, "*.png").ToList<string>();
                comboBoxImages.DataSource = filesname;
                if (parentImageBox != null)
                {
                    pictureBoxPreview.Image = parentImageBox.Image;
                    comboBoxImages.Text = parentImageBox.ImageLocation;
                }
            }
        }

        private void ComboBoxImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxImages.Text != "")
            {
                pictureBoxPreview.Image = Image.FromFile(comboBoxImages.Text);
                pictureBoxPreview.Update();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBoxImages.Text != "")
            {
                parentImageBox.Image = Image.FromFile(comboBoxImages.Text);
                parentImageBox.Update();
            }
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            parentImageBox.Image = parentImageBox.InitialImage;
            this.Close();
        }
    }
}
