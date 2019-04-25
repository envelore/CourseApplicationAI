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

        public tableEditor(CreateAI parent)
        {
            InitializeComponent();
            initPanelVisiable();
            comboBoxStatement.SelectedIndex = 0;
            comboBoxDirection.SelectedIndex = 0;
            parametrBox.DataSource = parent.parametrs;
            attitudeBox.SelectedIndex = 0;
            if (основнаяФорма.imagesPath != "")
            {
                string[] filesname = Directory.GetFiles(основнаяФорма.imagesPath, "*.png").ToArray<string>();
                imagesBox.DataSource = filesname;
            }
            creator = parent;
            actionBox.DataSource = creator.actions;
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
            var type = comboBoxStatement.SelectedItem as string;
            //MessageBox.Show(comboBoxStatement.SelectedItem as string);
            object[] parametrs = new object[3] ;
            string translateType = "";
            switch (type)
            {
                case "Наблюдаю...":
                    {
                        translateType = "watching";
                        parametrs[0] = imagesBox.Text;
                        parametrs[1] = distanceBox.Value;
                        parametrs[2] = comboBoxDirection.Text;
                    }
                        break;
                case "Могу совершить действие...":
                    {
                        translateType = "actionAvailable";
                        parametrs[0] = actionBox.Text;
                    }
                    break;
                case "Состояние моего параметра...":
                    {
                        translateType = "compare";
                        parametrs[0] = parametrBox.Text;
                        parametrs[1] = attitudeBox.Text;
                        parametrs[2] = valueParametr.Value;
                    }
                    break;
            }
            Factor newFactor = new Factor(textBoxID.Text, translateType, parametrs);
            creator.factors.Add(newFactor);
            //MessageBox.Show((source.DataSource as List<Factor>).Count.ToString());
            //MessageBox.Show(newFactor.name + " " + newFactor.type);
            source.DataSource = creator.factors;
            creator.tableViewFactors.Update();
            creator.tableViewActions.Update();
            source.Update();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //MessageBox.Show((creator.tableViewActions.DataSource as BindingList<Action>).Count.ToString());
        }
    }
}

/*{
        this.type = type;
        switch (type)
        {
            case "watching":
                whatDoesImageAISee = parametrs[0] as string;
                distanceWatch = (int)parametrs[1];
                break;
            case "compare":
                nameOfComparedParametr = parametrs[0] as string;
                typeCompare = parametrs[1] as string;
                valueOfCompare = (int)parametrs[2];
                break;
            case "actionAvailable":
                nameOfAction = parametrs[0] as string;
                break;
        }
    } */
