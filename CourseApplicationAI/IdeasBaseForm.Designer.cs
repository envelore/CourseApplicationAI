namespace CourseApplicationAI
{
    partial class IdeasBaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableViewFactorsAct = new System.Windows.Forms.DataGridView();
            this.textBoxAction = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tableViewFactorsAct)).BeginInit();
            this.SuspendLayout();
            // 
            // tableViewFactorsAct
            // 
            this.tableViewFactorsAct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableViewFactorsAct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableViewFactorsAct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.tableViewFactorsAct.Location = new System.Drawing.Point(211, 12);
            this.tableViewFactorsAct.Name = "tableViewFactorsAct";
            this.tableViewFactorsAct.RowHeadersVisible = false;
            this.tableViewFactorsAct.Size = new System.Drawing.Size(331, 150);
            this.tableViewFactorsAct.TabIndex = 0;
            // 
            // textBoxAction
            // 
            this.textBoxAction.Location = new System.Drawing.Point(12, 12);
            this.textBoxAction.Name = "textBoxAction";
            this.textBoxAction.ReadOnly = true;
            this.textBoxAction.Size = new System.Drawing.Size(185, 20);
            this.textBoxAction.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Фактор";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Вес (Double)";
            this.Column2.Name = "Column2";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(445, 168);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(96, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Оставь последнюю строку пустой!";
            // 
            // IdeasBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 202);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxAction);
            this.Controls.Add(this.tableViewFactorsAct);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IdeasBaseForm";
            this.Text = "Факторы";
            ((System.ComponentModel.ISupportInitialize)(this.tableViewFactorsAct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tableViewFactorsAct;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox textBoxAction;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
    }
}