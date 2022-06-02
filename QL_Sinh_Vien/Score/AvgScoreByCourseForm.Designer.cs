namespace QL_Sinh_Vien.Score
{
    partial class AvgScoreByCourseForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_Avg_Score_By_Course = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Avg_Score_By_Course)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Avg_Score_By_Course
            // 
            this.dataGridView_Avg_Score_By_Course.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dataGridView_Avg_Score_By_Course.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Avg_Score_By_Course.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Avg_Score_By_Course.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dataGridView_Avg_Score_By_Course.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Avg_Score_By_Course.Location = new System.Drawing.Point(8, 18);
            this.dataGridView_Avg_Score_By_Course.MultiSelect = false;
            this.dataGridView_Avg_Score_By_Course.Name = "dataGridView_Avg_Score_By_Course";
            this.dataGridView_Avg_Score_By_Course.ReadOnly = true;
            this.dataGridView_Avg_Score_By_Course.RowHeadersVisible = false;
            this.dataGridView_Avg_Score_By_Course.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_Avg_Score_By_Course.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Avg_Score_By_Course.RowTemplate.Height = 24;
            this.dataGridView_Avg_Score_By_Course.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Avg_Score_By_Course.Size = new System.Drawing.Size(583, 367);
            this.dataGridView_Avg_Score_By_Course.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label9.Location = new System.Drawing.Point(462, 415);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 21);
            this.label9.TabIndex = 31;
            this.label9.Text = "Phan Công Tú";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label11.Location = new System.Drawing.Point(476, 394);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 21);
            this.label11.TabIndex = 30;
            this.label11.Text = "Develop by ";
            // 
            // AvgScoreByCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 486);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGridView_Avg_Score_By_Course);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AvgScoreByCourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avgerage Score By CourseForm";
            this.Load += new System.EventHandler(this.AvgScoreByCourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Avg_Score_By_Course)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Avg_Score_By_Course;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
    }
}