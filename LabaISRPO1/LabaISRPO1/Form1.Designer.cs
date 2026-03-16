namespace BackpackApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listViewItems;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderWeight;
        private System.Windows.Forms.ColumnHeader columnHeaderCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMaxWeight;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnShowOriginal;

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
            this.listViewItems = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMaxWeight = new System.Windows.Forms.TextBox();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnShowOriginal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewItems
            // 
            this.listViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderWeight,
            this.columnHeaderCost});
            this.listViewItems.FullRowSelect = true;
            this.listViewItems.GridLines = true;
            this.listViewItems.HideSelection = false;
            this.listViewItems.Location = new System.Drawing.Point(12, 41);
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(560, 200);
            this.listViewItems.TabIndex = 0;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Название";
            this.columnHeaderName.Width = 150;
            // 
            // columnHeaderWeight
            // 
            this.columnHeaderWeight.Text = "Вес";
            this.columnHeaderWeight.Width = 80;
            // 
            // columnHeaderCost
            // 
            this.columnHeaderCost.Text = "Стоимость";
            this.columnHeaderCost.Width = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Максимальный вес:";
            // 
            // textBoxMaxWeight
            // 
            this.textBoxMaxWeight.Location = new System.Drawing.Point(156, 12);
            this.textBoxMaxWeight.Name = "textBoxMaxWeight";
            this.textBoxMaxWeight.Size = new System.Drawing.Size(100, 22);
            this.textBoxMaxWeight.TabIndex = 2;
            this.textBoxMaxWeight.Text = "8";
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(280, 10);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(100, 30);
            this.btnSolve.TabIndex = 3;
            this.btnSolve.Text = "Решить";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnShowOriginal
            // 
            this.btnShowOriginal.Location = new System.Drawing.Point(400, 10);
            this.btnShowOriginal.Name = "btnShowOriginal";
            this.btnShowOriginal.Size = new System.Drawing.Size(170, 30);
            this.btnShowOriginal.TabIndex = 4;
            this.btnShowOriginal.Text = "Показать исходные";
            this.btnShowOriginal.UseVisualStyleBackColor = true;
            this.btnShowOriginal.Click += new System.EventHandler(this.btnShowOriginal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.btnShowOriginal);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.textBoxMaxWeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewItems);
            this.Name = "Form1";
            this.Text = "Задача о рюкзаке";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}