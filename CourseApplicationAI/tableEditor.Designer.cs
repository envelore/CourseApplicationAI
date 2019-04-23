namespace CourseApplicationAI
{
    partial class tableEditor
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
            this.comboBoxStatement = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelWatch = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.distanceBox = new System.Windows.Forms.NumericUpDown();
            this.imagesBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelParametr = new System.Windows.Forms.Panel();
            this.attitudeBox = new System.Windows.Forms.DomainUpDown();
            this.valueParametr = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.parametrBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelAction = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.actionBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.panelWatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distanceBox)).BeginInit();
            this.panelParametr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valueParametr)).BeginInit();
            this.panelAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxStatement
            // 
            this.comboBoxStatement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatement.FormattingEnabled = true;
            this.comboBoxStatement.Items.AddRange(new object[] {
            "Наблюдаю...",
            "Могу совершить действие...",
            "Состояние моего параметра..."});
            this.comboBoxStatement.Location = new System.Drawing.Point(173, 34);
            this.comboBoxStatement.Name = "comboBoxStatement";
            this.comboBoxStatement.Size = new System.Drawing.Size(156, 21);
            this.comboBoxStatement.TabIndex = 0;
            this.comboBoxStatement.SelectedIndexChanged += new System.EventHandler(this.ComboBoxStatement_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Утверждение:";
            // 
            // panelWatch
            // 
            this.panelWatch.Controls.Add(this.label3);
            this.panelWatch.Controls.Add(this.distanceBox);
            this.panelWatch.Controls.Add(this.imagesBox);
            this.panelWatch.Controls.Add(this.label2);
            this.panelWatch.Location = new System.Drawing.Point(335, 7);
            this.panelWatch.Name = "panelWatch";
            this.panelWatch.Size = new System.Drawing.Size(346, 60);
            this.panelWatch.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "На расстоянии:";
            // 
            // distanceBox
            // 
            this.distanceBox.Location = new System.Drawing.Point(262, 27);
            this.distanceBox.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.distanceBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.distanceBox.Name = "distanceBox";
            this.distanceBox.Size = new System.Drawing.Size(81, 20);
            this.distanceBox.TabIndex = 2;
            this.distanceBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // imagesBox
            // 
            this.imagesBox.FormattingEnabled = true;
            this.imagesBox.Location = new System.Drawing.Point(6, 27);
            this.imagesBox.Name = "imagesBox";
            this.imagesBox.Size = new System.Drawing.Size(250, 21);
            this.imagesBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Какую клетку:";
            // 
            // panelParametr
            // 
            this.panelParametr.Controls.Add(this.attitudeBox);
            this.panelParametr.Controls.Add(this.valueParametr);
            this.panelParametr.Controls.Add(this.label5);
            this.panelParametr.Controls.Add(this.label4);
            this.panelParametr.Controls.Add(this.parametrBox);
            this.panelParametr.Location = new System.Drawing.Point(335, 7);
            this.panelParametr.Name = "panelParametr";
            this.panelParametr.Size = new System.Drawing.Size(346, 60);
            this.panelParametr.TabIndex = 3;
            // 
            // attitudeBox
            // 
            this.attitudeBox.Items.Add(">");
            this.attitudeBox.Items.Add("=");
            this.attitudeBox.Items.Add("<");
            this.attitudeBox.Location = new System.Drawing.Point(184, 28);
            this.attitudeBox.Name = "attitudeBox";
            this.attitudeBox.Size = new System.Drawing.Size(33, 20);
            this.attitudeBox.TabIndex = 4;
            this.attitudeBox.Text = "=";
            // 
            // valueParametr
            // 
            this.valueParametr.Location = new System.Drawing.Point(223, 28);
            this.valueParametr.Name = "valueParametr";
            this.valueParametr.Size = new System.Drawing.Size(120, 20);
            this.valueParametr.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Значение параметра:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Какой параметр:";
            // 
            // parametrBox
            // 
            this.parametrBox.FormattingEnabled = true;
            this.parametrBox.Location = new System.Drawing.Point(6, 27);
            this.parametrBox.Name = "parametrBox";
            this.parametrBox.Size = new System.Drawing.Size(172, 21);
            this.parametrBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(606, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(519, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.label7);
            this.panelAction.Controls.Add(this.actionBox);
            this.panelAction.Location = new System.Drawing.Point(335, 7);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(346, 60);
            this.panelAction.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Какое действие:";
            // 
            // actionBox
            // 
            this.actionBox.FormattingEnabled = true;
            this.actionBox.Location = new System.Drawing.Point(6, 27);
            this.actionBox.Name = "actionBox";
            this.actionBox.Size = new System.Drawing.Size(334, 21);
            this.actionBox.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Название фактора:";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(12, 35);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(155, 20);
            this.textBoxID.TabIndex = 7;
            // 
            // tableEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 112);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panelParametr);
            this.Controls.Add(this.panelAction);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelWatch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxStatement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "tableEditor";
            this.Text = "tableEditor";
            this.panelWatch.ResumeLayout(false);
            this.panelWatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distanceBox)).EndInit();
            this.panelParametr.ResumeLayout(false);
            this.panelParametr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valueParametr)).EndInit();
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStatement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelWatch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown distanceBox;
        private System.Windows.Forms.ComboBox imagesBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelParametr;
        private System.Windows.Forms.NumericUpDown valueParametr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox parametrBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DomainUpDown attitudeBox;
        private System.Windows.Forms.Panel panelAction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox actionBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxID;
    }
}