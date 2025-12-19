namespace ISRPO4._5._6._7
{
    partial class PR4
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnShifr = new System.Windows.Forms.Button();
            this.nudSdwig = new System.Windows.Forms.NumericUpDown();
            this.lblShift = new System.Windows.Forms.Label();
            this.cbxLeng = new System.Windows.Forms.ComboBox();
            this.lblLengua = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.btnDeShifr = new System.Windows.Forms.Button();
            this.Dell = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSdwig)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShifr
            // 
            this.btnShifr.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShifr.Location = new System.Drawing.Point(72, 449);
            this.btnShifr.Margin = new System.Windows.Forms.Padding(4);
            this.btnShifr.Name = "btnShifr";
            this.btnShifr.Size = new System.Drawing.Size(180, 53);
            this.btnShifr.TabIndex = 17;
            this.btnShifr.Text = "Зашифровать";
            this.btnShifr.UseVisualStyleBackColor = true;
            this.btnShifr.Click += new System.EventHandler(this.btnShifr_Click);
            // 
            // nudSdwig
            // 
            this.nudSdwig.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nudSdwig.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudSdwig.Location = new System.Drawing.Point(638, 377);
            this.nudSdwig.Margin = new System.Windows.Forms.Padding(4);
            this.nudSdwig.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSdwig.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSdwig.Name = "nudSdwig";
            this.nudSdwig.ReadOnly = true;
            this.nudSdwig.Size = new System.Drawing.Size(195, 35);
            this.nudSdwig.TabIndex = 16;
            this.nudSdwig.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSdwig.ValueChanged += new System.EventHandler(this.nudSdwig_ValueChanged);
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblShift.Location = new System.Drawing.Point(550, 379);
            this.lblShift.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(80, 27);
            this.lblShift.TabIndex = 15;
            this.lblShift.Text = "Сдвиг:";
            // 
            // cbxLeng
            // 
            this.cbxLeng.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbxLeng.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLeng.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxLeng.FormattingEnabled = true;
            this.cbxLeng.Items.AddRange(new object[] {
            "русский",
            "английский"});
            this.cbxLeng.Location = new System.Drawing.Point(181, 382);
            this.cbxLeng.Margin = new System.Windows.Forms.Padding(4);
            this.cbxLeng.Name = "cbxLeng";
            this.cbxLeng.Size = new System.Drawing.Size(195, 35);
            this.cbxLeng.TabIndex = 14;
            this.cbxLeng.SelectedIndexChanged += new System.EventHandler(this.cbxLeng_SelectedIndexChanged);
            // 
            // lblLengua
            // 
            this.lblLengua.AutoSize = true;
            this.lblLengua.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLengua.Location = new System.Drawing.Point(88, 385);
            this.lblLengua.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLengua.Name = "lblLengua";
            this.lblLengua.Size = new System.Drawing.Size(71, 27);
            this.lblLengua.TabIndex = 13;
            this.lblLengua.Text = "Язык:";
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtOutput.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtOutput.Location = new System.Drawing.Point(59, 251);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(800, 106);
            this.txtOutput.TabIndex = 12;
            this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResult.Location = new System.Drawing.Point(405, 192);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(79, 27);
            this.lblResult.TabIndex = 11;
            this.lblResult.Text = "Стало:";
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtInput.Location = new System.Drawing.Point(59, 67);
            this.txtInput.Margin = new System.Windows.Forms.Padding(4);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(800, 100);
            this.txtInput.TabIndex = 10;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblText.Location = new System.Drawing.Point(405, 22);
            this.lblText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(78, 27);
            this.lblText.TabIndex = 9;
            this.lblText.Text = "Было :";
            // 
            // btnDeShifr
            // 
            this.btnDeShifr.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeShifr.Location = new System.Drawing.Point(369, 449);
            this.btnDeShifr.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeShifr.Name = "btnDeShifr";
            this.btnDeShifr.Size = new System.Drawing.Size(180, 53);
            this.btnDeShifr.TabIndex = 18;
            this.btnDeShifr.Text = "Дешифровать";
            this.btnDeShifr.UseVisualStyleBackColor = true;
            this.btnDeShifr.Click += new System.EventHandler(this.btnDeShifr_Click);
            // 
            // Dell
            // 
            this.Dell.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dell.Location = new System.Drawing.Point(666, 449);
            this.Dell.Margin = new System.Windows.Forms.Padding(4);
            this.Dell.Name = "Dell";
            this.Dell.Size = new System.Drawing.Size(180, 53);
            this.Dell.TabIndex = 19;
            this.Dell.Text = "Очистить";
            this.Dell.UseVisualStyleBackColor = true;
            this.Dell.Click += new System.EventHandler(this.Dell_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 515);
            this.Controls.Add(this.Dell);
            this.Controls.Add(this.btnDeShifr);
            this.Controls.Add(this.btnShifr);
            this.Controls.Add(this.nudSdwig);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.cbxLeng);
            this.Controls.Add(this.lblLengua);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSdwig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShifr;
        private System.Windows.Forms.NumericUpDown nudSdwig;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.ComboBox cbxLeng;
        private System.Windows.Forms.Label lblLengua;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Button btnDeShifr;
        private System.Windows.Forms.Button Dell;
    }
}

