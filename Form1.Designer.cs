namespace DeliveryApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            ToolStripMenuItem_FoodType = new ToolStripMenuItem();
            ToolStripMenuItem_Food = new ToolStripMenuItem();
            ToolStripMenuItem_Basket = new ToolStripMenuItem();
            ToolStripMenuItem_User = new ToolStripMenuItem();
            ToolStripMenuItem_Order = new ToolStripMenuItem();
            ToolStripMenuItem_OrderStatus = new ToolStripMenuItem();
            ToolStripMenuItem_Worker = new ToolStripMenuItem();
            ToolStripMenuItem_Role = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            Button_AddData = new Button();
            Button_EditData = new Button();
            Button_DeleteData = new Button();
            Button_SaveData = new Button();
            Button_CancelChanges = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem_FoodType, ToolStripMenuItem_Food, ToolStripMenuItem_Basket, ToolStripMenuItem_User, ToolStripMenuItem_Order, ToolStripMenuItem_OrderStatus, ToolStripMenuItem_Worker, ToolStripMenuItem_Role });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(942, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_FoodType
            // 
            ToolStripMenuItem_FoodType.Name = "ToolStripMenuItem_FoodType";
            ToolStripMenuItem_FoodType.Size = new Size(75, 20);
            ToolStripMenuItem_FoodType.Text = "Food_Type";
            ToolStripMenuItem_FoodType.Click += ToolStripMenuItem_FoodType_Click;
            // 
            // ToolStripMenuItem_Food
            // 
            ToolStripMenuItem_Food.Name = "ToolStripMenuItem_Food";
            ToolStripMenuItem_Food.Size = new Size(46, 20);
            ToolStripMenuItem_Food.Text = "Food";
            ToolStripMenuItem_Food.Click += ToolStripMenuItem_Food_Click;
            // 
            // ToolStripMenuItem_Basket
            // 
            ToolStripMenuItem_Basket.Name = "ToolStripMenuItem_Basket";
            ToolStripMenuItem_Basket.Size = new Size(53, 20);
            ToolStripMenuItem_Basket.Text = "Basket";
            ToolStripMenuItem_Basket.Click += ToolStripMenuItem_Basket_Click;
            // 
            // ToolStripMenuItem_User
            // 
            ToolStripMenuItem_User.Name = "ToolStripMenuItem_User";
            ToolStripMenuItem_User.Size = new Size(42, 20);
            ToolStripMenuItem_User.Text = "User";
            ToolStripMenuItem_User.Click += ToolStripMenuItem_User_Click;
            // 
            // ToolStripMenuItem_Order
            // 
            ToolStripMenuItem_Order.Name = "ToolStripMenuItem_Order";
            ToolStripMenuItem_Order.Size = new Size(49, 20);
            ToolStripMenuItem_Order.Text = "Order";
            ToolStripMenuItem_Order.Click += ToolStripMenuItem_Order_Click;
            // 
            // ToolStripMenuItem_OrderStatus
            // 
            ToolStripMenuItem_OrderStatus.Name = "ToolStripMenuItem_OrderStatus";
            ToolStripMenuItem_OrderStatus.Size = new Size(86, 20);
            ToolStripMenuItem_OrderStatus.Text = "Order_Status";
            ToolStripMenuItem_OrderStatus.Click += ToolStripMenuItem_OrderStatus_Click;
            // 
            // ToolStripMenuItem_Worker
            // 
            ToolStripMenuItem_Worker.Name = "ToolStripMenuItem_Worker";
            ToolStripMenuItem_Worker.Size = new Size(57, 20);
            ToolStripMenuItem_Worker.Text = "Worker";
            ToolStripMenuItem_Worker.Click += ToolStripMenuItem_Worker_Click;
            // 
            // ToolStripMenuItem_Role
            // 
            ToolStripMenuItem_Role.Name = "ToolStripMenuItem_Role";
            ToolStripMenuItem_Role.Size = new Size(42, 20);
            ToolStripMenuItem_Role.Text = "Role";
            ToolStripMenuItem_Role.Click += ToolStripMenuItem_Role_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(918, 753);
            dataGridView1.TabIndex = 1;
            // 
            // Button_AddData
            // 
            Button_AddData.Location = new Point(12, 791);
            Button_AddData.Name = "Button_AddData";
            Button_AddData.Size = new Size(123, 23);
            Button_AddData.TabIndex = 2;
            Button_AddData.Text = "Добавить запись";
            Button_AddData.UseVisualStyleBackColor = true;
            Button_AddData.Click += Button_AddData_Click;
            // 
            // Button_EditData
            // 
            Button_EditData.Location = new Point(141, 791);
            Button_EditData.Name = "Button_EditData";
            Button_EditData.Size = new Size(143, 23);
            Button_EditData.TabIndex = 3;
            Button_EditData.Text = "Редактировать запись";
            Button_EditData.UseVisualStyleBackColor = true;
            Button_EditData.Click += Button_EditData_Click;
            // 
            // Button_DeleteData
            // 
            Button_DeleteData.Location = new Point(290, 791);
            Button_DeleteData.Name = "Button_DeleteData";
            Button_DeleteData.Size = new Size(143, 23);
            Button_DeleteData.TabIndex = 4;
            Button_DeleteData.Text = "Удалить запись";
            Button_DeleteData.UseVisualStyleBackColor = true;
            Button_DeleteData.Click += Button_DeleteData_Click;
            // 
            // Button_SaveData
            // 
            Button_SaveData.Location = new Point(508, 791);
            Button_SaveData.Name = "Button_SaveData";
            Button_SaveData.Size = new Size(143, 23);
            Button_SaveData.TabIndex = 5;
            Button_SaveData.Text = "Сохранить таблицу";
            Button_SaveData.UseVisualStyleBackColor = true;
            Button_SaveData.Click += Button_SaveData_Click;
            // 
            // Button_CancelChanges
            // 
            Button_CancelChanges.Enabled = false;
            Button_CancelChanges.Location = new Point(657, 791);
            Button_CancelChanges.Name = "Button_CancelChanges";
            Button_CancelChanges.Size = new Size(143, 23);
            Button_CancelChanges.TabIndex = 6;
            Button_CancelChanges.Text = "Отменить изменения";
            Button_CancelChanges.UseVisualStyleBackColor = true;
            Button_CancelChanges.Click += Button_CancelChanges_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 827);
            Controls.Add(Button_CancelChanges);
            Controls.Add(Button_SaveData);
            Controls.Add(Button_DeleteData);
            Controls.Add(Button_EditData);
            Controls.Add(Button_AddData);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "DeliveryApp";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem ToolStripMenuItem_FoodType;
        private ToolStripMenuItem ToolStripMenuItem_Food;
        private ToolStripMenuItem ToolStripMenuItem_Basket;
        private ToolStripMenuItem ToolStripMenuItem_User;
        private ToolStripMenuItem ToolStripMenuItem_Order;
        private ToolStripMenuItem ToolStripMenuItem_OrderStatus;
        private ToolStripMenuItem ToolStripMenuItem_Worker;
        private ToolStripMenuItem ToolStripMenuItem_Role;
        private DataGridView dataGridView1;
        private Button Button_AddData;
        private Button Button_EditData;
        private Button Button_DeleteData;
        private Button Button_SaveData;
        private Button Button_CancelChanges;

    }
}