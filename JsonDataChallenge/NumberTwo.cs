using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace JsonDataChallenge
{
    //The Classes
    public class Order
    {
        public string Order_id { get; set; }
        public DateTime Created_at { get; set; }
        public Customer Customer { get; set; }
        public List<Items> Items { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
    }

    public class DatabaseTwo
    {
        protected static string json2Path = @"/Users/training/Projects/JsonDataChallenge/JsonDataChallenge/Database/Data2.json";
        protected static string json = File.ReadAllText(json2Path);
        protected static List<Order> jArray = JsonConvert.DeserializeObject<List<Order>>(json);
    }

    //Methods
    public class MethodsTwo : DatabaseTwo
    {
        public static IEnumerable<Order> FebPurchases()
        {
            return jArray.Where(x => x.Created_at.ToLocalTime().Month == 02);
        }

        public static int AriBoros()
        {
            return jArray.Where(x => x.Customer.Name.ToLower() == "ari")
                .Sum(x => x.Items.Sum(x => x.Price * x.Qty));
        }

        public static IEnumerable<string> Irit()
        {
            return jArray
                .GroupBy(x => x.Customer.Name,
                x => x.Items.Sum(x => x.Price * x.Qty),
                (name, total) => new
                    { Key = name, Total = total.Sum() })
                .Where(x => x.Total < 300000)
                .Select(x => x.Key);
        }
    }
}
