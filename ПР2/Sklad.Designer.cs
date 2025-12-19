namespace SkladApp
{
    partial class Sklad
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
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.txtSearchByName = new System.Windows.Forms.TextBox();
            this.txtStillage = new System.Windows.Forms.TextBox();
            this.txtCell = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearchByName = new System.Windows.Forms.Button();
            this.btnSearchByCoords = new System.Windows.Forms.Button();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(24, 255);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowHeadersWidth = 51;
            this.dataGridViewProducts.RowTemplate.Height = 24;
            this.dataGridViewProducts.Size = new System.Drawing.Size(753, 173);
            this.dataGridViewProducts.TabIndex = 0;
            // 
            // txtSearchByName
            // 
            this.txtSearchByName.Location = new System.Drawing.Point(265, 72);
            this.txtSearchByName.Name = "txtSearchByName";
            this.txtSearchByName.Size = new System.Drawing.Size(237, 22);
            this.txtSearchByName.TabIndex = 1;
            // 
            // txtStillage
            // 
            this.txtStillage.Location = new System.Drawing.Point(265, 125);
            this.txtStillage.Name = "txtStillage";
            this.txtStillage.Size = new System.Drawing.Size(237, 22);
            this.txtStillage.TabIndex = 2;
            // 
            // txtCell
            // 
            this.txtCell.Location = new System.Drawing.Point(265, 176);
            this.txtCell.Name = "txtCell";
            this.txtCell.Size = new System.Drawing.Size(237, 22);
            this.txtCell.TabIndex = 3;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 57);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(220, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 126);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(220, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSearchByName
            // 
            this.btnSearchByName.Location = new System.Drawing.Point(12, 195);
            this.btnSearchByName.Name = "btnSearchByName";
            this.btnSearchByName.Size = new System.Drawing.Size(220, 23);
            this.btnSearchByName.TabIndex = 6;
            this.btnSearchByName.Text = "Поиск по имени";
            this.btnSearchByName.UseVisualStyleBackColor = true;
            // 
            // btnSearchByCoords
            // 
            this.btnSearchByCoords.Location = new System.Drawing.Point(536, 57);
            this.btnSearchByCoords.Name = "btnSearchByCoords";
            this.btnSearchByCoords.Size = new System.Drawing.Size(241, 23);
            this.btnSearchByCoords.TabIndex = 7;
            this.btnSearchByCoords.Text = "Поиск по координатам";
            this.btnSearchByCoords.UseVisualStyleBackColor = true;
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(536, 126);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(241, 23);
            this.btnSaveToFile.TabIndex = 8;
            this.btnSaveToFile.Text = "Сохранить в файл";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(536, 195);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(241, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Обновить данные";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // Sklad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSaveToFile);
            this.Controls.Add(this.btnSearchByCoords);
            this.Controls.Add(this.btnSearchByName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtCell);
            this.Controls.Add(this.txtStillage);
            this.Controls.Add(this.txtSearchByName);
            this.Controls.Add(this.dataGridViewProducts);
            this.Name = "Sklad";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Sklad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.TextBox txtSearchByName;
        private System.Windows.Forms.TextBox txtStillage;
        private System.Windows.Forms.TextBox txtCell;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearchByName;
        private System.Windows.Forms.Button btnSearchByCoords;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Button btnRefresh;
    }
}

