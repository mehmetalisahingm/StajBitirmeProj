namespace HomeAssis
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            btn1 = new Button();
            btn2 = new Button();
            btn4 = new Button();
            btn3 = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.Menu;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(632, 328);
            dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 359);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1095, 328);
            dataGridView2.TabIndex = 1;
            // 
            // btn1
            // 
            btn1.BackgroundImage = (Image)resources.GetObject("btn1.BackgroundImage");
            btn1.Location = new Point(683, 26);
            btn1.Name = "btn1";
            btn1.Size = new Size(150, 33);
            btn1.TabIndex = 2;
            btn1.Text = "Sensor Ekle";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // btn2
            // 
            btn2.BackgroundImage = (Image)resources.GetObject("btn2.BackgroundImage");
            btn2.Location = new Point(683, 65);
            btn2.Name = "btn2";
            btn2.Size = new Size(150, 33);
            btn2.TabIndex = 3;
            btn2.Text = "Esik Deger Duzenle";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // btn4
            // 
            btn4.BackgroundImage = (Image)resources.GetObject("btn4.BackgroundImage");
            btn4.Location = new Point(683, 152);
            btn4.Name = "btn4";
            btn4.Size = new Size(150, 33);
            btn4.TabIndex = 4;
            btn4.Text = "Sensor Duzenle";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btn4_Click;
            // 
            // btn3
            // 
            btn3.BackgroundImage = (Image)resources.GetObject("btn3.BackgroundImage");
            btn3.Location = new Point(683, 113);
            btn3.Name = "btn3";
            btn3.Size = new Size(150, 33);
            btn3.TabIndex = 5;
            btn3.Text = "Sensor Sil";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btn3_Click;
            // 
            // btnClear
            // 
            btnClear.BackgroundImage = (Image)resources.GetObject("btnClear.BackgroundImage");
            btnClear.Location = new Point(683, 191);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 33);
            btnClear.TabIndex = 6;
            btnClear.Text = "tabloları temizle";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1130, 703);
            Controls.Add(btnClear);
            Controls.Add(btn3);
            Controls.Add(btn4);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button btn1;
        private Button btn2;
        private Button btn4;
        private Button btn3;
        private Button btnClear;
    }
}


//namespace HomeAssis
//{
//    partial class Form1
//    {
//        private System.ComponentModel.IContainer components = null;
//        private Guna.UI2.WinForms.Guna2DataGridView dataGridView1;
//        private Guna.UI2.WinForms.Guna2DataGridView dataGridView2;
//        private Guna.UI2.WinForms.Guna2Button btn1;
//        private Guna.UI2.WinForms.Guna2Button btn2;
//        private Guna.UI2.WinForms.Guna2Button btn3;
//        private Guna.UI2.WinForms.Guna2Button btn4;
//        private Guna.UI2.WinForms.Guna2Button btnClear;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
//            dataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
//            dataGridView2 = new Guna.UI2.WinForms.Guna2DataGridView();
//            btn1 = new Guna.UI2.WinForms.Guna2Button();
//            btn2 = new Guna.UI2.WinForms.Guna2Button();
//            btn3 = new Guna.UI2.WinForms.Guna2Button();
//            btn4 = new Guna.UI2.WinForms.Guna2Button();
//            btnClear = new Guna.UI2.WinForms.Guna2Button();
//            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
//            SuspendLayout();

//            // ------------------ DataGridView1 ------------------
//            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            dataGridView1.BackgroundColor = System.Drawing.Color.White;
//            dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
//            dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
//            dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
//            dataGridView1.EnableHeadersVisualStyles = false;
//            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
//            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
//            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
//            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
//            dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
//            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
//            dataGridView1.GridColor = System.Drawing.Color.LightGray;
//            dataGridView1.Location = new System.Drawing.Point(12, 12);
//            dataGridView1.Name = "dataGridView1";
//            dataGridView1.RowTemplate.Height = 28;
//            dataGridView1.Size = new System.Drawing.Size(632, 328);

//            // ------------------ DataGridView2 ------------------
//            dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            dataGridView2.BackgroundColor = System.Drawing.Color.White;
//            dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
//            dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
//            dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
//            dataGridView2.EnableHeadersVisualStyles = false;
//            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
//            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
//            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
//            dataGridView2.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
//            dataGridView2.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
//            dataGridView2.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
//            dataGridView2.GridColor = System.Drawing.Color.LightGray;
//            dataGridView2.Location = new System.Drawing.Point(12, 359);
//            dataGridView2.Name = "dataGridView2";
//            dataGridView2.RowTemplate.Height = 28;
//            dataGridView2.Size = new System.Drawing.Size(1130, 328);

//            // ------------------ Butonlar ------------------
//            Guna.UI2.WinForms.Guna2Button[] buttons = { btn1, btn2, btn3, btn4, btnClear };
//            string[] btnTexts = { "Sensor Ekle", "Esik Deger Duzenle", "Sensor Sil", "Sensor Duzenle", "Tabloları Temizle" };
//            int startY = 26;

//            for (int i = 0; i < buttons.Length; i++)
//            {
//                buttons[i].Text = btnTexts[i];
//                buttons[i].Location = new System.Drawing.Point(683, startY + (i * 39));
//                buttons[i].Size = new System.Drawing.Size(150, 35);
//                buttons[i].FillColor = System.Drawing.Color.FromArgb(0, 120, 215);
//                buttons[i].ForeColor = System.Drawing.Color.White;
//                buttons[i].Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
//                buttons[i].BorderRadius = 10;
//                buttons[i].HoverState.FillColor = System.Drawing.Color.FromArgb(0, 150, 245);
//            }

//            // ------------------ Form ------------------
//            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(1183, 712);
//            this.Controls.Add(btnClear);
//            this.Controls.Add(btn3);
//            this.Controls.Add(btn4);
//            this.Controls.Add(btn2);
//            this.Controls.Add(btn1);
//            this.Controls.Add(dataGridView2);
//            this.Controls.Add(dataGridView1);
//            this.Text = "HomeAssis Dashboard";
//            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

//            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
//            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
//            ResumeLayout(false);
//        }
//    }
//}

