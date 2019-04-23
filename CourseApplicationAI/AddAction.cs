using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CourseApplicationAI
{
    public partial class AddAction : Form
    {
        CreateAI source;
        public BindingList<ChangeOfParam> changes = new BindingList<ChangeOfParam>();
        public AddAction(CreateAI src)
        {
            InitializeComponent();
            source = src;
            ChangeOfParam change = new ChangeOfParam(src.parametrs);
            changes.Add(change);
            (tableActionsParametrs.Columns[0] as DataGridViewComboBoxColumn).DataSource = source.parametrs;
            (tableActionsParametrs.Columns[0] as DataGridViewComboBoxColumn).DisplayMember = "name";
            //(tableActionsParametrs.Columns[0] as DataGridViewComboBoxColumn).DataPropertyName = "name";
            //MessageBox.Show((tableActionsParametrs.Columns[0] as DataGridViewComboBoxColumn).Items.Count.ToString());
            tableActionsParametrs.Rows.Add();
            tableActionsParametrs.Update();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            tableActionsParametrs.Enabled = checkBox1.Checked ? true : false;
            buttonPlus.Enabled = checkBox1.Checked ? true : false;
            buttonMinus.Enabled = checkBox1.Checked ? true : false;
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxFrom.Enabled = checkBox2.Checked ? true : false;
            comboBoxTo.Enabled = checkBox2.Checked ? true : false;
        }

        

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            List<(Parametr, int)> changes = new List<(Parametr, int)>();
            foreach (DataGridViewRow row in tableActionsParametrs.Rows)
            {
                (Parametr, int) change = (null, 0);
                foreach (var cell in row.Cells)
                {
                    if (cell as DataGridViewComboBoxCell != null)
                    {
                        var find = (cell as DataGridViewComboBoxCell).Value as string;
                        change.Item1 = source.parametrs.First<Parametr>(p => p.name == find);
                    }
                    if (cell as DataGridViewTextBoxCell != null)
                    {
                        var find = (cell as DataGridViewTextBoxCell).Value as string;
                        change.Item2 = Convert.ToInt32(find);
                    }
                }
                changes.Add(change);
            }
            Action newAct = new Action(textBox1.Text, comboBoxFrom.SelectedItem as string, comboBoxTo.SelectedItem as string, changes, 0, 0);
            //MessageBox.Show(changes.Count.ToString());
            source.actions.Add(newAct);
            source.generateIdeaList();
            this.Close();
        }
    }
}

public class ChangeOfParam
{
    public BindingList<Parametr> parametrs { get; set; }
    public Parametr current { get; set; }
    public string deltaValue { get; set; }

    public ChangeOfParam(BindingList<Parametr> parametrs)
    {
        this.parametrs = parametrs;
    }

}
