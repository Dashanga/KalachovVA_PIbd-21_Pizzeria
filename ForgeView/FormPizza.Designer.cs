namespace ForgeView
{
    partial class FormPizza
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
            this.labelPizzaName = new System.Windows.Forms.Label();
            this.labelCost = new System.Windows.Forms.Label();
            this.maskedTextBoxPizzaName = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxCost = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPizzaName
            // 
            this.labelPizzaName.AutoSize = true;
            this.labelPizzaName.Location = new System.Drawing.Point(12, 9);
            this.labelPizzaName.Name = "labelPizzaName";
            this.labelPizzaName.Size = new System.Drawing.Size(76, 17);
            this.labelPizzaName.TabIndex = 0;
            this.labelPizzaName.Text = "Название:";
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Location = new System.Drawing.Point(12, 50);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(47, 17);
            this.labelCost.TabIndex = 1;
            this.labelCost.Text = "Цена:";
            // 
            // maskedTextBoxPizzaName
            // 
            this.maskedTextBoxPizzaName.Location = new System.Drawing.Point(91, 9);
            this.maskedTextBoxPizzaName.Name = "maskedTextBoxPizzaName";
            this.maskedTextBoxPizzaName.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBoxPizzaName.TabIndex = 2;
            // 
            // maskedTextBoxCost
            // 
            this.maskedTextBoxCost.Location = new System.Drawing.Point(91, 50);
            this.maskedTextBoxCost.Name = "maskedTextBoxCost";
            this.maskedTextBoxCost.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBoxCost.TabIndex = 3;
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.buttonUpdate);
            this.groupBoxData.Controls.Add(this.buttonDel);
            this.groupBoxData.Controls.Add(this.buttonRef);
            this.groupBoxData.Controls.Add(this.buttonAdd);
            this.groupBoxData.Controls.Add(this.dataGridView);
            this.groupBoxData.Location = new System.Drawing.Point(15, 78);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(714, 315);
            this.groupBoxData.TabIndex = 4;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Ингредиенты";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(567, 61);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Изменить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(567, 107);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 3;
            this.buttonDel.Text = "Удалит";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(567, 153);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(75, 23);
            this.buttonRef.TabIndex = 2;
            this.buttonRef.Text = "Обновить";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(567, 21);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(6, 21);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(434, 288);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(654, 415);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(491, 415);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormPizza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxData);
            this.Controls.Add(this.maskedTextBoxCost);
            this.Controls.Add(this.maskedTextBoxPizzaName);
            this.Controls.Add(this.labelCost);
            this.Controls.Add(this.labelPizzaName);
            this.Name = "FormPizza";
            this.Text = "FormPizza";
            this.Load += new System.EventHandler(this.FormPizza_Load);
            this.groupBoxData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPizzaName;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPizzaName;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCost;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}