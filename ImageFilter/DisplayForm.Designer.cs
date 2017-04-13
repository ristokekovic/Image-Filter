namespace ImageFilter
{
    partial class DisplayForm
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
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroContextMenu2 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.channelView = new ImageFilter.Views.ChannelView();
            this.baseView = new ImageFilter.Views.BaseView();
            this.metroMenuStrip1 = new ModernUISample.metro.MetroMenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fIltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.x3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comparisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homogenityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displacementFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeWarpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoneFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unsafeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoRedoBufferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.histogramView = new ImageFilter.Views.HistogramView();
            this.showHistogram = new System.Windows.Forms.CheckBox();
            this.downsampleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroContextMenu1.SuspendLayout();
            this.metroMenuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(112, 76);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // metroContextMenu2
            // 
            this.metroContextMenu2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.metroContextMenu2.Name = "metroContextMenu2";
            this.metroContextMenu2.Size = new System.Drawing.Size(61, 4);
            // 
            // channelView
            // 
            this.channelView.Location = new System.Drawing.Point(20, 96);
            this.channelView.Name = "channelView";
            this.channelView.Size = new System.Drawing.Size(685, 390);
            this.channelView.TabIndex = 4;
            this.channelView.Visible = false;
            // 
            // baseView
            // 
            this.baseView.Location = new System.Drawing.Point(20, 115);
            this.baseView.Name = "baseView";
            this.baseView.Size = new System.Drawing.Size(636, 400);
            this.baseView.TabIndex = 3;
            // 
            // metroMenuStrip1
            // 
            this.metroMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.metroMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.metroMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.fIltersToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.metroMenuStrip1.Location = new System.Drawing.Point(20, 60);
            this.metroMenuStrip1.Name = "metroMenuStrip1";
            this.metroMenuStrip1.Size = new System.Drawing.Size(693, 33);
            this.metroMenuStrip1.TabIndex = 7;
            this.metroMenuStrip1.Text = "metroMenuStrip1";
            this.metroMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.metroMenuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem1,
            this.saveToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(53, 29);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(181, 30);
            this.loadToolStripMenuItem1.Text = "Load";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(181, 30);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.downsampleToolStripMenuItem});
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(56, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // fIltersToolStripMenuItem
            // 
            this.fIltersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.channelsToolStripMenuItem,
            this.colorToolStripMenuItem,
            this.invertToolStripMenuItem,
            this.edgeToolStripMenuItem,
            this.displacementFiltersToolStripMenuItem,
            this.histogramFiltersToolStripMenuItem});
            this.fIltersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.fIltersToolStripMenuItem.Name = "fIltersToolStripMenuItem";
            this.fIltersToolStripMenuItem.Size = new System.Drawing.Size(74, 29);
            this.fIltersToolStripMenuItem.Text = "FIlters";
            this.fIltersToolStripMenuItem.Click += new System.EventHandler(this.fIltersToolStripMenuItem_Click);
            // 
            // channelsToolStripMenuItem
            // 
            this.channelsToolStripMenuItem.Name = "channelsToolStripMenuItem";
            this.channelsToolStripMenuItem.Size = new System.Drawing.Size(263, 30);
            this.channelsToolStripMenuItem.Text = "Channels";
            this.channelsToolStripMenuItem.Click += new System.EventHandler(this.channelsToolStripMenuItem_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem1,
            this.invertToolStripMenuItem2});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(263, 30);
            this.colorToolStripMenuItem.Text = "Base FIlters";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // colorToolStripMenuItem1
            // 
            this.colorToolStripMenuItem1.Name = "colorToolStripMenuItem1";
            this.colorToolStripMenuItem1.Size = new System.Drawing.Size(138, 30);
            this.colorToolStripMenuItem1.Text = "Color";
            this.colorToolStripMenuItem1.Click += new System.EventHandler(this.colorToolStripMenuItem1_Click);
            // 
            // invertToolStripMenuItem2
            // 
            this.invertToolStripMenuItem2.Name = "invertToolStripMenuItem2";
            this.invertToolStripMenuItem2.Size = new System.Drawing.Size(138, 30);
            this.invertToolStripMenuItem2.Text = "Invert";
            this.invertToolStripMenuItem2.Click += new System.EventHandler(this.invertToolStripMenuItem2_Click);
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invertToolStripMenuItem1});
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(263, 30);
            this.invertToolStripMenuItem.Text = "Convolutional Filters";
            // 
            // invertToolStripMenuItem1
            // 
            this.invertToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x3ToolStripMenuItem,
            this.x5ToolStripMenuItem,
            this.x7ToolStripMenuItem,
            this.comparisonToolStripMenuItem});
            this.invertToolStripMenuItem1.Name = "invertToolStripMenuItem1";
            this.invertToolStripMenuItem1.Size = new System.Drawing.Size(215, 30);
            this.invertToolStripMenuItem1.Text = "Mean Removal";
            this.invertToolStripMenuItem1.Click += new System.EventHandler(this.invertToolStripMenuItem1_Click);
            // 
            // x3ToolStripMenuItem
            // 
            this.x3ToolStripMenuItem.Name = "x3ToolStripMenuItem";
            this.x3ToolStripMenuItem.Size = new System.Drawing.Size(192, 30);
            this.x3ToolStripMenuItem.Text = "3x3";
            this.x3ToolStripMenuItem.Click += new System.EventHandler(this.x3ToolStripMenuItem_Click);
            // 
            // x5ToolStripMenuItem
            // 
            this.x5ToolStripMenuItem.Name = "x5ToolStripMenuItem";
            this.x5ToolStripMenuItem.Size = new System.Drawing.Size(192, 30);
            this.x5ToolStripMenuItem.Text = "5x5";
            this.x5ToolStripMenuItem.Click += new System.EventHandler(this.x5ToolStripMenuItem_Click);
            // 
            // x7ToolStripMenuItem
            // 
            this.x7ToolStripMenuItem.Name = "x7ToolStripMenuItem";
            this.x7ToolStripMenuItem.Size = new System.Drawing.Size(192, 30);
            this.x7ToolStripMenuItem.Text = "7x7";
            this.x7ToolStripMenuItem.Click += new System.EventHandler(this.x7ToolStripMenuItem_Click);
            // 
            // comparisonToolStripMenuItem
            // 
            this.comparisonToolStripMenuItem.Name = "comparisonToolStripMenuItem";
            this.comparisonToolStripMenuItem.Size = new System.Drawing.Size(192, 30);
            this.comparisonToolStripMenuItem.Text = "Comparison";
            this.comparisonToolStripMenuItem.Click += new System.EventHandler(this.comparisonToolStripMenuItem_Click);
            // 
            // edgeToolStripMenuItem
            // 
            this.edgeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homogenityToolStripMenuItem});
            this.edgeToolStripMenuItem.Name = "edgeToolStripMenuItem";
            this.edgeToolStripMenuItem.Size = new System.Drawing.Size(263, 30);
            this.edgeToolStripMenuItem.Text = "Edge Detection";
            // 
            // homogenityToolStripMenuItem
            // 
            this.homogenityToolStripMenuItem.Name = "homogenityToolStripMenuItem";
            this.homogenityToolStripMenuItem.Size = new System.Drawing.Size(193, 30);
            this.homogenityToolStripMenuItem.Text = "Homogenity";
            this.homogenityToolStripMenuItem.Click += new System.EventHandler(this.homogenityToolStripMenuItem_Click);
            // 
            // displacementFiltersToolStripMenuItem
            // 
            this.displacementFiltersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeWarpToolStripMenuItem});
            this.displacementFiltersToolStripMenuItem.Name = "displacementFiltersToolStripMenuItem";
            this.displacementFiltersToolStripMenuItem.Size = new System.Drawing.Size(263, 30);
            this.displacementFiltersToolStripMenuItem.Text = "Displacement Filters";
            // 
            // timeWarpToolStripMenuItem
            // 
            this.timeWarpToolStripMenuItem.Name = "timeWarpToolStripMenuItem";
            this.timeWarpToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.timeWarpToolStripMenuItem.Text = "TimeWarp";
            this.timeWarpToolStripMenuItem.Click += new System.EventHandler(this.timeWarpToolStripMenuItem_Click);
            // 
            // histogramFiltersToolStripMenuItem
            // 
            this.histogramFiltersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoneFilterToolStripMenuItem});
            this.histogramFiltersToolStripMenuItem.Name = "histogramFiltersToolStripMenuItem";
            this.histogramFiltersToolStripMenuItem.Size = new System.Drawing.Size(263, 30);
            this.histogramFiltersToolStripMenuItem.Text = "Histogram Filters";
            // 
            // zoneFilterToolStripMenuItem
            // 
            this.zoneFilterToolStripMenuItem.Name = "zoneFilterToolStripMenuItem";
            this.zoneFilterToolStripMenuItem.Size = new System.Drawing.Size(180, 30);
            this.zoneFilterToolStripMenuItem.Text = "Zone Filter";
            this.zoneFilterToolStripMenuItem.Click += new System.EventHandler(this.zoneFilterToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unsafeToolStripMenuItem,
            this.undoRedoBufferToolStripMenuItem});
            this.optionsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(90, 29);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // unsafeToolStripMenuItem
            // 
            this.unsafeToolStripMenuItem.Name = "unsafeToolStripMenuItem";
            this.unsafeToolStripMenuItem.Size = new System.Drawing.Size(242, 30);
            this.unsafeToolStripMenuItem.Text = "Unsafe";
            // 
            // undoRedoBufferToolStripMenuItem
            // 
            this.undoRedoBufferToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeToolStripMenuItem});
            this.undoRedoBufferToolStripMenuItem.Name = "undoRedoBufferToolStripMenuItem";
            this.undoRedoBufferToolStripMenuItem.Size = new System.Drawing.Size(242, 30);
            this.undoRedoBufferToolStripMenuItem.Text = "Undo/Redo Buffer";
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(124, 30);
            this.sizeToolStripMenuItem.Text = "Size";
            this.sizeToolStripMenuItem.Click += new System.EventHandler(this.sizeToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(20, 493);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(693, 25);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(122, 20);
            this.toolStripStatusLabel1.Text = "Image Properties";
            // 
            // histogramView
            // 
            this.histogramView.Location = new System.Drawing.Point(20, 96);
            this.histogramView.Name = "histogramView";
            this.histogramView.Size = new System.Drawing.Size(685, 390);
            this.histogramView.TabIndex = 9;
            this.histogramView.Visible = false;
            // 
            // showHistogram
            // 
            this.showHistogram.AutoSize = true;
            this.showHistogram.Location = new System.Drawing.Point(574, 69);
            this.showHistogram.Name = "showHistogram";
            this.showHistogram.Size = new System.Drawing.Size(139, 21);
            this.showHistogram.TabIndex = 10;
            this.showHistogram.Text = "Show Histograms";
            this.showHistogram.UseVisualStyleBackColor = true;
            this.showHistogram.Visible = false;
            this.showHistogram.CheckedChanged += new System.EventHandler(this.showHistogram_CheckedChanged);
            // 
            // downsampleToolStripMenuItem
            // 
            this.downsampleToolStripMenuItem.Name = "downsampleToolStripMenuItem";
            this.downsampleToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.downsampleToolStripMenuItem.Text = "Downsample";
            this.downsampleToolStripMenuItem.Click += new System.EventHandler(this.downsampleToolStripMenuItem_Click);
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 538);
            this.Controls.Add(this.showHistogram);
            this.Controls.Add(this.histogramView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.metroMenuStrip1);
            this.Controls.Add(this.channelView);
            this.Controls.Add(this.baseView);
            this.MainMenuStrip = this.metroMenuStrip1;
            this.Name = "DisplayForm";
            this.Text = "Image Filter";
            this.metroContextMenu1.ResumeLayout(false);
            this.metroMenuStrip1.ResumeLayout(false);
            this.metroMenuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Views.BaseView baseView;
        private Views.ChannelView channelView;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu2;
        private ModernUISample.metro.MetroMenuStrip metroMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fIltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem2;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem unsafeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoRedoBufferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private Views.HistogramView histogramView;
        private System.Windows.Forms.CheckBox showHistogram;
        private System.Windows.Forms.ToolStripMenuItem edgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homogenityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displacementFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeWarpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comparisonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoneFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downsampleToolStripMenuItem;
    }
}

