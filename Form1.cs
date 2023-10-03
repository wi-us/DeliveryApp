using DeliveryApp.Resourses;

namespace DeliveryApp
{
    public partial class Form1 : Form
    {

        DeliveryApp.Resourses.DataBase db = new DeliveryApp.Resourses.DataBase();
        List<DataGridView> grids = new List<DataGridView>();
        public bool userAuthorized = false;
        public Form1()
        {

            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            Window_Authorization authorization = new Window_Authorization();
            authorization.Show();
            //authorization.EnabledChanged += Form1_Load;



            db.CollectData();
        }
        private void Button_AddData_Click(object sender, EventArgs e)
        {
            dynamic form = this.FindForm();
            int i = 0;

            foreach (var item in form.Controls["menuStrip1"].Items)
            {
                //var d = nameof(Tables.User);

                if (item.Checked == true)
                {
                    Window_EditData windowEditData = new Window_EditData();
                    int windowSizeX = 10;
                    int windowSizeY = 25;

                    foreach (var grid in grids)
                    {
                        if (grid.Name == item.Text)
                        {

                            int labelWidth = 100;
                            int labelHeight = 15;

                            int textBoxWidth = 100;
                            int textBoxHeight = 15;

                            int intervalWidth = 30;
                            int intervalHeight = 12;

                            int buttonWidth = 90;
                            int buttonHeight = 30;

                            Point labelPos = new Point(intervalWidth, intervalHeight);
                            Point textBoxPos = new Point(intervalWidth * 2 + labelWidth, intervalHeight);


                            foreach (DataGridViewColumn column in grid.Columns)
                            {
                                System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                                System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
                                textBox.Size = new Size(textBoxWidth, textBoxHeight);
                                label.Size = new Size(labelWidth, labelHeight);

                                label.Text = column.HeaderText;
                                label.Location = labelPos;
                                label.Visible = true;

                                if (column.HeaderText == "id" || column.HeaderText == "ID" || column.HeaderText == "Id")
                                {
                                    textBox.Text = (Convert.ToUInt32(grid.Rows[grid.Rows.Count - 1].Cells[column.HeaderText].Value) + 1).ToString();
                                }

                                textBox.Location = textBoxPos;
                                textBox.Visible = true;

                                labelPos.Y += (intervalHeight + labelHeight);
                                textBoxPos.Y += (intervalHeight + textBoxHeight);

                                windowEditData.Controls.Add(label);
                                windowEditData.Controls.Add(textBox);
                            }
                            windowSizeX = textBoxPos.X + textBoxWidth + intervalWidth;
                            windowSizeY = textBoxPos.Y + textBoxHeight + intervalHeight;

                            Point buttonPos = new Point(labelPos.X, textBoxPos.Y + intervalHeight);

                            System.Windows.Forms.Button button = new System.Windows.Forms.Button();
                            button.Location = buttonPos;
                            button.Size = new Size(buttonWidth, buttonHeight);
                            button.Visible = true;
                            button.FlatStyle = FlatStyle.System;
                            button.Text = "Сохранить";
                            button.Click += buttonClick_AddDataInTable;
                            button.Tag = item.Text;

                            windowEditData.Controls.Add(button);


                            windowSizeY += buttonHeight + intervalHeight * 3;
                        }

                        void buttonClick_AddDataInTable(object sender, EventArgs e)
                        {
                            var tag = (string)((System.Windows.Forms.Button)sender).Tag;
                            List<object> list = new List<object>();

                            foreach (var obj in windowEditData.Controls.OfType<System.Windows.Forms.TextBox>())
                            {
                                list.Add(obj.Text);
                            }
                            grid.Rows.Add(list.ToArray());

                            switch (tag)
                            {
                                case "Food":
                                    {
                                        Food food = new Food();

                                        db.food.Add(food.CastToThisClass(list));
                                        break;
                                    }
                                case "Food_Type":
                                    {
                                        Food_Type food_type = new Food_Type();

                                        db.foodTypes.Add(food_type.CastToThisClass(list));
                                        break;
                                    }
                                case "Basket":
                                    {
                                        Basket basket = new Basket();

                                        db.basket.Add(basket.CastToThisClass(list));
                                        break;
                                    }
                                case "User":
                                    {
                                        User user = new User();

                                        db.user.Add(user.CastToThisClass(list));
                                        break;
                                    }
                                case "Order":
                                    {
                                        Order order = new Order();

                                        db.order.Add(order.CastToThisClass(list));

                                        break;
                                    }
                                case "Order_Status":
                                    {
                                        Order_Status order_status = new Order_Status();
                                        order_status.CastToThisClass(list);
                                        db.orderStatus.Add(order_status);
                                        break;
                                    }
                                case "Worker":
                                    {
                                        Worker worker = new Worker();

                                        db.worker.Add(worker.CastToThisClass(list));
                                        break;
                                    }
                                case "Role":
                                    {
                                        Role role = new Role();

                                        db.role.Add(role.CastToThisClass(list));
                                        break;
                                    }
                            }

                        }
                    }

                    windowEditData.Size = new Size(windowSizeX, windowSizeY);
                    windowEditData.Show();



                    break;

                }
                i++;
            }
        }
        private void ToolStripMenuItem_FoodType_Click(object sender, EventArgs e)
        {
            dynamic form = this.FindForm();

            var menuItem = (ToolStripMenuItem)sender;

            var table = db.foodTypes;
            dataGridView1.Visible = false;
            HideAllTables();
            //проверка существует ли таблица
            CheckTheToolMenuItem(menuItem);
            bool isGridExist = IsTableExist(menuItem);
            //если таблица не существует
            if (!isGridExist)
            {
                FormTable(db.foodTypes, menuItem.Text);
                foreach (var item in table)
                {
                    object[] obj = new object[] { item.id, item.Type };
                    grids[grids.Count - 1].Rows.Add(obj);
                }
            }
        }
        private void ToolStripMenuItem_Food_Click(object sender, EventArgs e)
        {
            //заполнение таблицы данными FoodType

            dynamic form = FindForm();

            var menu = ((ToolStripMenuItem)sender).Owner;
            var menuItem = (ToolStripMenuItem)sender;
            bool isGridExist = false;
            var table = db.food;
            dataGridView1.Visible = false;

            HideAllTables();
            //проверка существует ли таблица
            CheckTheToolMenuItem(menuItem);
            isGridExist = IsTableExist(menuItem);
            //если таблица не существует
            if (!isGridExist)
            {
                FormTable(db.food, menuItem.Text);
                foreach (var item in table)
                {
                    object[] obj = new object[] { item.id, item.Name, item.Type_id, item.Picture, item.Price };
                    grids[grids.Count - 1].Rows.Add(obj);
                }
            }
        }

