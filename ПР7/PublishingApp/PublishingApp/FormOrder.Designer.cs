namespace PublishingApp
{
    partial class FormOrder
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBooks = new System.Windows.Forms.ComboBox();
            this.groupBoxBookInfo = new System.Windows.Forms.GroupBox();
            this.lblCirculation = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPages = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxCustomer = new System.Windows.Forms.GroupBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBoxOffice = new System.Windows.Forms.GroupBox();
            this.comboBoxOffice = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxBookInfo.SuspendLayout();
            this.groupBoxCustomer.SuspendLayout();
            this.groupBoxOffice.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите книгу:";
            // 
            // comboBoxBooks
            // 
            this.comboBoxBooks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBooks.FormattingEnabled = true;
            this.comboBoxBooks.Location = new System.Drawing.Point(213, 23);
            this.comboBoxBooks.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxBooks.Name = "comboBoxBooks";
            this.comboBoxBooks.Size = new System.Drawing.Size(399, 24);
            this.comboBoxBooks.TabIndex = 1;
            this.comboBoxBooks.SelectedIndexChanged += new System.EventHandler(this.comboBoxBooks_SelectedIndexChanged);
            // 
            // groupBoxBookInfo
            // 
            this.groupBoxBookInfo.Controls.Add(this.lblCirculation);
            this.groupBoxBookInfo.Controls.Add(this.label8);
            this.groupBoxBookInfo.Controls.Add(this.lblPages);
            this.groupBoxBookInfo.Controls.Add(this.label6);
            this.groupBoxBookInfo.Controls.Add(this.lblYear);
            this.groupBoxBookInfo.Controls.Add(this.label5);
            this.groupBoxBookInfo.Controls.Add(this.lblAuthor);
            this.groupBoxBookInfo.Controls.Add(this.label4);
            this.groupBoxBookInfo.Controls.Add(this.lblBookTitle);
            this.groupBoxBookInfo.Controls.Add(this.label3);
            this.groupBoxBookInfo.Controls.Add(this.lblPrice);
            this.groupBoxBookInfo.Controls.Add(this.label2);
            this.groupBoxBookInfo.Location = new System.Drawing.Point(27, 74);
            this.groupBoxBookInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxBookInfo.Name = "groupBoxBookInfo";
            this.groupBoxBookInfo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxBookInfo.Size = new System.Drawing.Size(587, 222);
            this.groupBoxBookInfo.TabIndex = 2;
            this.groupBoxBookInfo.TabStop = false;
            this.groupBoxBookInfo.Text = "Информация о книге";
            // 
            // lblCirculation
            // 
            this.lblCirculation.AutoSize = true;
            this.lblCirculation.Location = new System.Drawing.Point(160, 185);
            this.lblCirculation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCirculation.Name = "lblCirculation";
            this.lblCirculation.Size = new System.Drawing.Size(14, 16);
            this.lblCirculation.TabIndex = 11;
            this.lblCirculation.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 185);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Тираж (экз.):";
            // 
            // lblPages
            // 
            this.lblPages.AutoSize = true;
            this.lblPages.Location = new System.Drawing.Point(160, 148);
            this.lblPages.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPages.Name = "lblPages";
            this.lblPages.Size = new System.Drawing.Size(14, 16);
            this.lblPages.TabIndex = 9;
            this.lblPages.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 148);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Количество стр.:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(160, 111);
            this.lblYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(14, 16);
            this.lblYear.TabIndex = 7;
            this.lblYear.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 111);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Год издания:";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(160, 74);
            this.lblAuthor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(75, 16);
            this.lblAuthor.TabIndex = 5;
            this.lblAuthor.Text = "Не указан";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Автор:";
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblBookTitle.Location = new System.Drawing.Point(160, 37);
            this.lblBookTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(101, 18);
            this.lblBookTitle.TabIndex = 3;
            this.lblBookTitle.Text = "Не выбрана";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Название:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.Green;
            this.lblPrice.Location = new System.Drawing.Point(427, 172);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(64, 25);
            this.lblPrice.TabIndex = 1;
            this.lblPrice.Text = "0 руб";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(427, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Цена:";
            // 
            // groupBoxCustomer
            // 
            this.groupBoxCustomer.Controls.Add(this.txtPhone);
            this.groupBoxCustomer.Controls.Add(this.label7);
            this.groupBoxCustomer.Controls.Add(this.txtAddress);
            this.groupBoxCustomer.Controls.Add(this.label9);
            this.groupBoxCustomer.Controls.Add(this.txtCustomerName);
            this.groupBoxCustomer.Controls.Add(this.label10);
            this.groupBoxCustomer.Location = new System.Drawing.Point(27, 308);
            this.groupBoxCustomer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxCustomer.Name = "groupBoxCustomer";
            this.groupBoxCustomer.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxCustomer.Size = new System.Drawing.Size(587, 160);
            this.groupBoxCustomer.TabIndex = 3;
            this.groupBoxCustomer.TabStop = false;
            this.groupBoxCustomer.Text = "Данные клиента";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(160, 111);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(399, 22);
            this.txtPhone.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 114);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Телефон:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(160, 74);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(399, 22);
            this.txtAddress.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 78);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Адрес:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(160, 37);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(399, 22);
            this.txtCustomerName.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 41);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "ФИО:";
            // 
            // groupBoxOffice
            // 
            this.groupBoxOffice.Controls.Add(this.comboBoxOffice);
            this.groupBoxOffice.Controls.Add(this.label11);
            this.groupBoxOffice.Location = new System.Drawing.Point(27, 480);
            this.groupBoxOffice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxOffice.Name = "groupBoxOffice";
            this.groupBoxOffice.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxOffice.Size = new System.Drawing.Size(587, 74);
            this.groupBoxOffice.TabIndex = 4;
            this.groupBoxOffice.TabStop = false;
            this.groupBoxOffice.Text = "Офис получения";
            // 
            // comboBoxOffice
            // 
            this.comboBoxOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOffice.FormattingEnabled = true;
            this.comboBoxOffice.Location = new System.Drawing.Point(160, 31);
            this.comboBoxOffice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxOffice.Name = "comboBoxOffice";
            this.comboBoxOffice.Size = new System.Drawing.Size(399, 24);
            this.comboBoxOffice.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 34);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Офис:";
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCreateOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreateOrder.ForeColor = System.Drawing.Color.White;
            this.btnCreateOrder.Location = new System.Drawing.Point(347, 578);
            this.btnCreateOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(267, 49);
            this.btnCreateOrder.TabIndex = 5;
            this.btnCreateOrder.Text = "Оформить предзаказ";
            this.btnCreateOrder.UseVisualStyleBackColor = false;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(27, 578);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 49);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 654);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.groupBoxOffice);
            this.Controls.Add(this.groupBoxCustomer);
            this.Controls.Add(this.groupBoxBookInfo);
            this.Controls.Add(this.comboBoxBooks);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оформление предзаказа книги";
            this.Load += new System.EventHandler(this.FormOrder_Load);
            this.groupBoxBookInfo.ResumeLayout(false);
            this.groupBoxBookInfo.PerformLayout();
            this.groupBoxCustomer.ResumeLayout(false);
            this.groupBoxCustomer.PerformLayout();
            this.groupBoxOffice.ResumeLayout(false);
            this.groupBoxOffice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBooks;
        private System.Windows.Forms.GroupBox groupBoxBookInfo;
        private System.Windows.Forms.Label lblCirculation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPages;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxCustomer;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBoxOffice;
        private System.Windows.Forms.ComboBox comboBoxOffice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnCancel;
    }
}