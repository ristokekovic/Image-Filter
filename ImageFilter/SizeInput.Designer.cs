namespace ImageFilter
{
    partial class SizeInput
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
            this.bufferSizeInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bufferSizeInput
            // 
            this.bufferSizeInput.Location = new System.Drawing.Point(118, 118);
            this.bufferSizeInput.Name = "bufferSizeInput";
            this.bufferSizeInput.Size = new System.Drawing.Size(120, 22);
            this.bufferSizeInput.TabIndex = 16;
            this.bufferSizeInput.Text = "10";
            this.bufferSizeInput.TextChanged += new System.EventHandler(this.Red_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(45, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Size";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 28);
            this.label1.TabIndex = 14;
            this.label1.Text = "Enter the size of undo and redo buffer";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(48, 159);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(90, 27);
            this.OK.TabIndex = 18;
            this.OK.Text = "OK";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(153, 159);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(90, 27);
            this.Cancel.TabIndex = 17;
            this.Cancel.Text = "Cancel";
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // SizeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.bufferSizeInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SizeInput";
            this.Text = "SizeInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox bufferSizeInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
    }
}