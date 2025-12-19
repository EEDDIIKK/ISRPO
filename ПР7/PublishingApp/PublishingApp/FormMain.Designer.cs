namespace PublishingApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnOpenOrderForm = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOpenOrderForm
            // 
            this.btnOpenOrderForm.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOpenOrderForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenOrderForm.ForeColor = System.Drawing.Color.White;
            this.btnOpenOrderForm.Location = new System.Drawing.Point(50, 100);
            this.btnOpenOrderForm.Name = "btnOpenOrderForm";
            this.btnOpenOrderForm.Size = new System.Drawing.Size(300, 60);
            this.btnOpenOrderForm.TabIndex = 0;
            this.btnOpenOrderForm.Text = "Оформить предзаказ книги";
            this.btnOpenOrderForm.UseVisualStyleBackColor = false;
            this.btnOpenOrderForm.Click += new System.EventHandler(this.btnOpenOrderForm_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(50, 180);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(300, 30);
            this.btnTestConnection.TabIndex = 1;
            this.btnTestConnection.Text = "Проверить подключение к БД";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(45, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Издательство \"Книжный мир\"";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.btnOpenOrderForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная форма - Издательство";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnOpenOrderForm;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label label1;
    }
}