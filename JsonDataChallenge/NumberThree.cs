using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonDataChallenge
{
    public class Inventory
    {
        public int Inventory_id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List <string> Tags { get; set; }
        public int Purchased_at { get; set; }
        public Placement Placement { get; set; }
    }

    public class Placement
    {
        public int Room_id { get; set; }
        public string Name { get; set; }
    }
    
    public static class MethodsThree
    {
        static string json3Path = @"/Users/training/Projects/JsonDataChallenge/JsonDataChallenge/Database/Data3.json";

        public static void ItemsMeetingRoom()
        {
            string savePath = @"/Users/training/Projects/JsonDataChallenge/JsonDataChallenge/Database/Items.json";
            var json = File.ReadAllText(json3Path);
            var jArray = JsonConvert.DeserializeObject<List<Inventory>>(json);
            List<Inventory> result = new List<Inventory>();

            foreach (var i in jArray)
            {
                var x = i.Placement.Name;
                if(x == "Meeting Room")
                {
                    result.Add(i);
                }
            }

            var hasil = JsonConvert.SerializeObject(result);
            File.WriteAllText(savePath, hasil);
        }

        public static void FindElectronics()
        {
            string savePath = @"/Users/training/Projects/JsonDataChallenge/JsonDataChallenge/Database/Electronic.json";
            var json = File.ReadAllText(json3Path);
            var jArray = JsonConvert.DeserializeObject<List<Inventory>>(json);
            List<Inventory> result = new List<Inventory>();

            foreach (var i in jArray)
            {
                var x = i.Type;
                if (x == "electronic")
                {
                    result.Add(i);
                }
            }

            var hasil = JsonConvert.SerializeObject(result);
            File.WriteAllText(savePath, hasil);
        }

        public static void FindFurniture()
        {
            string savePath = @"/Users/training/Projects/JsonDataChallenge/JsonDataChallenge/Database/Furniture.json";
            var json = File.ReadAllText(json3Path);
            var jArray = JsonConvert.DeserializeObject<List<Inventory>>(json);
            List<Inventory> result = new List<Inventory>();

            foreach (var i in jArray)
            {
                var x = i.Tags;
                if (x.Contains("furniture"))
                {
                    result.Add(i);
                }
            }

            var hasil = JsonConvert.SerializeObject(result);
            File.WriteAllText(savePath, hasil);
        }

        //public static void PurchasedAt()
        //{
        //    string savePath = @"/Users/training/Projects/JsonDataChallenge/JsonDataChallenge/Database/Furniture.json";
        //    var json = File.ReadAllText(json3Path);
        //    var jArray = JsonConvert.DeserializeObject<List<Inventory>>(json);
        //    List<Inventory> result = new List<Inventory>();

        //    foreach (var i in jArray)
        //    {
        //        var x = i.Purchased_at.TryFormat()
        //        if (x.Day == 16 && x.Month == 01 && x.Year == 2020)
        //        {
        //            result.Add(i);
        //        }
        //    }

        //    var hasil = JsonConvert.SerializeObject(result);
        //    File.WriteAllText(savePath, hasil);
        //}

        public static void AllBrown()
        {
            string savePath = @"/Users/training/Projects/JsonDataChallenge/JsonDataChallenge/Database/all-browns.json";
            var json = File.ReadAllText(json3Path);
            var jArray = JsonConvert.DeserializeObject<List<Inventory>>(json);
            List<Inventory> result = new List<Inventory>();

            foreach (var i in jArray)
            {
                var x = i.Tags;
                if (x.Contains("brown"))
                {
                    result.Add(i);
                }
            }

            var hasil = JsonConvert.SerializeObject(result);
            File.WriteAllText(savePath, hasil);
        }
    }

}