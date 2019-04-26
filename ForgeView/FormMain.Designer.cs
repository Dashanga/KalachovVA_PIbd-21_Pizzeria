namespace ForgeView
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingredientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pizzasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.putOnStorageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прайсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storageLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.buttonPaid = new System.Windows.Forms.Button();
            this.implementersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.putOnStorageItem,
            this.reportsToolStripMenuItem,
            this.startWorkToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(717, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerToolStripMenuItem,
            this.ingredientsToolStripMenuItem,
            this.pizzasToolStripMenuItem,
            this.storagesToolStripMenuItem,
            this.implementersToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.helpToolStripMenuItem.Text = "Справка";
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.customerToolStripMenuItem.Text = "Покупатели";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // ingredientsToolStripMenuItem
            // 
            this.ingredientsToolStripMenuItem.Name = "ingredientsToolStripMenuItem";
            this.ingredientsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.ingredientsToolStripMenuItem.Text = "Ингредиенты";
            this.ingredientsToolStripMenuItem.Click += new System.EventHandler(this.ingredientsToolStripMenuItem_Click);
            // 
            // pizzasToolStripMenuItem
            // 
            this.pizzasToolStripMenuItem.Name = "pizzasToolStripMenuItem";
            this.pizzasToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.pizzasToolStripMenuItem.Text = "Пиццы";
            this.pizzasToolStripMenuItem.Click += new System.EventHandler(this.pizzasToolStripMenuItem_Click);
            // 
            // storagesToolStripMenuItem
            // 
            this.storagesToolStripMenuItem.Name = "storagesToolStripMenuItem";
            this.storagesToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.storagesToolStripMenuItem.Text = "Склады";
            this.storagesToolStripMenuItem.Click += new System.EventHandler(this.storagesToolStripMenuItem_Click);
            // 
            // putOnStorageItem
            // 
            this.putOnStorageItem.Name = "putOnStorageItem";
            this.putOnStorageItem.Size = new System.Drawing.Size(141, 24);
            this.putOnStorageItem.Text = "Пополнить склад";
            this.putOnStorageItem.Click += new System.EventHandler(this.putOnStorageItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прайсToolStripMenuItem,
            this.storageLoadToolStripMenuItem,
            this.customerOrdersToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.reportsToolStripMenuItem.Text = "Отчеты";
            // 
            // прайсToolStripMenuItem
            // 
            this.прайсToolStripMenuItem.Name = "прайсToolStripMenuItem";
            this.прайсToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.прайсToolStripMenuItem.Text = "Прайс";
            this.прайсToolStripMenuItem.Click += new System.EventHandler(this.прайсToolStripMenuItem_Click);
            // 
            // storageLoadToolStripMenuItem
            // 
            this.storageLoadToolStripMenuItem.Name = "storageLoadToolStripMenuItem";
            this.storageLoadToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.storageLoadToolStripMenuItem.Text = "Загруженность складов";
            this.storageLoadToolStripMenuItem.Click += new System.EventHandler(this.storageLoadToolStripMenuItem_Click);
            // 
            // customerOrdersToolStripMenuItem
            // 
            this.customerOrdersToolStripMenuItem.Name = "customerOrdersToolStripMenuItem";
            this.customerOrdersToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.customerOrdersToolStripMenuItem.Text = "Заказы клиентов";
            this.customerOrdersToolStripMenuItem.Click += new System.EventHandler(this.customerOrdersToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 31);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(475, 379);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(524, 31);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(181, 54);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Сделать заказ";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(524, 355);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(181, 55);
            this.buttonRef.TabIndex = 3;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // buttonPaid
            // 
            this.buttonPaid.Location = new System.Drawing.Point(524, 271);
            this.buttonPaid.Name = "buttonPaid";
            this.buttonPaid.Size = new System.Drawing.Size(181, 59);
            this.buttonPaid.TabIndex = 4;
            this.buttonPaid.Text = "Заказ оплачен";
            this.buttonPaid.UseVisualStyleBackColor = true;
            this.buttonPaid.Click += new System.EventHandler(this.buttonPaid_Click);
            // 
            // implementersToolStripMenuItem
            // 
            this.implementersToolStripMenuItem.Name = "implementersToolStripMenuItem";
            this.implementersToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.implementersToolStripMenuItem.Text = "Исполнители";
            this.implementersToolStripMenuItem.Click += new System.EventHandler(this.implementersToolStripMenuItem_Click);
            // 
            // startWorkToolStripMenuItem
            // 
            this.startWorkToolStripMenuItem.Name = "startWorkToolStripMenuItem";
            this.startWorkToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.startWorkToolStripMenuItem.Text = "Запуск работ";
            this.startWorkToolStripMenuItem.Click += new System.EventHandler(this.startWorkToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 423);
            this.Controls.Add(this.buttonPaid);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Управление заказами";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingredientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pizzasToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.Button buttonPaid;
        private System.Windows.Forms.ToolStripMenuItem storagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem putOnStorageItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прайсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storageLoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem implementersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startWorkToolStripMenuItem;
    }
}

