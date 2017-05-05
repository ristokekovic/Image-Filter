namespace ImageFilter.Views
{
    partial class BaseView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.message = new System.Windows.Forms.Label();
            this.baseImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.baseImage)).BeginInit();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(247, 191);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(154, 17);
            this.message.TabIndex = 0;
            this.message.Text = "Please select an image";
            // 
            // baseImage
            // 
            this.baseImage.InitialImage = null;
            this.baseImage.Location = new System.Drawing.Point(4, 4);
            this.baseImage.Name = "baseImage";
            this.baseImage.Size = new System.Drawing.Size(649, 336);
            this.baseImage.TabIndex = 1;
            this.baseImage.TabStop = false;
            this.baseImage.Visible = false;
            this.baseImage.Click += new System.EventHandler(this.baseImage_Click);
            // 
            // BaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.baseImage);
            this.Controls.Add(this.message);
            this.Name = "BaseView";
            this.Size = new System.Drawing.Size(656, 400);
            ((System.ComponentModel.ISupportInitialize)(this.baseImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label message;
        private System.Windows.Forms.PictureBox baseImage;
    }
}
