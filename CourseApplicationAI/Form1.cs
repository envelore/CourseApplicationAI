using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CourseApplicationAI
{
    public partial class основнаяФорма : Form
    {
        public основнаяФорма()
        {
            InitializeComponent();
            //hashToImage["0000"] = "null";
        }

        static public string imagesPath = "";
        static public Dictionary<string, string> hashToImage;
        static public Dictionary<string, string> hashToPathImage = new Dictionary<string, string>();
        static public Stream reading = null;
        private void PictureBox201_DoubleClick(object sender, EventArgs e)
        {
            MapSettingForm setup = new MapSettingForm();
            setup.parentImageBox = sender as PictureBox;
            setup.Show();
        }

        private void ВизулизацияButton_Click(object sender, EventArgs e)
        {
            foreach (Control picture in this.панельОтображающаяКарту.Controls)
            {
                if (picture.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    (picture as PictureBox).BorderStyle = BorderStyle.None;
                    (picture as PictureBox).Enabled = false;
                }
            }
        }

        private void РедактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control picture in this.панельОтображающаяКарту.Controls)
            {
                if (picture.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    (picture as PictureBox).BorderStyle = BorderStyle.FixedSingle;
                    (picture as PictureBox).Enabled = true;
                }
            }
        }

        private void СоздатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openpath = new FolderBrowserDialog();
            openpath.ShowDialog();
            imagesPath = openpath.SelectedPath;
            путьНеЗаданToolStripMenuItem.Text = imagesPath;
            путьНеЗаданToolStripMenuItem.ForeColor = Color.Green;
            string[] filesname = Directory.GetFiles(основнаяФорма.imagesPath, "*.png").ToArray<string>();
            Image tempForHash;
            foreach (string path in filesname)
            {
                tempForHash = Image.FromFile(path);
                byte[] buffer = imageToByteArray(tempForHash);
                var hash = getMd5Hash(buffer);
                hashToPathImage[hash] = path;
            }
            структураКартыToolStripMenuItem.Enabled = true;
            графическиеОбъектыToolStripMenuItem.ForeColor = Color.Black;
        }

        private void СгенерироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var genForm = new GenerateForm();
            genForm.parent = this;
            genForm.Show();
        }
        static string getMd5Hash(byte[] buffer)
        {
            MD5 md5Hasher = MD5.Create();

            byte[] data = md5Hasher.ComputeHash(buffer);

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        static byte[] imageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }

        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> content = new List<string>();
            var path = "";
            var dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.Filter = "Карта(*.ai)|*.ai";
            dialog.ShowDialog();
            path = dialog.FileName;
            if ((path == "")||(path == null)) { return; };
            //File.Create(path);
            
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            foreach (Control picture in this.панельОтображающаяКарту.Controls)
            {
                if (picture.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    var pic = picture as PictureBox;
                    var x = pic.Location.X / 45;
                    var y = pic.Location.Y / 45;
                    string hash;
                    if (pic.Image != null)
                    {
                        byte[] buffer = imageToByteArray(pic.Image);
                        hash = getMd5Hash(buffer);
                    } else
                    {
                        hash = "0000";
                    }
                    content.Add("<x=" + x.ToString() + " y=" + y.ToString() + " pictureHash=" + hash + ">");
                }
            }
            File.WriteAllLines(path, content);
        }

        private void ЗагрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.AddExtension = true;
            dialog.Filter = "Карта(*.ai)|*.ai";
            dialog.ShowDialog();
            if ((dialog.FileName == "") || (dialog.FileName == null)) { return; }
            string[] readText = File.ReadAllLines(dialog.FileName);
            foreach (var str in readText)
            {
                int i = 0;
                while (str[i] != '=') i++;
                i++;
                string str_x = "";
                while (str[i] != ' ')
                {
                    str_x += str[i];
                    i++;
                }
                int x = Convert.ToInt32(str_x);

                while (str[i] != '=') i++;
                i++;
                string str_y = "";
                while (str[i] != ' ')
                {
                    str_y += str[i];
                    i++;
                }
                int y = Convert.ToInt32(str_y);

                while (str[i] != '=') i++;
                i++;
                string str_hash = "";
                while (str[i] != '>')
                {
                    str_hash += str[i];
                    i++;
                }
                foreach (Control picture in this.панельОтображающаяКарту.Controls)
                {
                    if (picture.GetType().ToString() == "System.Windows.Forms.PictureBox")
                    {
                        var pic = picture as PictureBox;
                        if ((pic.Location.X == x*45) && (pic.Location.Y == y*45))
                        {
                            pic.ImageLocation = hashToPathImage[str_hash];
                        }
                    }
                }
            }
            
            MessageBox.Show("Loaded!");
            
        }
        private void TestButton_Click(object sender, EventArgs e)
        {
            /* if (reading == null)
             {
                 var dialog = new OpenFileDialog();
                 dialog.AddExtension = true;
                 dialog.Filter = "Карта(*.ai)|*.ai";
                 dialog.ShowDialog();
                 if ((dialog.FileName == "") || (dialog.FileName == null)) { return; }
                 //var str = dialog.OpenFile();
                 reading = dialog.OpenFile();
             }
             testText.Text = ((char)reading.ReadByte()).ToString();*/

            string result = "";
            foreach (var val in hashToPathImage)
            {
                result += val.Key + ":" + val.Value + "\n";
            }
            MessageBox.Show(result + sizeof(char).ToString());
        }

        private void СоздатьИИToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAI view = new CreateAI(this.панельОтображающаяКарту);
            view.Show();
        }
    }
}
