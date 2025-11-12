namespace TicketApp
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numbers = new System.Windows.Forms.Label();
            this.lukyBilet = new System.Windows.Forms.Label();
            this.unlukyBilet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Генератор тралл билетов";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(260, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сгенерировать счастливый билет";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numbers
            // 
            this.numbers.AutoSize = true;
            this.numbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numbers.Location = new System.Drawing.Point(312, 152);
            this.numbers.Name = "numbers";
            this.numbers.Size = new System.Drawing.Size(22, 32);
            this.numbers.TabIndex = 2;
            this.numbers.Text = ".";
            this.numbers.Click += new System.EventHandler(this.numbers_Click);
            // 
            // lukyBilet
            // 
            this.lukyBilet.AutoSize = true;
            this.lukyBilet.Location = new System.Drawing.Point(321, 244);
            this.lukyBilet.Name = "lukyBilet";
            this.lukyBilet.Size = new System.Drawing.Size(10, 16);
            this.lukyBilet.TabIndex = 3;
            this.lukyBilet.Text = ".";
            this.lukyBilet.Click += new System.EventHandler(this.lukyBilet_Click);
            // 
            // unlukyBilet
            // 
            this.unlukyBilet.AutoSize = true;
            this.unlukyBilet.Location = new System.Drawing.Point(321, 287);
            this.unlukyBilet.Name = "unlukyBilet";
            this.unlukyBilet.Size = new System.Drawing.Size(10, 16);
            this.unlukyBilet.TabIndex = 4;
            this.unlukyBilet.Text = ".";
            this.unlukyBilet.Click += new System.EventHandler(this.unlukyBilet_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.unlukyBilet);
            this.Controls.Add(this.lukyBilet);
            this.Controls.Add(this.numbers);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label numbers;
        private System.Windows.Forms.Label lukyBilet;
        private System.Windows.Forms.Label unlukyBilet;
    }
}

