namespace GUI_QLBanHang
{
    partial class ThongKecs
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgvThongKeSP = new System.Windows.Forms.DataGridView();
            this.dtgvThongKeTonKho = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKeSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKeTonKho)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgvThongKeSP);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(-2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1188, 336);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê tồn kho";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgvThongKeTonKho);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(-2, 343);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1197, 359);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thống kê san phẩm";
            // 
            // dtgvThongKeSP
            // 
            this.dtgvThongKeSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvThongKeSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThongKeSP.Location = new System.Drawing.Point(7, 28);
            this.dtgvThongKeSP.Name = "dtgvThongKeSP";
            this.dtgvThongKeSP.RowHeadersWidth = 51;
            this.dtgvThongKeSP.RowTemplate.Height = 24;
            this.dtgvThongKeSP.Size = new System.Drawing.Size(1181, 308);
            this.dtgvThongKeSP.TabIndex = 0;
            // 
            // dtgvThongKeTonKho
            // 
            this.dtgvThongKeTonKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvThongKeTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThongKeTonKho.Location = new System.Drawing.Point(7, 28);
            this.dtgvThongKeTonKho.Name = "dtgvThongKeTonKho";
            this.dtgvThongKeTonKho.RowHeadersWidth = 51;
            this.dtgvThongKeTonKho.RowTemplate.Height = 24;
            this.dtgvThongKeTonKho.Size = new System.Drawing.Size(1184, 331);
            this.dtgvThongKeTonKho.TabIndex = 0;
            // 
            // ThongKecs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 714);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ThongKecs";
            this.Text = "ThongKecs";
            this.Load += new System.EventHandler(this.ThongKecs_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKeSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKeTonKho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgvThongKeSP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgvThongKeTonKho;
    }
}