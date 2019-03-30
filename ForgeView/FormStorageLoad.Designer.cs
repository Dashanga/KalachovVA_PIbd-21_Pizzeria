namespace ForgeView
{
    partial class FormStorageLoad
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StorageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSave2Csv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StorageColumn,
            this.IngredientColumn,
            this.CountColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(506, 351);
            this.dataGridView1.TabIndex = 0;
            // 
            // StorageColumn
            // 
            this.StorageColumn.HeaderText = "Склад";
            this.StorageColumn.Name = "StorageColumn";
            // 
            // IngredientColumn
            // 
            this.IngredientColumn.HeaderText = "Ингредиент";
            this.IngredientColumn.Name = "IngredientColumn";
            // 
            // CountColumn
            // 
            this.CountColumn.HeaderText = "Количество";
            this.CountColumn.Name = "CountColumn";
            // 
            // buttonSave2Csv
            // 
            this.buttonSave2Csv.Location = new System.Drawing.Point(628, 12);
            this.buttonSave2Csv.Name = "buttonSave2Csv";
            this.buttonSave2Csv.Size = new System.Drawing.Size(133, 74);
            this.buttonSave2Csv.TabIndex = 1;
            this.buttonSave2Csv.Text = "Сохранить в Excel";
            this.buttonSave2Csv.UseVisualStyleBackColor = true;
            this.buttonSave2Csv.Click += new System.EventHandler(this.buttonSave2Csv_Click);
            // 
            // FormStorageLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSave2Csv);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormStorageLoad";
            this.Text = "FormStorageLoad";
            this.Load += new System.EventHandler(this.FormStorageLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StorageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountColumn;
        private System.Windows.Forms.Button buttonSave2Csv;
    }
}