namespace QL_Sinh_Vien.Score
{
    partial class ManageScoreForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Student_ID = new System.Windows.Forms.TextBox();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.textBox_Score = new System.Windows.Forms.TextBox();
            this.comboBox_Select_Course = new System.Windows.Forms.ComboBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_Avg_Score_By_Course = new System.Windows.Forms.Button();
            this.button_Show_Student = new System.Windows.Forms.Button();
            this.button_Show_Score = new System.Windows.Forms.Button();
            this.dataGridView_Student_Score = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Student_Score)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(50, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Course:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(95, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Score:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(44, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description:";
            // 
            // textBox_Student_ID
            // 
            this.textBox_Student_ID.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Student_ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.textBox_Student_ID.Location = new System.Drawing.Point(172, 13);
            this.textBox_Student_ID.Name = "textBox_Student_ID";
            this.textBox_Student_ID.Size = new System.Drawing.Size(244, 32);
            this.textBox_Student_ID.TabIndex = 4;
            this.textBox_Student_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Student_ID_KeyPress);
            // 
            // textBox_Description
            // 
            this.textBox_Description.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.textBox_Description.Location = new System.Drawing.Point(172, 198);
            this.textBox_Description.Multiline = true;
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.Size = new System.Drawing.Size(244, 163);
            this.textBox_Description.TabIndex = 5;
            // 
            // textBox_Score
            // 
            this.textBox_Score.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Score.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.textBox_Score.Location = new System.Drawing.Point(172, 137);
            this.textBox_Score.Name = "textBox_Score";
            this.textBox_Score.Size = new System.Drawing.Size(244, 32);
            this.textBox_Score.TabIndex = 6;
            this.textBox_Score.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Score_KeyPress);
            // 
            // comboBox_Select_Course
            // 
            this.comboBox_Select_Course.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Select_Course.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.comboBox_Select_Course.FormattingEnabled = true;
            this.comboBox_Select_Course.Location = new System.Drawing.Point(172, 72);
            this.comboBox_Select_Course.Name = "comboBox_Select_Course";
            this.comboBox_Select_Course.Size = new System.Drawing.Size(244, 31);
            this.comboBox_Select_Course.TabIndex = 7;
            // 
            // button_Add
            // 
            this.button_Add.BackColor = System.Drawing.Color.White;
            this.button_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Add.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.button_Add.Location = new System.Drawing.Point(54, 392);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(171, 52);
            this.button_Add.TabIndex = 8;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = false;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.BackColor = System.Drawing.Color.Red;
            this.button_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Remove.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Remove.ForeColor = System.Drawing.Color.White;
            this.button_Remove.Location = new System.Drawing.Point(245, 392);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(171, 52);
            this.button_Remove.TabIndex = 9;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = false;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // button_Avg_Score_By_Course
            // 
            this.button_Avg_Score_By_Course.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.button_Avg_Score_By_Course.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Avg_Score_By_Course.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Avg_Score_By_Course.ForeColor = System.Drawing.SystemColors.Control;
            this.button_Avg_Score_By_Course.Location = new System.Drawing.Point(54, 463);
            this.button_Avg_Score_By_Course.Name = "button_Avg_Score_By_Course";
            this.button_Avg_Score_By_Course.Size = new System.Drawing.Size(362, 48);
            this.button_Avg_Score_By_Course.TabIndex = 10;
            this.button_Avg_Score_By_Course.Text = "Average Score By Course";
            this.button_Avg_Score_By_Course.UseVisualStyleBackColor = false;
            this.button_Avg_Score_By_Course.Click += new System.EventHandler(this.button_Avg_Score_By_Course_Click);
            // 
            // button_Show_Student
            // 
            this.button_Show_Student.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.button_Show_Student.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Show_Student.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Show_Student.ForeColor = System.Drawing.Color.White;
            this.button_Show_Student.Location = new System.Drawing.Point(486, 38);
            this.button_Show_Student.Name = "button_Show_Student";
            this.button_Show_Student.Size = new System.Drawing.Size(246, 35);
            this.button_Show_Student.TabIndex = 11;
            this.button_Show_Student.Text = "Show Student";
            this.button_Show_Student.UseVisualStyleBackColor = false;
            this.button_Show_Student.Click += new System.EventHandler(this.button_Show_Student_Click);
            // 
            // button_Show_Score
            // 
            this.button_Show_Score.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.button_Show_Score.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Show_Score.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Show_Score.ForeColor = System.Drawing.Color.White;
            this.button_Show_Score.Location = new System.Drawing.Point(785, 38);
            this.button_Show_Score.Name = "button_Show_Score";
            this.button_Show_Score.Size = new System.Drawing.Size(271, 35);
            this.button_Show_Score.TabIndex = 12;
            this.button_Show_Score.Text = "Show Score";
            this.button_Show_Score.UseVisualStyleBackColor = false;
            this.button_Show_Score.Click += new System.EventHandler(this.button_Show_Score_Click);
            // 
            // dataGridView_Student_Score
            // 
            this.dataGridView_Student_Score.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dataGridView_Student_Score.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Student_Score.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Student_Score.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_Student_Score.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Student_Score.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Student_Score.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Student_Score.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Student_Score.Location = new System.Drawing.Point(460, 94);
            this.dataGridView_Student_Score.MultiSelect = false;
            this.dataGridView_Student_Score.Name = "dataGridView_Student_Score";
            this.dataGridView_Student_Score.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Student_Score.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_Student_Score.RowHeadersVisible = false;
            this.dataGridView_Student_Score.RowHeadersWidth = 51;
            this.dataGridView_Student_Score.RowTemplate.Height = 24;
            this.dataGridView_Student_Score.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Student_Score.Size = new System.Drawing.Size(1040, 480);
            this.dataGridView_Student_Score.TabIndex = 13;
            this.dataGridView_Student_Score.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Student_Score_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panel1.Controls.Add(this.button_Avg_Score_By_Course);
            this.panel1.Controls.Add(this.button_Remove);
            this.panel1.Controls.Add(this.button_Add);
            this.panel1.Controls.Add(this.comboBox_Select_Course);
            this.panel1.Controls.Add(this.textBox_Score);
            this.panel1.Controls.Add(this.textBox_Description);
            this.panel1.Controls.Add(this.textBox_Student_ID);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(9, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 552);
            this.panel1.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label9.Location = new System.Drawing.Point(1194, 43);
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
            this.label11.Location = new System.Drawing.Point(1208, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 21);
            this.label11.TabIndex = 30;
            this.label11.Text = "Develop by ";
            // 
            // ManageScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1522, 614);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView_Student_Score);
            this.Controls.Add(this.button_Show_Score);
            this.Controls.Add(this.button_Show_Student);
            this.Name = "ManageScoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageScoreForm";
            this.Load += new System.EventHandler(this.ManageScoreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Student_Score)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Student_ID;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.TextBox textBox_Score;
        private System.Windows.Forms.ComboBox comboBox_Select_Course;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_Avg_Score_By_Course;
        private System.Windows.Forms.Button button_Show_Student;
        private System.Windows.Forms.Button button_Show_Score;
        private System.Windows.Forms.DataGridView dataGridView_Student_Score;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
    }
}