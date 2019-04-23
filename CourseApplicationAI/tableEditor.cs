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
    public partial class tableEditor : Form
    {
        public DataGridView source;
        public CreateAI creator;

        public tableEditor()
        {
            InitializeComponent();
            initPanelVisiable();
            comboBoxStatement.SelectedIndex = 0;
            if (основнаяФорма.imagesPath != "")
            {
                string[] filesname = Directory.GetFiles(основнаяФорма.imagesPath, "*.png").ToArray<string>();
                imagesBox.DataSource = filesname;
            }
        }

        private void initPanelVisiable()
        {
            switch (this.comboBoxStatement.SelectedIndex)
            {
                case 0:
                    {
                        panelWatch.Visible = true;
                        panelAction.Visible = false;
                        panelParametr.Visible = false; panelWatch.Visible = true;
                    }
                    break;
                case 1:
                    {
                        panelAction.Visible = true;
                        panelWatch.Visible = false; panelAction.Visible = true;
                        panelParametr.Visible = false; panelAction.Visible = true;
                    }
                    break;
                case 2:
                    {
                        panelParametr.Visible = true;
                        panelWatch.Visible = false;
                        panelAction.Visible = false;
                        panelParametr.Visible = true;
                    }
                    break;
            }
        }

        private void ComboBoxStatement_SelectedIndexChanged(object sender, EventArgs e)
        {
            initPanelVisiable();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var type = comboBoxStatement.SelectedText;

            switch (type)
            {
                case "Наблюдаю...":
                    break;
                case "Могу совершить действие...":
                    break;
                case "Состояние моего параметра...":
                    break;
            }
            Factor newFactor = new Factor()
            (source.DataSource as List<Factor>).Add()
            this.Close();
        }
    }
}


