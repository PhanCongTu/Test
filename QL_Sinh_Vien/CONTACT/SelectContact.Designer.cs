namespace QL_Sinh_Vien.CONTACT
{
    partial class SelectContact
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
            this.dataGridView_Select_Contact = new System.Windows.Forms.DataGridView();
            this.button_OK = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Select_Contact)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Select_Contact
            // 
            this.dataGridView_Select_Contact.AllowUserToResizeRows = false;
            this.dataGridView_Select_Contact.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Select_Contact.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dataGridView_Select_Contact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Select_Contact.Location = new System.Drawing.Point(3, 7);
            this.dataGridView_Select_Contact.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_Select_Contact.Name = "dataGridView_Select_Contact";
            this.dataGridView_Select_Contact.ReadOnly = true;
            this.dataGridView_Select_Contact.RowHeadersVisible = false;
            this.dataGridView_Select_Contact.RowHeadersWidth = 51;
            this.dataGridView_Select_Contact.RowTemplate.Height = 24;
            this.dataGridView_Select_Contact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Select_Contact.Size = new System.Drawing.Size(966, 492);
            this.dataGridView_Select_Contact.TabIndex = 0;
            this.dataGridView_Select_Contact.Click += new System.EventHandler(this.dataGridView_Select_Contact_Click);
            // 
            // button_OK
            // 
            this.button_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_OK.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.Location = new System.Drawing.Point(365, 522);
            this.button_OK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(226, 61);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label10.Location = new System.Drawing.Point(629, 562);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 21);
            this.label10.TabIndex = 13;
            this.label10.Text = "Phan Công Tú";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label12.Location = new System.Drawing.Point(651, 534);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 21);
            this.label12.TabIndex = 12;
            this.label12.Text = "Develop by ";
            // 
            // SelectContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 634);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.dataGridView_Select_Contact);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SelectContact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectContact";
            this.Load += new System.EventHandler(this.SelectContact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Select_Contact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Select_Contact;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
    }
}