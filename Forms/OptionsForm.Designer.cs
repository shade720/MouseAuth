namespace MouseAuth.Forms
{
    partial class OptionsForm
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
            groupBox1 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            ReverificationPeriodComboBox = new ComboBox();
            SaveOptionsButton = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(ReverificationPeriodComboBox);
            groupBox1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(330, 234);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Опции";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(291, 43);
            label2.Name = "label2";
            label2.Size = new Size(35, 17);
            label2.TabIndex = 2;
            label2.Text = "сек.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(8, 43);
            label1.Name = "label1";
            label1.Size = new Size(213, 17);
            label1.TabIndex = 1;
            label1.Text = "Интервал повторной проверки";
            // 
            // ReverificationPeriodComboBox
            // 
            ReverificationPeriodComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ReverificationPeriodComboBox.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ReverificationPeriodComboBox.FormattingEnabled = true;
            ReverificationPeriodComboBox.Items.AddRange(new object[] { "1", "3", "5", "10", "15", "20", "30", "45", "60", "90", "180" });
            ReverificationPeriodComboBox.Location = new Point(227, 39);
            ReverificationPeriodComboBox.Name = "ReverificationPeriodComboBox";
            ReverificationPeriodComboBox.Size = new Size(64, 25);
            ReverificationPeriodComboBox.TabIndex = 0;
            // 
            // SaveOptionsButton
            // 
            SaveOptionsButton.FlatStyle = FlatStyle.Flat;
            SaveOptionsButton.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            SaveOptionsButton.Location = new Point(12, 251);
            SaveOptionsButton.Margin = new Padding(3, 2, 3, 2);
            SaveOptionsButton.Name = "SaveOptionsButton";
            SaveOptionsButton.Size = new Size(330, 34);
            SaveOptionsButton.TabIndex = 4;
            SaveOptionsButton.Text = "Сохранить";
            SaveOptionsButton.UseVisualStyleBackColor = true;
            SaveOptionsButton.Click += SaveOptionsButton_Click;
            // 
            // OptionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(354, 294);
            Controls.Add(SaveOptionsButton);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "OptionsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Опции тестирования";
            Load += OptionsForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private ComboBox ReverificationPeriodComboBox;
        private Button SaveOptionsButton;
        private Label label2;
    }
}