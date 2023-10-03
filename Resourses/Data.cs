using Newtonsoft.Json;
using System.Runtime.Serialization;


namespace DeliveryApp.Resourses
{
    public class DataBase
    {
        public List<Food_Type> foodTypes;
        public List<Food> food;
        public List<Basket> basket;
        public List<User> user;
        public List<Order> order;
        public List<Order_Status> orderStatus;
        public List<Worker> worker;
        public List<Role> role;

        public object[] objects;


        public void CollectData(string path = @"C:\Users\wiusm\source\repos\DeliveryApp\DeliveryApp\Resourses\DataBase\")
        {

            foodTypes = JsonConvert.DeserializeObject<List<Food_Type>>(File.ReadAllText(path + "Food_Type.json"));
            food = JsonConvert.DeserializeObject<List<Food>>(File.ReadAllText(path + "Food.json"));
            basket = JsonConvert.DeserializeObject<List<Basket>>(File.ReadAllText(path + "Basket.json"));
            user = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(path + "User.json"));
            order = JsonConvert.DeserializeObject<List<Order>>(File.ReadAllText(path + "Order.json"));
            orderStatus = JsonConvert.DeserializeObject<List<Order_Status>>(File.ReadAllText(path + "Order_Status.json"));
            worker = JsonConvert.DeserializeObject<List<Worker>>(File.ReadAllText(path + "Worker.json"));
            role = JsonConvert.DeserializeObject<List<Role>>(File.ReadAllText(path + "Role.json"));

            
        }
        public void RewriteData(DataBase data, string path = @"C:\Users\wiusm\source\repos\DeliveryApp\DeliveryApp\Resourses\DataBase\")
        {
            File.WriteAllText(path + "Food_Type.json", string.Empty);
            File.WriteAllText(path + "Food_Type.json", JsonConvert.SerializeObject(data.foodTypes));

            File.WriteAllText(path + "Food.json", string.Empty);
            File.WriteAllText(path + "Food.json", JsonConvert.SerializeObject(data.food));

            File.WriteAllText(path + "Basket.json", string.Empty);
            File.WriteAllText(path + "Basket.json", JsonConvert.SerializeObject(data.basket));

            File.WriteAllText(path + "User.json", string.Empty);
            File.WriteAllText(path + "User.json", JsonConvert.SerializeObject(data.user));

            File.WriteAllText(path + "Order.json", string.Empty);
            File.WriteAllText(path + "Order.json", JsonConvert.SerializeObject(data.order));

            File.WriteAllText(path + "Order_Status.json", string.Empty);
            File.WriteAllText(path + "Order_Status.json", JsonConvert.SerializeObject(data.orderStatus));

            File.WriteAllText(path + "Worker.json", string.Empty);
            File.WriteAllText(path + "Worker.json", JsonConvert.SerializeObject(data.worker));

            File.WriteAllText(path + "Role.json", string.Empty);
            File.WriteAllText(path + "Role.json", JsonConvert.SerializeObject(data.role));

        }
    }
    public enum Tables
    {
        Food_Type = 0, Food, Basket, User, Order, Order_Status, Worker, Role
    }

    public class Food_Type
    {
        [DataMember]
        public uint id;
        [DataMember]
        public string Type;

