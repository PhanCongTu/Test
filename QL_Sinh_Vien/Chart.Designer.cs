namespace QL_Sinh_Vien
{
    partial class Chart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartBDC = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBDT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartBDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBDT)).BeginInit();
            this.SuspendLayout();
            // 
            // chartBDC
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBDC.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBDC.Legends.Add(legend1);
            this.chartBDC.Location = new System.Drawing.Point(427, 12);
            this.chartBDC.Name = "chartBDC";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "chartBDC";
            this.chartBDC.Series.Add(series1);
            this.chartBDC.Size = new System.Drawing.Size(361, 435);
            this.chartBDC.TabIndex = 0;
            this.chartBDC.Text = "chart1";
            title1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Sex Ratio";
            title1.Text = "Sex Ratio";
            this.chartBDC.Titles.Add(title1);
            // 
            // chartBDT
            // 
            chartArea2.Name = "ChartArea1";
            this.chartBDT.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartBDT.Legends.Add(legend2);
            this.chartBDT.Location = new System.Drawing.Point(12, 12);
            this.chartBDT.Name = "chartBDT";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "chartBDT";
            this.chartBDT.Series.Add(series2);
            this.chartBDT.Size = new System.Drawing.Size(409, 435);
            this.chartBDT.TabIndex = 1;
            this.chartBDT.Text = "chart2";
            title2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Sex Ratio";
            this.chartBDT.Titles.Add(title2);
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartBDT);
            this.Controls.Add(this.chartBDC);
            this.Name = "Chart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chart";
            this.Load += new System.EventHandler(this.Chart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartBDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBDT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartBDC;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBDT;
    }
}