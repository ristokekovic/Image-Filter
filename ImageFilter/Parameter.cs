using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework;

namespace ImageFilter
{
	/// <summary>
	/// Summary description for Parameter.
	/// </summary>
	public class Parameter : MetroFramework.Forms.MetroForm
	{
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.TextBox Value;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public int nValue
		{
			get 
			{
				return (Convert.ToInt32(Value.Text, 10));
			}
			set{Value.Text = value.ToString();}
		}

		public Parameter()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
            this.Value = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(23, 125);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(90, 26);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(129, 125);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(90, 26);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            // 
            // Value
            // 
            this.Value.Location = new System.Drawing.Point(100, 78);
            this.Value.Name = "Value";
            this.Value.Size = new System.Drawing.Size(120, 22);
            this.Value.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Factor";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Parameter
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(247, 183);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Value);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Name = "Parameter";
            this.Text = "Parameter";
            this.Load += new System.EventHandler(this.Parameter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void Parameter_Load(object sender, System.EventArgs e)
		{
		
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
