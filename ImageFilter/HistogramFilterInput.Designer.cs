namespace ImageFilter
{
    partial class HistogramFilterInput
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
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.n = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.k = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(39, 194);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(90, 27);
            this.OK.TabIndex = 23;
            this.OK.Text = "OK";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(144, 194);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(90, 27);
            this.Cancel.TabIndex = 22;
            this.Cancel.Text = "Cancel";
            // 
            // n
            // 
            this.n.Location = new System.Drawing.Point(109, 118);
            this.n.Name = "n";
            this.n.Size = new System.Drawing.Size(120, 22);
            this.n.TabIndex = 21;
            this.n.Text = "5";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(36, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "n";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 40);
            this.label1.TabIndex = 19;
            this.label1.Text = "Enter the number of zones (z) and number of pixels in each zone (k)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // k
            // 
            this.k.Location = new System.Drawing.Point(109, 146);
            this.k.Name = "k";
            this.k.Size = new System.Drawing.Size(120, 22);
            this.k.TabIndex = 25;
            this.k.Text = "50";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(36, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 19);
            this.label3.TabIndex = 24;
            this.label3.Text = "k";
            // 
            // HistogramFilterInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.k);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.n);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HistogramFilterInput";
            this.Text = "HistogramFilterInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox n;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox k;
        private System.Windows.Forms.Label label3;
    }
}