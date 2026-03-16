namespace FilesApp
{
    partial class SimbolsCount
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnCountUp;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.TextBox txtPath;

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
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnCountUp = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 30);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCountUp
            // 
            this.btnCountUp.Location = new System.Drawing.Point(130, 12);
            this.btnCountUp.Name = "btnCountUp";
            this.btnCountUp.Size = new System.Drawing.Size(100, 30);
            this.btnCountUp.TabIndex = 1;
            this.btnCountUp.Text = "Подсчитать";
            this.btnCountUp.UseVisualStyleBackColor = true;
            this.btnCountUp.Click += new System.EventHandler(this.btnCountUp_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(248, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(366, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(484, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 30);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblInfo1
            // 
            this.lblInfo1.AutoSize = true;
            this.lblInfo1.Location = new System.Drawing.Point(12, 55);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(231, 17);
            this.lblInfo1.TabIndex = 5;
            this.lblInfo1.Text = "Введите текст или выберите файл";
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.Location = new System.Drawing.Point(12, 225);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(209, 17);
            this.lblInfo2.TabIndex = 6;
            this.lblInfo2.Text = "Количество символов в тексте:";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(12, 75);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtText.Size = new System.Drawing.Size(572, 130);
            this.txtText.TabIndex = 7;
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(12, 245);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(100, 22);
            this.txtCount.TabIndex = 8;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 280);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(572, 22);
            this.txtPath.TabIndex = 9;
            // 
            // SimbolsCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 321);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.lblInfo2);
            this.Controls.Add(this.lblInfo1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCountUp);
            this.Controls.Add(this.btnOpen);
            this.Name = "SimbolsCount";
            this.Text = "Подсчёт символов в тексте";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimbolsCount_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}