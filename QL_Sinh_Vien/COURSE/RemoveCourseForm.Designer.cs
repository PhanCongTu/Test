namespace QL_Sinh_Vien.COURSE
{
    partial class RemoveCourseForm
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
            this.label_Enter_Course_ID = new System.Windows.Forms.Label();
            this.textBox_Course_ID = new System.Windows.Forms.TextBox();
            this.button_Remove = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Enter_Course_ID
            // 
            this.label_Enter_Course_ID.AutoSize = true;
            this.label_Enter_Course_ID.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Enter_Course_ID.ForeColor = System.Drawing.Color.White;
            this.label_Enter_Course_ID.Location = new System.Drawing.Point(32, 26);
            this.label_Enter_Course_ID.Name = "label_Enter_Course_ID";
            this.label_Enter_Course_ID.Size = new System.Drawing.Size(203, 23);
            this.label_Enter_Course_ID.TabIndex = 0;
            this.label_Enter_Course_ID.Text = "Enter The Course ID:";
            // 
            // textBox_Course_ID
            // 
            this.textBox_Course_ID.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Course_ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.textBox_Course_ID.Location = new System.Drawing.Point(278, 23);
            this.textBox_Course_ID.Name = "textBox_Course_ID";
            this.textBox_Course_ID.Size = new System.Drawing.Size(196, 32);
            this.textBox_Course_ID.TabIndex = 1;
            this.textBox_Course_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Course_ID_KeyPress);
            // 
            // button_Remove
            // 
            this.button_Remove.BackColor = System.Drawing.Color.White;
            this.button_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Remove.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Remove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.button_Remove.Location = new System.Drawing.Point(512, 19);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(134, 37);
            this.button_Remove.TabIndex = 2;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = false;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label9.Location = new System.Drawing.Point(423, 149);
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
            this.label11.Location = new System.Drawing.Point(437, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 21);
            this.label11.TabIndex = 30;
            this.label11.Text = "Develop by ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panel1.Controls.Add(this.button_Remove);
            this.panel1.Controls.Add(this.textBox_Course_ID);
            this.panel1.Controls.Add(this.label_Enter_Course_ID);
            this.panel1.Location = new System.Drawing.Point(1, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 70);
            this.panel1.TabIndex = 32;
            // 
            // RemoveCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 203);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Name = "RemoveCourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemoveCourseForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Enter_Course_ID;
        private System.Windows.Forms.TextBox textBox_Course_ID;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
    }
}