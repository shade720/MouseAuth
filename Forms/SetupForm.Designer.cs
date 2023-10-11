namespace MouseAuth.Forms
{
    partial class SetupForm
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
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            Canvas = new Panel();
            StartTest = new Button();
            StopTest = new Button();
            label3 = new Label();
            TestingPartLabel = new Label();
            label5 = new Label();
            label4 = new Label();
            TestsCountLabel = new Label();
            OptionsLinkLabel = new LinkLabel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Controls.Add(label2);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(606, 38);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(173, 7);
            label2.Name = "label2";
            label2.Size = new Size(251, 22);
            label2.TabIndex = 2;
            label2.Text = "Калибровка параметров";
            // 
            // label1
            // 
            label1.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(322, 82);
            label1.Name = "label1";
            label1.Size = new Size(280, 96);
            label1.TabIndex = 1;
            label1.Text = "Для дальнейшего распознавания вас по вашим движениям мыши необходимо пройти серию тестов, которые позволят произвести начальную настройку параметров идентификации.\r\n";
            // 
            // Canvas
            // 
            Canvas.BorderStyle = BorderStyle.FixedSingle;
            Canvas.Location = new Point(21, 54);
            Canvas.Margin = new Padding(3, 2, 3, 2);
            Canvas.Name = "Canvas";
            Canvas.Size = new Size(281, 244);
            Canvas.TabIndex = 2;
            // 
            // StartTest
            // 
            StartTest.FlatStyle = FlatStyle.Flat;
            StartTest.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            StartTest.Location = new Point(21, 300);
            StartTest.Margin = new Padding(3, 2, 3, 2);
            StartTest.Name = "StartTest";
            StartTest.Size = new Size(281, 34);
            StartTest.TabIndex = 3;
            StartTest.Text = "Старт";
            StartTest.UseVisualStyleBackColor = true;
            StartTest.Click += StartTest_Click;
            // 
            // StopTest
            // 
            StopTest.FlatStyle = FlatStyle.Flat;
            StopTest.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            StopTest.Location = new Point(21, 300);
            StopTest.Margin = new Padding(3, 2, 3, 2);
            StopTest.Name = "StopTest";
            StopTest.Size = new Size(280, 34);
            StopTest.TabIndex = 4;
            StopTest.Text = "Стоп";
            StopTest.UseVisualStyleBackColor = true;
            StopTest.Click += StopTest_Click;
            // 
            // label3
            // 
            label3.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(322, 196);
            label3.Name = "label3";
            label3.Size = new Size(280, 96);
            label3.TabIndex = 5;
            label3.Text = "Процедура тестирования заключается в последовательном нажатии кнопок по доступности в течении 10 секунд, в результате чего будут собраны необходимые биометрические данные.";
            // 
            // TestingPartLabel
            // 
            TestingPartLabel.AutoSize = true;
            TestingPartLabel.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TestingPartLabel.Location = new Point(373, 54);
            TestingPartLabel.Name = "TestingPartLabel";
            TestingPartLabel.Size = new Size(19, 21);
            TestingPartLabel.TabIndex = 6;
            TestingPartLabel.Text = "1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(385, 54);
            label5.Name = "label5";
            label5.Size = new Size(21, 21);
            label5.TabIndex = 7;
            label5.Text = "/ ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(322, 54);
            label4.Name = "label4";
            label4.Size = new Size(44, 21);
            label4.TabIndex = 8;
            label4.Text = "Тест";
            // 
            // TestsCountLabel
            // 
            TestsCountLabel.AutoSize = true;
            TestsCountLabel.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TestsCountLabel.Location = new Point(397, 54);
            TestsCountLabel.Name = "TestsCountLabel";
            TestsCountLabel.Size = new Size(19, 21);
            TestsCountLabel.TabIndex = 9;
            TestsCountLabel.Text = "3";
            // 
            // OptionsLinkLabel
            // 
            OptionsLinkLabel.AutoSize = true;
            OptionsLinkLabel.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            OptionsLinkLabel.Location = new Point(538, 308);
            OptionsLinkLabel.Name = "OptionsLinkLabel";
            OptionsLinkLabel.Size = new Size(56, 19);
            OptionsLinkLabel.TabIndex = 10;
            OptionsLinkLabel.TabStop = true;
            OptionsLinkLabel.Text = "Опции";
            OptionsLinkLabel.MouseClick += OptionsLinkLabel_MouseClick;
            // 
            // SetupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(606, 352);
            Controls.Add(OptionsLinkLabel);
            Controls.Add(TestsCountLabel);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(TestingPartLabel);
            Controls.Add(label3);
            Controls.Add(StartTest);
            Controls.Add(Canvas);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(StopTest);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SetupForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Окно калибровки";
            FormClosing += SetupForm_FormClosing;
            Load += SetupForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel Canvas;
        private Label label2;
        private Button StartTest;
        private Button StopTest;
        private Label label3;
        private Label TestingPartLabel;
        private Label label5;
        private Label label4;
        private Label TestsCountLabel;
        private LinkLabel OptionsLinkLabel;
    }
}