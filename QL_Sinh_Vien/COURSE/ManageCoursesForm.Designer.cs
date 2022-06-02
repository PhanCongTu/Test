namespace QL_Sinh_Vien
{
    partial class ManageCoursesForm
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
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.textBox_Label = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_Hours_Number = new System.Windows.Forms.NumericUpDown();
            this.listBox_Courses = new System.Windows.Forms.ListBox();
            this.button_First = new System.Windows.Forms.Button();
            this.button_Previous = new System.Windows.Forms.Button();
            this.button_Next = new System.Windows.Forms.Button();
            this.button_Last = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.label_Total_Courses = new System.Windows.Forms.Label();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hours_Number)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_ID
            // 
            this.textBox_ID.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.textBox_ID.Location = new System.Drawing.Point(36, 47);
            this.textBox_ID.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(382, 32);
            this.textBox_ID.TabIndex = 0;
            this.textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // textBox_Description
            // 
            this.textBox_Description.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.textBox_Description.Location = new System.Drawing.Point(36, 236);
            this.textBox_Description.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Description.Multiline = true;
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.Size = new System.Drawing.Size(382, 161);
            this.textBox_Description.TabIndex = 1;
            // 
            // textBox_Label
            // 
            this.textBox_Label.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.textBox_Label.Location = new System.Drawing.Point(36, 110);
            this.textBox_Label.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Label.Name = "textBox_Label";
            this.textBox_Label.Size = new System.Drawing.Size(382, 32);
            this.textBox_Label.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label1.Location = new System.Drawing.Point(32, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label2.Location = new System.Drawing.Point(32, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Label";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label3.Location = new System.Drawing.Point(32, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hours Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label4.Location = new System.Drawing.Point(32, 209);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            // 
            // numericUpDown_Hours_Number
            // 
            this.numericUpDown_Hours_Number.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_Hours_Number.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.numericUpDown_Hours_Number.Location = new System.Drawing.Point(36, 173);
            this.numericUpDown_Hours_Number.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_Hours_Number.Name = "numericUpDown_Hours_Number";
            this.numericUpDown_Hours_Number.Size = new System.Drawing.Size(382, 32);
            this.numericUpDown_Hours_Number.TabIndex = 7;
            // 
            // listBox_Courses
            // 
            this.listBox_Courses.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Courses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.listBox_Courses.FormattingEnabled = true;
            this.listBox_Courses.ItemHeight = 23;
            this.listBox_Courses.Location = new System.Drawing.Point(465, 53);
            this.listBox_Courses.Margin = new System.Windows.Forms.Padding(4);
            this.listBox_Courses.Name = "listBox_Courses";
            this.listBox_Courses.Size = new System.Drawing.Size(568, 349);
            this.listBox_Courses.TabIndex = 8;
            this.listBox_Courses.Click += new System.EventHandler(this.listBox_Courses_Click);
            // 
            // button_First
            // 
            this.button_First.BackColor = System.Drawing.Color.White;
            this.button_First.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_First.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_First.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.button_First.Location = new System.Drawing.Point(154, 22);
            this.button_First.Margin = new System.Windows.Forms.Padding(4);
            this.button_First.Name = "button_First";
            this.button_First.Size = new System.Drawing.Size(188, 62);
            this.button_First.TabIndex = 9;
            this.button_First.Text = "First";
            this.button_First.UseVisualStyleBackColor = false;
            this.button_First.Click += new System.EventHandler(this.button_First_Click);
            // 
            // button_Previous
            // 
            this.button_Previous.BackColor = System.Drawing.Color.White;
            this.button_Previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Previous.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Previous.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.button_Previous.Location = new System.Drawing.Point(351, 22);
            this.button_Previous.Margin = new System.Windows.Forms.Padding(4);
            this.button_Previous.Name = "button_Previous";
            this.button_Previous.Size = new System.Drawing.Size(188, 62);
            this.button_Previous.TabIndex = 10;
            this.button_Previous.Text = "Previous";
            this.button_Previous.UseVisualStyleBackColor = false;
            this.button_Previous.Click += new System.EventHandler(this.button_Previous_Click);
            // 
            // button_Next
            // 
            this.button_Next.BackColor = System.Drawing.Color.White;
            this.button_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Next.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Next.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.button_Next.Location = new System.Drawing.Point(548, 22);
            this.button_Next.Margin = new System.Windows.Forms.Padding(4);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(188, 62);
            this.button_Next.TabIndex = 11;
            this.button_Next.Text = "Next";
            this.button_Next.UseVisualStyleBackColor = false;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // button_Last
            // 
            this.button_Last.BackColor = System.Drawing.Color.White;
            this.button_Last.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Last.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Last.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.button_Last.Location = new System.Drawing.Point(744, 22);
            this.button_Last.Margin = new System.Windows.Forms.Padding(4);
            this.button_Last.Name = "button_Last";
            this.button_Last.Size = new System.Drawing.Size(188, 62);
            this.button_Last.TabIndex = 12;
            this.button_Last.Text = "Last";
            this.button_Last.UseVisualStyleBackColor = false;
            this.button_Last.Click += new System.EventHandler(this.button_Last_Click);
            // 
            // button_Add
            // 
            this.button_Add.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Add.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Add.ForeColor = System.Drawing.SystemColors.Control;
            this.button_Add.Location = new System.Drawing.Point(186, 114);
            this.button_Add.Margin = new System.Windows.Forms.Padding(4);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(188, 62);
            this.button_Add.TabIndex = 13;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = false;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.BackColor = System.Drawing.Color.White;
            this.button_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Edit.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.button_Edit.Location = new System.Drawing.Point(382, 114);
            this.button_Edit.Margin = new System.Windows.Forms.Padding(4);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(188, 62);
            this.button_Edit.TabIndex = 14;
            this.button_Edit.Text = "Edit";
            this.button_Edit.UseVisualStyleBackColor = false;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.BackColor = System.Drawing.Color.Red;
            this.button_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Remove.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Remove.ForeColor = System.Drawing.SystemColors.Control;
            this.button_Remove.Location = new System.Drawing.Point(579, 114);
            this.button_Remove.Margin = new System.Windows.Forms.Padding(4);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(188, 62);
            this.button_Remove.TabIndex = 15;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = false;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // label_Total_Courses
            // 
            this.label_Total_Courses.AutoSize = true;
            this.label_Total_Courses.BackColor = System.Drawing.Color.White;
            this.label_Total_Courses.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_Total_Courses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label_Total_Courses.Location = new System.Drawing.Point(719, 418);
            this.label_Total_Courses.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Total_Courses.Name = "label_Total_Courses";
            this.label_Total_Courses.Size = new System.Drawing.Size(191, 29);
            this.label_Total_Courses.TabIndex = 16;
            this.label_Total_Courses.Text = "Total Courses: ";
            // 
            // button_Refresh
            // 
            this.button_Refresh.BackColor = System.Drawing.Color.White;
            this.button_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Refresh.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Refresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.button_Refresh.Location = new System.Drawing.Point(523, 410);
            this.button_Refresh.Margin = new System.Windows.Forms.Padding(4);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(188, 62);
            this.button_Refresh.TabIndex = 17;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = false;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.button_Remove);
            this.panel1.Controls.Add(this.button_Edit);
            this.panel1.Controls.Add(this.button_Add);
            this.panel1.Controls.Add(this.button_Last);
            this.panel1.Controls.Add(this.button_Next);
            this.panel1.Controls.Add(this.button_Previous);
            this.panel1.Controls.Add(this.button_First);
            this.panel1.Location = new System.Drawing.Point(5, 480);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 211);
            this.panel1.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(792, 155);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 21);
            this.label9.TabIndex = 29;
            this.label9.Text = "Phan Công Tú";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label11.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(813, 124);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 21);
            this.label11.TabIndex = 28;
            this.label11.Text = "Develop by ";
            // 
            // ManageCoursesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1060, 719);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.label_Total_Courses);
            this.Controls.Add(this.listBox_Courses);
            this.Controls.Add(this.numericUpDown_Hours_Number);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Label);
            this.Controls.Add(this.textBox_Description);
            this.Controls.Add(this.textBox_ID);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ManageCoursesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageCoursesForm";
            this.Load += new System.EventHandler(this.ManageCoursesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hours_Number)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.TextBox textBox_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hours_Number;
        private System.Windows.Forms.ListBox listBox_Courses;
        private System.Windows.Forms.Button button_First;
        private System.Windows.Forms.Button button_Previous;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.Button button_Last;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Label label_Total_Courses;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
    }
}