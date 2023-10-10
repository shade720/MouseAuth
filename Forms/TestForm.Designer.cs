namespace MouseAuth.Forms
{
    partial class TestForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            Button1 = new Button();
            Button2 = new Button();
            Button3 = new Button();
            Button4 = new Button();
            Button5 = new Button();
            TimerLabel = new Label();
            SuspendLayout();
            // 
            // Button1
            // 
            Button1.BackColor = Color.Transparent;
            Button1.BackgroundImage = (Image)resources.GetObject("Button1.BackgroundImage");
            Button1.BackgroundImageLayout = ImageLayout.Zoom;
            Button1.Enabled = false;
            Button1.FlatAppearance.BorderSize = 0;
            Button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Button1.FlatStyle = FlatStyle.Flat;
            Button1.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Button1.Location = new Point(19, 133);
            Button1.Name = "Button1";
            Button1.Size = new Size(50, 50);
            Button1.TabIndex = 1;
            Button1.UseVisualStyleBackColor = false;
            Button1.Click += Button1_Click;
            Button1.MouseDown += Button1_MouseDown;
            Button1.MouseHover += Button1_MouseHover;
            Button1.MouseUp += Button1_MouseUp;
            // 
            // Button2
            // 
            Button2.BackColor = Color.Transparent;
            Button2.BackgroundImage = (Image)resources.GetObject("Button2.BackgroundImage");
            Button2.BackgroundImageLayout = ImageLayout.Zoom;
            Button2.Enabled = false;
            Button2.FlatAppearance.BorderSize = 0;
            Button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Button2.FlatStyle = FlatStyle.Flat;
            Button2.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Button2.ForeColor = SystemColors.ControlText;
            Button2.Location = new Point(71, 241);
            Button2.Name = "Button2";
            Button2.Size = new Size(50, 50);
            Button2.TabIndex = 2;
            Button2.UseVisualStyleBackColor = false;
            Button2.Click += Button2_Click;
            Button2.MouseDown += Button2_MouseDown;
            Button2.MouseHover += Button2_MouseHover;
            Button2.MouseUp += Button2_MouseUp;
            // 
            // Button3
            // 
            Button3.BackColor = Color.Transparent;
            Button3.BackgroundImage = (Image)resources.GetObject("Button3.BackgroundImage");
            Button3.BackgroundImageLayout = ImageLayout.Zoom;
            Button3.Enabled = false;
            Button3.FlatAppearance.BorderSize = 0;
            Button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Button3.FlatStyle = FlatStyle.Flat;
            Button3.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Button3.Location = new Point(202, 241);
            Button3.Name = "Button3";
            Button3.Size = new Size(50, 50);
            Button3.TabIndex = 3;
            Button3.UseVisualStyleBackColor = false;
            Button3.Click += Button3_Click;
            Button3.MouseDown += Button3_MouseDown;
            Button3.MouseHover += Button3_MouseHover;
            Button3.MouseUp += Button3_MouseUp;
            // 
            // Button4
            // 
            Button4.BackColor = Color.Transparent;
            Button4.BackgroundImage = (Image)resources.GetObject("Button4.BackgroundImage");
            Button4.BackgroundImageLayout = ImageLayout.Zoom;
            Button4.Enabled = false;
            Button4.FlatAppearance.BorderSize = 0;
            Button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Button4.FlatStyle = FlatStyle.Flat;
            Button4.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Button4.Location = new Point(250, 133);
            Button4.Name = "Button4";
            Button4.Size = new Size(50, 50);
            Button4.TabIndex = 4;
            Button4.UseVisualStyleBackColor = false;
            Button4.Click += Button4_Click;
            Button4.MouseDown += Button4_MouseDown;
            Button4.MouseHover += Button4_MouseHover;
            Button4.MouseUp += Button4_MouseUp;
            // 
            // Button5
            // 
            Button5.BackColor = Color.Transparent;
            Button5.BackgroundImage = (Image)resources.GetObject("Button5.BackgroundImage");
            Button5.BackgroundImageLayout = ImageLayout.Zoom;
            Button5.Enabled = false;
            Button5.FlatAppearance.BorderSize = 0;
            Button5.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Button5.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Button5.FlatStyle = FlatStyle.Flat;
            Button5.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Button5.Location = new Point(136, 32);
            Button5.Name = "Button5";
            Button5.Size = new Size(50, 50);
            Button5.TabIndex = 5;
            Button5.UseVisualStyleBackColor = false;
            Button5.Click += Button5_Click;
            Button5.MouseDown += Button5_MouseDown;
            Button5.MouseHover += Button5_MouseHover;
            Button5.MouseUp += Button5_MouseUp;
            // 
            // TimerLabel
            // 
            TimerLabel.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TimerLabel.Location = new Point(136, 144);
            TimerLabel.Name = "TimerLabel";
            TimerLabel.Size = new Size(56, 48);
            TimerLabel.TabIndex = 8;
            TimerLabel.Text = "10";
            TimerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(321, 325);
            Controls.Add(TimerLabel);
            Controls.Add(Button5);
            Controls.Add(Button4);
            Controls.Add(Button3);
            Controls.Add(Button2);
            Controls.Add(Button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TestForm";
            MouseMove += MainForm_MouseMove;
            ResumeLayout(false);
        }

        #endregion

        private Button Button1;
        private Button Button2;
        private Button Button3;
        private Button Button4;
        private Button Button5;
        private Label TimerLabel;
    }
}