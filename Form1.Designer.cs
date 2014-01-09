namespace Cube
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
            this.m_layer1 = new System.Windows.Forms.PictureBox();
            this.m_layer2 = new System.Windows.Forms.PictureBox();
            this.m_layer3 = new System.Windows.Forms.PictureBox();
            this.m_layer4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_layer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_layer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_layer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_layer4)).BeginInit();
            this.SuspendLayout();
            // 
            // m_layer1
            // 
            this.m_layer1.Location = new System.Drawing.Point(24, 23);
            this.m_layer1.Name = "m_layer1";
            this.m_layer1.Size = new System.Drawing.Size(80, 80);
            this.m_layer1.TabIndex = 0;
            this.m_layer1.TabStop = false;
            // 
            // m_layer2
            // 
            this.m_layer2.Location = new System.Drawing.Point(137, 23);
            this.m_layer2.Name = "m_layer2";
            this.m_layer2.Size = new System.Drawing.Size(80, 80);
            this.m_layer2.TabIndex = 1;
            this.m_layer2.TabStop = false;
            // 
            // m_layer3
            // 
            this.m_layer3.Location = new System.Drawing.Point(24, 132);
            this.m_layer3.Name = "m_layer3";
            this.m_layer3.Size = new System.Drawing.Size(80, 80);
            this.m_layer3.TabIndex = 2;
            this.m_layer3.TabStop = false;
            // 
            // m_layer4
            // 
            this.m_layer4.Location = new System.Drawing.Point(137, 132);
            this.m_layer4.Name = "m_layer4";
            this.m_layer4.Size = new System.Drawing.Size(80, 80);
            this.m_layer4.TabIndex = 3;
            this.m_layer4.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 263);
            this.Controls.Add(this.m_layer4);
            this.Controls.Add(this.m_layer3);
            this.Controls.Add(this.m_layer2);
            this.Controls.Add(this.m_layer1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.m_layer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_layer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_layer3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_layer4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.PictureBox m_layer1;
        private System.Windows.Forms.PictureBox m_layer2;
        private System.Windows.Forms.PictureBox m_layer3;
        private System.Windows.Forms.PictureBox m_layer4;
    }
}

