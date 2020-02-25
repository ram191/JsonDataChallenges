using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace JsonDataChallenge
{
    //The Classes
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

    public class DatabaseThree
    {
        protected static string jsonPath = @"/Users/training/Projects/JsonDataChallenge/JsonDataChallenge/Database/Data3.json";
        protected static string json = File.ReadAllText(jsonPath);
        protected static List<Inventory> jArray = JsonConvert.DeserializeObject<List<Inventory>>(json);
    }

    //Methods
    public class MethodsThree : DatabaseThree
    {
        public static void ItemsMeetingRoom()
        {
            string savePath = @"/Users/training/Projects/JsonDataChallenge/JsonDataChallenge/Database/Items.json";
            var result = jArray.Where(x => x.Placement.Name.ToLower().Contains("meeting room"));
            var hasil = JsonConvert.SerializeObject(result);
            File.WriteAllText(savePath, hasil);
        }

        public static void FindElectronics()
        {
            string savePath = @"/Users/training/Projects/JsonDataChallenge/JsonDataChallenge/Database/Electronic.json";
            var result = jArray.Where(x => x.Type.ToLower().Contains("electronic"));
            var hasil = JsonConvert.SerializeObject(result);
            File.WriteAllText(savePath, hasil);
        }

        public static void FindFurniture()
        {
            string savePath = @"/Users/training/Projects/JsonDataChallenge/JsonDataChallenge/Database/Furniture.json";
            var result = jArray.Where(x => x.Tags.Contains("furniture"));
            var hasil = JsonConvert.SerializeObject(result);
            File.WriteAllText(savePath, hasil);
        }

        public static void PurchasedAt()
        {
            string savePath = @"/Users/training/Projects/JsonDataChallenge/JsonDataChallenge/Database/purchased-at-2020-01-16.json.json";
            var result = jArray
                .Where(x => new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(x.Purchased_at).Day == 16 &&
            new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(x.Purchased_at).Month == 01 &&
            new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(x.Purchased_at).Year == 2020);
            var hasil = JsonConvert.SerializeObject(result);
            File.WriteAllText(savePath, hasil);
        }

        public static void AllBrown()
        {
            string savePath = @"/Users/training/Projects/JsonDataChallenge/JsonDataChallenge/Database/all-browns.json";
            var result = jArray.Where(x => x.Tags.Contains("brown"));
            var hasil = JsonConvert.SerializeObject(result);
            File.WriteAllText(savePath, hasil);
        }
    }

}