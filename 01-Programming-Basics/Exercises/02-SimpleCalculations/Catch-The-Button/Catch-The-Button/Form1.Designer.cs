namespace Catch_The_Button
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
            this.buttonCatchMe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCatchMe
            // 
            this.buttonCatchMe.Location = new System.Drawing.Point(94, 166);
            this.buttonCatchMe.Name = "buttonCatchMe";
            this.buttonCatchMe.Size = new System.Drawing.Size(75, 49);
            this.buttonCatchMe.TabIndex = 0;
            this.buttonCatchMe.Text = "Catch Me!";
            this.buttonCatchMe.UseVisualStyleBackColor = true;
            this.buttonCatchMe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonCatchMe_MouseClick);
            this.buttonCatchMe.MouseEnter += new System.EventHandler(this.buttonCatchMe_MouseEnter);
            this.buttonCatchMe.MouseLeave += new System.EventHandler(this.buttonCatchMe_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Catch The Button!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 249);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCatchMe);
            this.Name = "Form1";
            this.Text = "Catch The Button";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCatchMe;
        private System.Windows.Forms.Label label1;
    }
}