        [IgnoreDataMember]
        public uint columnCount { get; } = 2;
        [IgnoreDataMember]
        public Tables table { get; } = Tables.Food_Type;
        [IgnoreDataMember]
        public string[] columnNames { get; } = { "id", "Type" };
        [IgnoreDataMember]
        public Type[] types = { typeof(uint), typeof(string) };
        
        
        public Food_Type CastToThisClass(List<object>dataRow)
        {
            if (dataRow.Count <= columnCount)
            {
                Food_Type food_Type = new Food_Type();
                if (!(dataRow[0] is uint))
                {

                    food_Type.id = Convert.ToUInt32(dataRow[0]);
                }
                food_Type.Type = dataRow[1].ToString();

                return food_Type;
            }
            else
            {
                return null;
            }
                
        }
    }
    public class Food
    {
        [DataMember]
        public uint id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public uint Type_id { get; set; }
        [DataMember]
        public string Picture { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [IgnoreDataMember]
        public uint columnCount { get; } = 5;
        [IgnoreDataMember]
        public Tables table { get; } = Tables.Food;
        [IgnoreDataMember]
        public string[] columnNames { get; } = { "id", "Name" , "Type_id", "Picture", "Price" };
        [IgnoreDataMember]
        public Type[] types { get; } = { typeof(uint), typeof(string), typeof(uint), typeof(string), typeof(decimal) };
        public Food CastToThisClass(List<object> dataRow)
        {
            if(dataRow.Count <= columnCount)
            {
                Food food = new Food();
                if (!(dataRow[0] is uint))
                {
                    food.id = Convert.ToUInt32(dataRow[0]);
                }
                food.Name = dataRow[1].ToString();
                if (!(dataRow[2] is uint))
                {
                    food.Type_id = Convert.ToUInt32(dataRow[2]);
                }
                food.Picture = dataRow[3].ToString();
                if (!(dataRow[4] is decimal))
                {
                    food.Price = Convert.ToDecimal(dataRow[4]);
                }
                return food;
            }
            else
            {
                return null;
            }
        }
    }
    public class Basket
    {
        [DataMember]
        public uint id { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public uint User_ID { get; set; }
        [DataMember]
        public uint Food_ID { get; set; }
        [IgnoreDataMember]
        public uint columnCount { get; } = 4;
        [IgnoreDataMember]
        public Tables table { get; } = Tables.Basket;
        [IgnoreDataMember]
        public string[] columnNames { get; } = { "id", "Price", "User_ID", "Food_ID" };
        [IgnoreDataMember]
        public Type[] types { get; } = { typeof(uint), typeof(decimal), typeof(uint), typeof(uint) };
        public Basket CastToThisClass(List<object> dataRow)
        {
            if (dataRow.Count <= columnCount)
            {
                Basket basket = new Basket();
                if (!(dataRow[0] is uint))
                {
                    basket.id = Convert.ToUInt32(dataRow[0]);
                }
                if (!(dataRow[1] is decimal))
                {
                    basket.Price = Convert.ToDecimal(dataRow[1]);
                }
                if (!(dataRow[2] is uint))
                {
                    basket.User_ID = Convert.ToUInt32(dataRow[2]);
                }
                if (!(dataRow[3] is uint))
                {
                    basket.Food_ID = Convert.ToUInt32(dataRow[3]);
                }
                
                return basket;
            }
            else
            {
                return null;
            }
        }
    }
    public class User
    {
        [DataMember]
        public uint id { get; set; }
        [DataMember]
        public uint Telegram_ID { get; set; }
        [DataMember]
        public string Adress { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Mail { get; set; }
        [IgnoreDataMember]
        public uint columnCount { get; } = 5;
        [IgnoreDataMember]
        public Tables table { get; } = Tables.User;
        [IgnoreDataMember]
        public string[] columnNames { get; } = { "id", "Telegram_ID", "Adress", "Phone", "Mail" };
        [IgnoreDataMember]
        public Type[] types { get; } = { typeof(uint), typeof(uint), typeof(string), typeof(string), typeof(string) };
        public User CastToThisClass(List<object> dataRow)
        {
            if (dataRow.Count <= columnCount)
            {
                User user = new User();
                if (!(dataRow[0] is uint))
                {
                    user.id = Convert.ToUInt32(dataRow[0]);
                }
                if (!(dataRow[1] is uint))
                {
                    user.Telegram_ID = Convert.ToUInt32(dataRow[1]);
                }
                user.Adress = dataRow[2].ToString();
                user.Phone = dataRow[3].ToString();
                user.Mail = dataRow[4].ToString();

                return user;
            }
            else
            {
                return null;
            }
        }
    }
    public class Order  
    {
        [DataMember]
        public uint id { get; set; }
        [DataMember]
        public uint Basket_ID { get; set; }
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public uint Status { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public uint Worker_ID { get; set; }
        [IgnoreDataMember]
        public uint columnCount { get; } = 5;
        [IgnoreDataMember]
        public Tables table { get; } = Tables.Order;
        [IgnoreDataMember]
        public string[] columnNames { get; } = { "id", "Basket_ID", "Date", "Status", "Price", "Worker_ID" };
        [IgnoreDataMember]
        public Type[] types { get; } = { typeof(uint), typeof(uint), typeof(string), typeof(uint), typeof(decimal), typeof(uint) };
        public Order CastToThisClass(List<object> dataRow)
        {
            if (dataRow.Count <= columnCount)
            {
                Order order = new Order();
                if (!(dataRow[0] is uint))
                {
                    order.id = Convert.ToUInt32(dataRow[0]);
                }
                if (!(dataRow[1] is uint))
                {
                    order.Basket_ID = Convert.ToUInt32(dataRow[1]);
                }
                order.Date = dataRow[2].ToString();
                if (!(dataRow[3] is uint))
                {
                    order.Status = Convert.ToUInt32(dataRow[3]);
                }
                if (!(dataRow[4] is decimal))
                {
                    order.Price = Convert.ToDecimal(dataRow[5]);
                }
                if (!(dataRow[5] is uint))
                {
                    order.Worker_ID = Convert.ToUInt32(dataRow[5]);
                }
                return order;
            }
            else
            {
                return null;
            }
        }
    }
    public class Order_Status   
    {
        [DataMember]
        public uint id { get; set; }
        [DataMember]
        public string Type { get; set; }
        [IgnoreDataMember]
        public uint columnCount { get; } = 2;
        [IgnoreDataMember]
        public Tables table { get; } = Tables.Order_Status;
        [IgnoreDataMember]
        public string[] columnNames { get; } = { "id", "Type"};
        [IgnoreDataMember]
        public Type[] types { get; } = { typeof(uint), typeof(string) };
        public Order_Status CastToThisClass(List<object> dataRow)
        {
            if (dataRow.Count <= columnCount)
            {
                Order_Status order = new Order_Status();
                if (!(dataRow[0] is uint))
                {
                    order.id = Convert.ToUInt32(dataRow[0]);
                }
                order.Type = dataRow[1].ToString();

                return order;
            }
            else
            {
                return null;
            }
        }
    }
    public class Worker
    {
        [DataMember]
        public uint id { get; set; }
        [DataMember]
        public uint Role_ID { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [IgnoreDataMember]
        public uint columnCount { get; } = 6;
        [IgnoreDataMember]
        public Tables table { get; } = Tables.Worker;
        [IgnoreDataMember]
        public string[] columnNames { get; } = { "id", "Role_ID", "Login", "Password", "Email", "Phone" };
        [IgnoreDataMember]
        public Type[] types { get; } = { typeof(uint), typeof(uint), typeof(string), typeof(string), typeof(string), typeof(string) };
        public Worker CastToThisClass(List<object> dataRow)
        {
            if (dataRow.Count <= columnCount)
            {
                Worker worker = new Worker();
                if (!(dataRow[0] is uint))
                {
                    worker.id = Convert.ToUInt32(dataRow[0]);
                }
                if (!(dataRow[1] is uint))
                {
                    worker.Role_ID = Convert.ToUInt32(dataRow[1]);
                }
                worker.Login = dataRow[2].ToString();
                worker.Password = dataRow[3].ToString();
                worker.Email = dataRow[4].ToString();
                worker.Phone = dataRow[5].ToString();
                
                return worker;
            }
            else
            {
                return null;
            }
        }
    }
    public class Role
    {
        [DataMember]
        public uint id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [IgnoreDataMember]
        public uint columnCount { get; } = 2;
        [IgnoreDataMember]
        public Tables table { get; } = Tables.Role;
        [IgnoreDataMember]
        public string[] columnNames { get; } = { "id", "Name" };
        [IgnoreDataMember]
        public Type[] types { get; } = { typeof(uint), typeof(string) };
        public Role CastToThisClass(List<object> dataRow)
        {
            if (dataRow.Count <= columnCount)
            {
                Role role = new Role();
                if (!(dataRow[0] is uint))
                {
                    role.id = Convert.ToUInt32(dataRow[0]);
                }
                role.Name = dataRow[1].ToString();

                return role;
            }
            else
            {
                return null;
            }
        }
    }
}
