namespace Genetic_Algorhitm_lab4
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Run = new System.Windows.Forms.Button();
            this.maxChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lastValuesLabel = new System.Windows.Forms.Label();
            this.minChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LabelMinCalcs = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.maxChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minChart)).BeginInit();
            this.SuspendLayout();
            // 
            // Run
            // 
            this.Run.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Run.Location = new System.Drawing.Point(414, 428);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(207, 24);
            this.Run.TabIndex = 0;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // maxChart
            // 
            chartArea5.Name = "ChartArea1";
            this.maxChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.maxChart.Legends.Add(legend5);
            this.maxChart.Location = new System.Drawing.Point(12, 12);
            this.maxChart.Name = "maxChart";
            this.maxChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.IsVisibleInLegend = false;
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.maxChart.Series.Add(series5);
            this.maxChart.Size = new System.Drawing.Size(390, 217);
            this.maxChart.TabIndex = 1;
            this.maxChart.Text = "chart1";
            // 
            // lastValuesLabel
            // 
            this.lastValuesLabel.AutoSize = true;
            this.lastValuesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastValuesLabel.Location = new System.Drawing.Point(408, 9);
            this.lastValuesLabel.Name = "lastValuesLabel";
            this.lastValuesLabel.Size = new System.Drawing.Size(0, 17);
            this.lastValuesLabel.TabIndex = 2;
            // 
            // minChart
            // 
            chartArea6.Name = "ChartArea1";
            this.minChart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.minChart.Legends.Add(legend6);
            this.minChart.Location = new System.Drawing.Point(12, 235);
            this.minChart.Name = "minChart";
            this.minChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.IsVisibleInLegend = false;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.minChart.Series.Add(series6);
            this.minChart.Size = new System.Drawing.Size(390, 217);
            this.minChart.TabIndex = 3;
            this.minChart.Text = "chart1";
            // 
            // LabelMinCalcs
            // 
            this.LabelMinCalcs.AutoSize = true;
            this.LabelMinCalcs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelMinCalcs.Location = new System.Drawing.Point(411, 235);
            this.LabelMinCalcs.Name = "LabelMinCalcs";
            this.LabelMinCalcs.Size = new System.Drawing.Size(0, 17);
            this.LabelMinCalcs.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 461);
            this.Controls.Add(this.LabelMinCalcs);
            this.Controls.Add(this.minChart);
            this.Controls.Add(this.lastValuesLabel);
            this.Controls.Add(this.maxChart);
            this.Controls.Add(this.Run);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Genetic algorithm";
            ((System.ComponentModel.ISupportInitialize)(this.maxChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.DataVisualization.Charting.Chart maxChart;
        private System.Windows.Forms.Label lastValuesLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart minChart;
        private System.Windows.Forms.Label LabelMinCalcs;
    }
}

