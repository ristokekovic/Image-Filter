namespace ImageFilter.Views
{
    partial class ChannelView
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
            this.originalImage = new System.Windows.Forms.PictureBox();
            this.firstChannel = new System.Windows.Forms.PictureBox();
            this.secondChannel = new System.Windows.Forms.PictureBox();
            this.thirdChannel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdChannel)).BeginInit();
            this.SuspendLayout();
            // 
            // originalImage
            // 
            this.originalImage.Location = new System.Drawing.Point(4, 4);
            this.originalImage.Name = "originalImage";
            this.originalImage.Size = new System.Drawing.Size(324, 181);
            this.originalImage.TabIndex = 0;
            this.originalImage.TabStop = false;
            this.originalImage.Click += new System.EventHandler(this.originalImage_Click);
            // 
            // firstChannel
            // 
            this.firstChannel.Location = new System.Drawing.Point(334, 4);
            this.firstChannel.Name = "firstChannel";
            this.firstChannel.Size = new System.Drawing.Size(348, 181);
            this.firstChannel.TabIndex = 1;
            this.firstChannel.TabStop = false;
            // 
            // secondChannel
            // 
            this.secondChannel.Location = new System.Drawing.Point(4, 192);
            this.secondChannel.Name = "secondChannel";
            this.secondChannel.Size = new System.Drawing.Size(324, 185);
            this.secondChannel.TabIndex = 2;
            this.secondChannel.TabStop = false;
            // 
            // thirdChannel
            // 
            this.thirdChannel.Location = new System.Drawing.Point(335, 192);
            this.thirdChannel.Name = "thirdChannel";
            this.thirdChannel.Size = new System.Drawing.Size(347, 185);
            this.thirdChannel.TabIndex = 3;
            this.thirdChannel.TabStop = false;
            // 
            // ChannelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.thirdChannel);
            this.Controls.Add(this.secondChannel);
            this.Controls.Add(this.firstChannel);
            this.Controls.Add(this.originalImage);
            this.Name = "ChannelView";
            this.Size = new System.Drawing.Size(685, 390);
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdChannel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox originalImage;
        private System.Windows.Forms.PictureBox firstChannel;
        private System.Windows.Forms.PictureBox secondChannel;
        private System.Windows.Forms.PictureBox thirdChannel;
    }
}