        private void Button_SaveData_Click(object sender, EventArgs e)
        {
            db.RewriteData(db);
            MessageBox.Show("Данные успешно сохранены!", "Готово!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void HideAllTables()
        {
            foreach (var grid in grids)
            {
                grid.Visible = false;
            }
        }
        public void CheckTheToolMenuItem(ToolStripMenuItem menuItem, bool CheckItem = true)
        {
            dynamic form = FindForm();

            ToolStrip menu = menuItem.Owner;

            foreach (ToolStripMenuItem item in menu.Items)
            {
                item.Checked = false;
            }
            if (CheckItem)
            {
                menuItem.Checked = true;
            }

        }
        public bool IsTableExist(ToolStripMenuItem menuItem, bool ShowTable = true)
        {
            foreach (var grid in grids)
            {
                if (menuItem.Text == grid.Name)
                {
                    if (ShowTable)
                    {
                        grid.Visible = true;
                    }
                    return true;
                }
            }
            return false;
        }
        public int? FindIndexOfEnables()
        {
            foreach (var grid in grids)
            {
                if (grid.Visible)
                {
                    return grids.IndexOf(grid);
                }
            }
            return null;
        }
        private void Button_DeleteData_Click(object sender, EventArgs e)
        {

            dynamic tag = FindForm().Controls["menuStrip1"];
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            foreach (var item in tag.Items)
            {
                if (item.Checked)
                {
                    menuItem = item;
                }
            }

            if (FindIndexOfEnables() != null)
            {
                var i = Convert.ToInt32(FindIndexOfEnables());
                var t = grids[i].SelectedRows;
                foreach (DataGridViewRow row in t)
                {
                    switch (menuItem.Text)
                    {
                        case "Food":
                            {
                                Food food = new Food();

                                db.food.RemoveAt(row.Index);
                                break;
                            }
                        case "Food_Type":
                            {
                                Food_Type food_type = new Food_Type();

                                db.foodTypes.RemoveAt(row.Index);
                                break;
                            }
                        case "Basket":
                            {
                                Basket basket = new Basket();

                                db.basket.RemoveAt(row.Index);
                                break;
                            }
                        case "User":
                            {
                                User user = new User();

                                db.user.RemoveAt(row.Index);
                                break;
                            }
                        case "Order":
                            {
                                Order order = new Order();

                                db.order.RemoveAt(row.Index);

                                break;
                            }
                        case "Order_Status":
                            {
                                Order_Status order_status = new Order_Status();
                                db.orderStatus.RemoveAt(row.Index);
                                break;
                            }
                        case "Worker":
                            {
                                Worker worker = new Worker();

                                db.worker.RemoveAt(row.Index);
                                break;
                            }
                        case "Role":
                            {
                                Role role = new Role();

                                db.role.RemoveAt(row.Index);
                                break;
                            }
                    }
                    if (MessageBox.Show("Вы уверены, что хотите удалить выбранные строки?", "Точно?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        grids[i].Rows.Remove(row);
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }

        private void Button_EditData_Click(object sender, EventArgs e)
        {
            dynamic form = this.FindForm();
            int i = 0;
            int selectedIndex = 0;


            foreach (var item in form.Controls["menuStrip1"].Items)
            {
                //var d = nameof(Tables.User);

                if (item.Checked == true)
                {
                    Window_EditData windowEditData = new Window_EditData();
                    int windowSizeX = 10;
                    int windowSizeY = 25;

                    foreach (var grid in grids)
                    {
                        if (grid.Name == item.Text)
                        {
                            if (grid.SelectedRows.Count != 0)
                            {
                                selectedIndex = grid.SelectedRows[0].Index;
                            }
                            else
                            {
                                break;
                            }
                            int labelWidth = 100;
                            int labelHeight = 15;

                            int textBoxWidth = 100;
                            int textBoxHeight = 15;

                            int intervalWidth = 30;
                            int intervalHeight = 12;

                            int buttonWidth = 90;
                            int buttonHeight = 30;

                            Point labelPos = new Point(intervalWidth, intervalHeight);
                            Point textBoxPos = new Point(intervalWidth * 2 + labelWidth, intervalHeight);

                            int j = 0;
                            foreach (DataGridViewColumn column in grid.Columns)
                            {
                                System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                                System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
                                textBox.Name = column.Name;
                                label.Name = column.Name;

                                textBox.Size = new Size(textBoxWidth, textBoxHeight);
                                label.Size = new Size(labelWidth, labelHeight);

                                label.Text = column.HeaderText;
                                label.Location = labelPos;
                                label.Visible = true;

                                textBox.Text = grid.SelectedRows[0].Cells[j].Value.ToString();


                                textBox.Location = textBoxPos;
                                textBox.Visible = true;

                                labelPos.Y += (intervalHeight + labelHeight);
                                textBoxPos.Y += (intervalHeight + textBoxHeight);

                                windowEditData.Controls.Add(label);
                                windowEditData.Controls.Add(textBox);

                                //windowSizeX = label.Size.Width + textBox.Size.Width + 40;
                                //windowSizeY = (label.Size.Height + 12) * grid.Columns.Count + 50;
                                //windowSizeY = label.Location.Y + 50;
                                j++;
                            }

                            //windowSizeX = intervalWidth * 3 + labelWidth + textBoxWidth;
                            windowSizeX = textBoxPos.X + textBoxWidth + intervalWidth;
                            //windowSizeY = (textBoxHeight * grid.Columns.Count) + ((intervalHeight+2) * grid.Columns.Count);
                            windowSizeY = textBoxPos.Y + textBoxHeight + intervalHeight;

                            Point buttonPos = new Point(labelPos.X, textBoxPos.Y + intervalHeight);

                            System.Windows.Forms.Button button = new System.Windows.Forms.Button();
                            button.Location = buttonPos;
                            button.Size = new Size(buttonWidth, buttonHeight);
                            button.Visible = true;
                            button.FlatStyle = FlatStyle.System;
                            button.Text = "Сохранить";
                            button.Click += buttonClick_AddDataInTable;
                            button.Tag = item.Text;

                            windowEditData.Controls.Add(button);


                            windowSizeY += buttonHeight + intervalHeight * 3;
                        }

                        void buttonClick_AddDataInTable(object sender, EventArgs e)
                        {
                            //object[] objects = new object[] { windowEditData.Controls.OfType<System.Windows.Forms.TextBox>() };
                            var tag = (string)((System.Windows.Forms.Button)sender).Tag;
                            List<object> list = new List<object>();

                            int k = 0;
                            foreach (var obj in windowEditData.Controls.OfType<System.Windows.Forms.TextBox>())
                            {
                                list.Add(obj.Text);
                                grid.Rows[selectedIndex].Cells[k].Value = obj.Text;
                                k++;
                            }
                            grid.Rows.Add(list.ToArray());



                            switch (tag)
                            {
                                case "Food":
                                    {
                                        Food food = new Food();
                                        db.food[selectedIndex] = food.CastToThisClass(list);
                                        break;
                                    }
                                case "Food_Type":
                                    {
                                        Food_Type food_type = new Food_Type();

                                        db.foodTypes[selectedIndex] = food_type.CastToThisClass(list);
                                        break;
                                    }
                                case "Basket":
                                    {
                                        Basket basket = new Basket();

                                        db.basket[selectedIndex] = basket.CastToThisClass(list);
                                        break;
                                    }
                                case "User":
                                    {
                                        User user = new User();

                                        db.user[selectedIndex] = user.CastToThisClass(list);
                                        break;
                                    }
                                case "Order":
                                    {
                                        Order order = new Order();

                                        db.order[selectedIndex] = order.CastToThisClass(list);

                                        break;
                                    }
                                case "Order_Status":
                                    {
                                        Order_Status order_status = new Order_Status();
                                        order_status.CastToThisClass(list);
                                        db.orderStatus.Add(order_status);
                                        break;
                                    }
                                case "Worker":
                                    {
                                        Worker worker = new Worker();

                                        db.worker[selectedIndex] = worker.CastToThisClass(list);
                                        break;
                                    }
                                case "Role":
                                    {
                                        Role role = new Role();

                                        db.role[selectedIndex] = role.CastToThisClass(list);
                                        break;
                                    }
                            }

                            grid.Rows.RemoveAt(selectedIndex);
                        }
                    }

                    windowEditData.Size = new Size(windowSizeX, windowSizeY);
                    windowEditData.Show();



                    break;

                }
                i++;
            }

        }

        private void ToolStripMenuItem_Basket_Click(object sender, EventArgs e)
        {
            //заполнение таблицы данными FoodType

            dynamic form = FindForm();

            var menu = ((ToolStripMenuItem)sender).Owner;
            var menuItem = (ToolStripMenuItem)sender;
            bool isGridExist = false;
            var table = db.basket;
            dataGridView1.Visible = false;

            HideAllTables();
            //проверка существует ли таблица
            CheckTheToolMenuItem(menuItem);
            isGridExist = IsTableExist(menuItem);
            //если таблица не существует
            if (!isGridExist)
            {
                FormTable(table, menuItem.Text);
                foreach (var item in table)
                {
                    object[] obj = new object[] { item.id, item.Price, item.User_ID, item.Food_ID };
                    grids[grids.Count - 1].Rows.Add(obj);
                }
            }
        }

        private void ToolStripMenuItem_User_Click(object sender, EventArgs e)
        {
            //заполнение таблицы данными FoodType

            dynamic form = FindForm();

            var menu = ((ToolStripMenuItem)sender).Owner;
            var menuItem = (ToolStripMenuItem)sender;
            bool isGridExist = false;
            var table = db.user;
            dataGridView1.Visible = false;

            HideAllTables();
            //проверка существует ли таблица
            CheckTheToolMenuItem(menuItem);
            isGridExist = IsTableExist(menuItem);
            //если таблица не существует
            if (!isGridExist)
            {
                FormTable(table, menuItem.Text);
                foreach (var item in table)
                {
                    object[] obj = new object[] { item.id, item.Telegram_ID, item.Adress, item.Phone, item.Mail };
                    grids[grids.Count - 1].Rows.Add(obj);
                }
            }
        }

        private void ToolStripMenuItem_Order_Click(object sender, EventArgs e)
        {
            //заполнение таблицы данными FoodType

            dynamic form = FindForm();

            var menu = ((ToolStripMenuItem)sender).Owner;
            var menuItem = (ToolStripMenuItem)sender;
            bool isGridExist = false;
            var table = db.order;
            dataGridView1.Visible = false;

            HideAllTables();
            //проверка существует ли таблица
            CheckTheToolMenuItem(menuItem);
            isGridExist = IsTableExist(menuItem);
            //если таблица не существует
            if (!isGridExist)
            {
                FormTable(table, menuItem.Text);
                foreach (var item in table)
                {
                    object[] obj = new object[] { item.id, item.Basket_ID, item.Date, item.Status, item.Price, item.Worker_ID };
                    grids[grids.Count - 1].Rows.Add(obj);
                }
            }
        }

        private void ToolStripMenuItem_OrderStatus_Click(object sender, EventArgs e)
        {
            //заполнение таблицы данными FoodType

            dynamic form = FindForm();

            var menu = ((ToolStripMenuItem)sender).Owner;
            var menuItem = (ToolStripMenuItem)sender;
            bool isGridExist = false;
            var table = db.orderStatus;
            dataGridView1.Visible = false;

            HideAllTables();
            //проверка существует ли таблица
            CheckTheToolMenuItem(menuItem);
            isGridExist = IsTableExist(menuItem);
            //если таблица не существует
            if (!isGridExist)
            {
                FormTable(table, menuItem.Text);
                foreach (var item in table)
                {
                    object[] obj = new object[] { item.id, item.Type };
                    grids[grids.Count - 1].Rows.Add(obj);
                }
            }
        }

        private void ToolStripMenuItem_Worker_Click(object sender, EventArgs e)
        {
            //заполнение таблицы данными FoodType

            dynamic form = FindForm();

            var menu = ((ToolStripMenuItem)sender).Owner;
            var menuItem = (ToolStripMenuItem)sender;
            bool isGridExist = false;
            var table = db.worker;
            dataGridView1.Visible = false;

            HideAllTables();
            //проверка существует ли таблица
            CheckTheToolMenuItem(menuItem);
            isGridExist = IsTableExist(menuItem);
            //если таблица не существует
            if (!isGridExist)
            {
                FormTable(table, menuItem.Text);
                foreach (var item in table)
                {
                    object[] obj = new object[] { item.id, item.Role_ID, item.Login, item.Password, item.Email, item.Phone };
                    grids[grids.Count - 1].Rows.Add(obj);
                }
            }
        }

        private void ToolStripMenuItem_Role_Click(object sender, EventArgs e)
        {
            //заполнение таблицы данными FoodType

            dynamic form = FindForm();

            var menu = ((ToolStripMenuItem)sender).Owner;
            var menuItem = (ToolStripMenuItem)sender;
            bool isGridExist = false;
            var table = db.role;
            dataGridView1.Visible = false;

            HideAllTables();
            //проверка существует ли таблица
            CheckTheToolMenuItem(menuItem);
            isGridExist = IsTableExist(menuItem);
            //если таблица не существует
            if (!isGridExist)
            {
                FormTable(table, menuItem.Text);
                foreach (var item in table)
                {
                    object[] obj = new object[] { item.id, item.Name };
                    grids[grids.Count - 1].Rows.Add(obj);
                }
            }
        }

        private void Button_CancelChanges_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите отменить ВСЕ изменения?", "Точно?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                db.CollectData();
                grids.Clear();
                dynamic form = FindForm();
                foreach (var item in form.Controls)
                {
                    if (item.Name != "dataGridView1" && item.GetType().Name == "DataGridView")
                    {
                        form.Controls.Remove(item);
                    }
                }

                ToolStripMenuItem_FoodType_Click(menuStrip1.Items[0], e);


            }
        }
        public void RefreshTables()
        {
            db.CollectData();
            FormTable(db.food, db.food[0].Name);
            foreach (var row in db.food)
            {

                DataGridView dataGridView1 = new DataGridView();
                foreach (var grid in grids)
                {
                    if (grid.Name == row.Name)
                    {

                    }
                }
            }
        }
        public void FormTable<T>(List<T> data, string gridName)
        {
            DataGridView dataGridView = new DataGridView();
            dataGridView.Location = dataGridView1.Location;
            dataGridView.Size = dataGridView1.Size;
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;

            dynamic table = data;
            int i = 0;
            foreach (var item in table[0].columnNames)
            {
                DataGridViewColumn column = new DataGridViewColumn();

                DataGridViewCell cell = new DataGridViewTextBoxCell();

                column.Name = item;
                column.HeaderText = item;
                column.CellTemplate = cell;
                column.Visible = true;
                dataGridView.Columns.Add(column);
                column.ValueType = table[0].types[i];
                i++;
            }

            //dataGridView.Rows[dataGridView.Rows.Count - 1].Visible = false;
            dataGridView.Name = gridName;
            //отображаем таблицу
            dataGridView.Visible = true;
            //добавляем таблицу в существующие

            dynamic form = FindForm();
            form.Controls.Add(dataGridView);
            grids.Add(form.Controls[form.Controls.Count - 1]);
        }
    }
}