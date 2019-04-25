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
    public partial class IdeasBaseForm : Form
    {
        CreateAI source;
        Idea idea;
        DataGridViewRow row;
        public IdeasBaseForm(CreateAI src, Idea act, DataGridViewRow row)
        {
            InitializeComponent();
            source = src;
            idea = act;
            (tableViewFactorsAct.Columns[0] as DataGridViewComboBoxColumn).DataSource = source.factors;
            (tableViewFactorsAct.Columns[0] as DataGridViewComboBoxColumn).DisplayMember = "name";
            textBoxAction.Text = act.name;
            this.row = row;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            List<(Factor, double)> weights = new List<(Factor, double)>();
            foreach (DataGridViewRow row in tableViewFactorsAct.Rows)
            {
                if (row.Index != tableViewFactorsAct.Rows.Count-1)
                {
                    (Factor, double) weight = (null, 0);
                    foreach (var cell in row.Cells)
                    {
                        if (cell as DataGridViewComboBoxCell != null)
                        {
                            MessageBox.Show((cell as DataGridViewComboBoxCell).Value as string);
                            weight.Item1 = source.factors.First<Factor>(f => f.name == (cell as DataGridViewComboBoxCell).Value as string);
                        }
                        if (cell as DataGridViewTextBoxCell != null)
                        {
                            weight.Item2 = Convert.ToDouble((cell as DataGridViewTextBoxCell).Value as string);
                        }
                    }
                    weights.Add(weight);
                }
            }
            source.ideas.First<Idea>(i => i.name == textBoxAction.Text).weights = weights;
            (row.Cells[0] as DataGridViewCheckBoxCell).Value = true;
            /*MessageBox.Show(source.ideas.First<Idea>(i => i.name == textBoxAction.Text).name);
            foreach ( var w in weights)
            {
                MessageBox.Show(w.Item1.name + " : " + w.Item2.ToString());
            }*/
            this.Close();
        }
    }
}
