﻿namespace ForgeView
{
    partial class FormPizzaIngredient
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
            this.comboBoxProductComponents = new System.Windows.Forms.ComboBox();
            this.Ингредиент = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.maskedTextBoxCount = new System.Windows.Forms.MaskedTextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxProductComponents
            // 
            this.comboBoxProductComponents.FormattingEnabled = true;
            this.comboBoxProductComponents.Location = new System.Drawing.Point(119, 6);
            this.comboBoxProductComponents.Name = "comboBoxProductComponents";
            this.comboBoxProductComponents.Size = new System.Drawing.Size(254, 24);
            this.comboBoxProductComponents.TabIndex = 0;
            // 
            // Ингредиент
            // 
            this.Ингредиент.AutoSize = true;
            this.Ингредиент.Location = new System.Drawing.Point(23, 13);
            this.Ингредиент.Name = "Ингредиент";
            this.Ингредиент.Size = new System.Drawing.Size(90, 17);
            this.Ингредиент.TabIndex = 1;
            this.Ингредиент.Text = "Ингредиент:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(23, 46);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(57, 17);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "Кол-во:";
            // 
            // maskedTextBoxCount
            // 
            this.maskedTextBoxCount.Location = new System.Drawing.Point(119, 46);
            this.maskedTextBoxCount.Name = "maskedTextBoxCount";
            this.maskedTextBoxCount.Size = new System.Drawing.Size(254, 22);
            this.maskedTextBoxCount.TabIndex = 3;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(119, 96);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(225, 96);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormPizzaIngredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 177);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.maskedTextBoxCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.Ингредиент);
            this.Controls.Add(this.comboBoxProductComponents);
            this.Name = "FormPizzaIngredient";
            this.Text = "FormProductComponent";
            this.Load += new System.EventHandler(this.FormPizzaIngredient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxProductComponents;
        private System.Windows.Forms.Label Ингредиент;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCount;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}