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
        public List<Placement> Placement { get; set; }
    }

    public class Placement
    {
        public int Room_id { get; set; }
        public string Name { get; set; }
    }
    
    public class MethodsThree
    {
        static string json2Path = @"D:\Programming\Refactory\JsonDataChallenges\JsonDataChallenge\Database\Data3.json";

        public static string ItemsMeetingRoom()
        {
            var json = File.ReadAllText(json3Path);
            var jArray = JsonConvert.DeserializeObject<List<Inventory>>(json);
            List<string> result = new List<string>();

            foreach (var i in jArray)
            {
                var x = i.Placement.Name;
                if (x == "Meeting Room")
                {
                    result.Add(i);
                }
            }
            // Add return and save file
            return result;
        }

        public static FindElectronics()
        {
            var json = File.ReadAllText(json3Path);
            var jArray = JsonConvert.DeserializeObject<List<Inventory>>(json);
            List<string> result = new List<string>();

            foreach (var i in jArray)
            {
                var x = i.Type;
                if (x == "electronic")
                {
                    result.Add(i);
                }
            }
            // Add return and save file
            return result;
        }

        public static FindFurniture()
        {
            var json = File.ReadAllText(json3Path);
            var jArray = JsonConvert.DeserializeObject<List<Inventory>>(json);
            List<string> result = new List<string>();

            foreach (var i in jArray)
            {
                var x = i.Tags;
                if (x.Contains("furniture"))
                {
                    result.Add(i);
                }
            }
            // Add return and save file
            return result;
        }

        public static PurchasedAt()
        {
            var json = File.ReadAllText(json3Path);
            var jArray = JsonConvert.DeserializeObject<List<Inventory>>(json);
            List<string> result = new List<string>();

            foreach (var i in jArray)
            {
                var x = i.PurchasedAt.ToLocalTime();
                if (x.Day == 16 && x.Month == 01 && x.Year == 2020)
                {
                    result.Add(i);
                }
            }
            // Add return and save file
            return result;
        }

        public static AllBrown()
        {
            var json = File.ReadAllText(json3Path);
            var jArray = JsonConvert.DeserializeObject<List<Inventory>>(json);
            List<string> result = new List<string>();

            foreach (var i in jArray)
            {
                var x = i.Tags;
                if (x.Contains("brown"))
                {
                    result.Add(i);
                }
            }
            // Add return and save file
            return result;
        }
    }

}