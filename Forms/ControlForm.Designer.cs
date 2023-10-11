namespace MouseAuth.Forms
{
    partial class ControlForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
            Worker = new System.ComponentModel.BackgroundWorker();
            NotifyIcon = new NotifyIcon(components);
            SuspendLayout();
            // 
            // Worker
            // 
            Worker.WorkerSupportsCancellation = true;
            Worker.DoWork += Worker_DoWork;
            // 
            // NotifyIcon
            // 
            NotifyIcon.Icon = (Icon)resources.GetObject("NotifyIcon.Icon");
            NotifyIcon.Text = "MouseAuth";
            NotifyIcon.Visible = true;
            // 
            // ControlForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Name = "ControlForm";
            Opacity = 0D;
            ShowInTaskbar = false;
            Text = "ControlForm";
            FormClosing += ControlForm_FormClosing;
            Load += ControlForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker Worker;
        private NotifyIcon NotifyIcon;
    }
}