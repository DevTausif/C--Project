
namespace FreshDairyFarm
{
    partial class ManagerProductsMilkForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.PRICE = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.LITRE = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.INSERT = new System.Windows.Forms.Button();
            this.UPDATE = new System.Windows.Forms.Button();
            this.DELETE = new System.Windows.Forms.Button();
            this.RESET = new System.Windows.Forms.Button();
            this.MILKDETAILS = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.PRICE);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.LITRE);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.ID);
            this.panel1.Location = new System.Drawing.Point(65, 57);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 252);
            this.panel1.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(52, 185);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(68, 26);
            this.textBox3.TabIndex = 6;
            // 
            // PRICE
            // 
            this.PRICE.AutoSize = true;
            this.PRICE.BackColor = System.Drawing.Color.White;
            this.PRICE.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRICE.Location = new System.Drawing.Point(65, 157);
            this.PRICE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PRICE.Name = "PRICE";
            this.PRICE.Size = new System.Drawing.Size(47, 19);
            this.PRICE.TabIndex = 5;
            this.PRICE.Text = "PRICE";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "COW",
            "GOAT"});
            this.comboBox1.Location = new System.Drawing.Point(125, 92);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(82, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "SELECT";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(52, 122);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(68, 26);
            this.textBox2.TabIndex = 3;
            // 
            // LITRE
            // 
            this.LITRE.AutoSize = true;
            this.LITRE.BackColor = System.Drawing.Color.White;
            this.LITRE.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LITRE.Location = new System.Drawing.Point(65, 92);
            this.LITRE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LITRE.Name = "LITRE";
            this.LITRE.Size = new System.Drawing.Size(45, 19);
            this.LITRE.TabIndex = 2;
            this.LITRE.Text = "LITRE";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(52, 60);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(68, 26);
            this.textBox1.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.BackColor = System.Drawing.Color.White;
            this.ID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.Location = new System.Drawing.Point(73, 33);
            this.ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(23, 19);
            this.ID.TabIndex = 0;
            this.ID.Text = "ID";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(327, 57);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(370, 252);
            this.dataGridView1.TabIndex = 11;
            // 
            // INSERT
            // 
            this.INSERT.BackColor = System.Drawing.Color.White;
            this.INSERT.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.INSERT.Location = new System.Drawing.Point(352, 318);
            this.INSERT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.INSERT.Name = "INSERT";
            this.INSERT.Size = new System.Drawing.Size(63, 34);
            this.INSERT.TabIndex = 18;
            this.INSERT.Text = "INSERT";
            this.INSERT.UseVisualStyleBackColor = false;
            // 
            // UPDATE
            // 
            this.UPDATE.BackColor = System.Drawing.Color.White;
            this.UPDATE.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UPDATE.Location = new System.Drawing.Point(441, 318);
            this.UPDATE.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UPDATE.Name = "UPDATE";
            this.UPDATE.Size = new System.Drawing.Size(63, 34);
            this.UPDATE.TabIndex = 19;
            this.UPDATE.Text = "UPDATE";
            this.UPDATE.UseVisualStyleBackColor = false;
            // 
            // DELETE
            // 
            this.DELETE.BackColor = System.Drawing.Color.White;
            this.DELETE.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DELETE.Location = new System.Drawing.Point(527, 318);
            this.DELETE.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DELETE.Name = "DELETE";
            this.DELETE.Size = new System.Drawing.Size(63, 34);
            this.DELETE.TabIndex = 20;
            this.DELETE.Text = "DELETE";
            this.DELETE.UseVisualStyleBackColor = false;
            // 
            // RESET
            // 
            this.RESET.BackColor = System.Drawing.Color.White;
            this.RESET.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RESET.Location = new System.Drawing.Point(611, 318);
            this.RESET.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RESET.Name = "RESET";
            this.RESET.Size = new System.Drawing.Size(63, 34);
            this.RESET.TabIndex = 21;
            this.RESET.Text = "RESET";
            this.RESET.UseVisualStyleBackColor = false;
            // 
            // MILKDETAILS
            // 
            this.MILKDETAILS.AutoSize = true;
            this.MILKDETAILS.BackColor = System.Drawing.Color.White;
            this.MILKDETAILS.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MILKDETAILS.Location = new System.Drawing.Point(230, 17);
            this.MILKDETAILS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MILKDETAILS.Name = "MILKDETAILS";
            this.MILKDETAILS.Size = new System.Drawing.Size(150, 23);
            this.MILKDETAILS.TabIndex = 22;
            this.MILKDETAILS.Text = "MILK DETAILS";
            // 
            // ManagerProductsMilkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(753, 373);
            this.Controls.Add(this.MILKDETAILS);
            this.Controls.Add(this.RESET);
            this.Controls.Add(this.DELETE);
            this.Controls.Add(this.UPDATE);
            this.Controls.Add(this.INSERT);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ManagerProductsMilkForm";
            this.Text = "ManagerProductsMilkForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label PRICE;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label LITRE;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button INSERT;
        private System.Windows.Forms.Button UPDATE;
        private System.Windows.Forms.Button DELETE;
        private System.Windows.Forms.Button RESET;
        private System.Windows.Forms.Label MILKDETAILS;
    }
}