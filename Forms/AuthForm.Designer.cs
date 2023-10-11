namespace MouseAuth.Forms
{
    partial class AuthForm
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
            label1 = new Label();
            Canvas = new Panel();
            StartTest = new Button();
            StopTest = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(281, 38);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(51, 8);
            label1.Name = "label1";
            label1.Size = new Size(173, 22);
            label1.TabIndex = 0;
            label1.Text = "Аутентификация";
            // 
            // Canvas
            // 
            Canvas.BackColor = Color.White;
            Canvas.Location = new Point(0, 36);
            Canvas.Margin = new Padding(3, 2, 3, 2);
            Canvas.Name = "Canvas";
            Canvas.Size = new Size(281, 244);
            Canvas.TabIndex = 1;
            // 
            // StartTest
            // 
            StartTest.FlatStyle = FlatStyle.Flat;
            StartTest.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            StartTest.Location = new Point(0, 280);
            StartTest.Margin = new Padding(3, 2, 3, 2);
            StartTest.Name = "StartTest";
            StartTest.Size = new Size(280, 34);
            StartTest.TabIndex = 5;
            StartTest.Text = "Старт";
            StartTest.UseVisualStyleBackColor = true;
            StartTest.Click += StartTest_Click;
            // 
            // StopTest
            // 
            StopTest.FlatStyle = FlatStyle.Flat;
            StopTest.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            StopTest.Location = new Point(0, 280);
            StopTest.Margin = new Padding(3, 2, 3, 2);
            StopTest.Name = "StopTest";
            StopTest.Size = new Size(280, 34);
            StopTest.TabIndex = 6;
            StopTest.Text = "Стоп";
            StopTest.UseVisualStyleBackColor = true;
            StopTest.Click += StopTest_Click;
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(281, 315);
            Controls.Add(StartTest);
            Controls.Add(StopTest);
            Controls.Add(Canvas);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AuthForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += AuthForm_FormClosing;
            Load += AuthForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel Canvas;
        private Button StartTest;
        private Button StopTest;
    }
}