using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonDataChallenge
{
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

    public class MethodsTwo
    {
        static string json2Path = @"/Users/training/Projects/JsonDataChallenge/JsonDataChallenge/Database/Data2.json";

        public static string FebPurchases()
        {
            var json = File.ReadAllText(json2Path);
            var jArray = JsonConvert.DeserializeObject<List<Order>>(json);
            List<string> result = new List<string>();

            foreach (var i in jArray)
            {
                var x = i.Created_at.ToLocalTime();
                if (x.Month == 02)
                {
                    result.Add(i.Order_id);
                }
            }
            return String.Join(',', result);
        }

        public static int AriBoros()
        {
            var json = File.ReadAllText(json2Path);
            var jArray = JsonConvert.DeserializeObject<List<Order>>(json);
            List<int> result = new List<int>();

            foreach (var i in jArray)
            {
                if (i.Customer.Name == "Ari")
                {
                    foreach (var y in i.Items)
                    {
                        {
                            result.Add(y.Price * y.Qty);
                        }
                    }
                }

            }
            var result2 = result.Sum();
            return result2;
        }

        //LONG ANSWER

        //public static string Irit()
        //{
        //    var json = File.ReadAllText(json2Path);
        //    var jArray = JsonConvert.DeserializeObject<List<Order>>(json);
        //    List<int> ari = new List<int>();
        //    List<int> ririn = new List<int>();
        //    List<int> annis = new List<int>();

        //    foreach (var i in jArray)
        //    {
        //        if (i.Customer.Name == "Ari")
        //        {
        //            foreach (var y in i.Items)
        //            {
        //                {
        //                    ari.Add(y.Price * y.Qty);
        //                }
        //            }
        //        }
        //    }

        //    foreach (var i in jArray)
        //    {
        //        if (i.Customer.Name == "Ririn")
        //        {
        //            foreach (var y in i.Items)
        //            {
        //                {
        //                    ririn.Add(y.Price * y.Qty);
        //                }
        //            }
        //        }
        //    }

        //    foreach (var i in jArray)
        //    {
        //        if (i.Customer.Name == "Annis")
        //        {
        //            foreach (var y in i.Items)
        //            {
        //                {
        //                    annis.Add(y.Price * y.Qty);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
