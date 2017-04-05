namespace ImageFilter.Views
{
    partial class HistogramView
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.redChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.greenChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.blueChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.baseImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.redChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseImage)).BeginInit();
            this.SuspendLayout();
            // 
            // redChart
            // 
            chartArea1.Name = "ChartArea1";
            this.redChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.redChart.Legends.Add(legend1);
            this.redChart.Location = new System.Drawing.Point(333, 4);
            this.redChart.Name = "redChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Red";
            this.redChart.Series.Add(series1);
            this.redChart.Size = new System.Drawing.Size(349, 186);
            this.redChart.TabIndex = 1;
            this.redChart.Text = "Red Chart";
            // 
            // greenChart
            // 
            chartArea2.Name = "ChartArea1";
            this.greenChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.greenChart.Legends.Add(legend2);
            this.greenChart.Location = new System.Drawing.Point(4, 196);
            this.greenChart.Name = "greenChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series2.Color = System.Drawing.Color.ForestGreen;
            series2.Legend = "Legend1";
            series2.Name = "Green";
            this.greenChart.Series.Add(series2);
            this.greenChart.Size = new System.Drawing.Size(323, 191);
            this.greenChart.TabIndex = 2;
            this.greenChart.Text = "chart3";
            // 
            // blueChart
            // 
            chartArea3.Name = "ChartArea1";
            this.blueChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.blueChart.Legends.Add(legend3);
            this.blueChart.Location = new System.Drawing.Point(333, 196);
            this.blueChart.Name = "blueChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series3.Legend = "Legend1";
            series3.Name = "Blue";
            this.blueChart.Series.Add(series3);
            this.blueChart.Size = new System.Drawing.Size(349, 191);
            this.blueChart.TabIndex = 3;
            this.blueChart.Text = "Blue Tones";
            // 
            // baseImage
            // 
            this.baseImage.Location = new System.Drawing.Point(4, 4);
            this.baseImage.Name = "baseImage";
            this.baseImage.Size = new System.Drawing.Size(323, 186);
            this.baseImage.TabIndex = 4;
            this.baseImage.TabStop = false;
            // 
            // HistogramView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.baseImage);
            this.Controls.Add(this.blueChart);
            this.Controls.Add(this.greenChart);
            this.Controls.Add(this.redChart);
            this.Name = "HistogramView";
            this.Size = new System.Drawing.Size(685, 390);
            ((System.ComponentModel.ISupportInitialize)(this.redChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart redChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart greenChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart blueChart;
        private System.Windows.Forms.PictureBox baseImage;
    }
}
