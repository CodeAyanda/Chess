
namespace Chess
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.whitesTurnText = new System.Windows.Forms.Label();
            this.blacksTurnText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // whitesTurnText
            // 
            this.whitesTurnText.AutoSize = true;
            this.whitesTurnText.Font = new System.Drawing.Font("Segoe UI", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whitesTurnText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.whitesTurnText.Location = new System.Drawing.Point(56, 44);
            this.whitesTurnText.Name = "whitesTurnText";
            this.whitesTurnText.Size = new System.Drawing.Size(181, 71);
            this.whitesTurnText.TabIndex = 0;
            this.whitesTurnText.Text = "label1";
            // 
            // blacksTurnText
            // 
            this.blacksTurnText.AutoSize = true;
            this.blacksTurnText.Font = new System.Drawing.Font("Segoe UI", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blacksTurnText.Location = new System.Drawing.Point(56, 168);
            this.blacksTurnText.Name = "blacksTurnText";
            this.blacksTurnText.Size = new System.Drawing.Size(181, 71);
            this.blacksTurnText.TabIndex = 1;
            this.blacksTurnText.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(850, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 105);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1363, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.blacksTurnText);
            this.Controls.Add(this.whitesTurnText);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label whitesTurnText;
        private System.Windows.Forms.Label blacksTurnText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer2;
    }
}

