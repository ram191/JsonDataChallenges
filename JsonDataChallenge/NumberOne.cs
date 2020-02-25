using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace JsonDataChallenge
{
    //The Classes
    public class UserArticles
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public Profile Profile { get; set; }
        public List<Articles> Articles { get; set; }
    }

    public class Profile
    {
        public string Full_name { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> Phones { get; set; }
    }

    public class Articles
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Published_at { get; set; }
    }

    public class Database
    {
        protected static string json1Path = @"/Users/training/Projects/JsonDataChallenge/JsonDataChallenge/Database/Data1.json";
        protected static string json = File.ReadAllText(json1Path);
        protected static List<UserArticles> jArray = JsonConvert.DeserializeObject<List<UserArticles>>(json);
    }

    //Methods
    public class Methods : Database
    {

        public static IEnumerable<string> NoPhone()
        {
            return jArray.Where(x => !x.Profile.Phones.Any()).Select(x => x.Profile.Full_name);
        }

        public static IEnumerable<string> HasArticles()
        {
            return jArray.Where(x => !x.Articles.Any()).Select(x => x.Profile.Full_name);
        }

        public static IEnumerable<string> HasAnnis()
        {
            return jArray.Where(x => x.Profile.Full_name.ToLower().Contains("annis")).Select(x => x.Profile.Full_name);
        }

        public static IEnumerable<string> Has2020()
        {
            return jArray.Where(x => x.Articles.Any(y => y.Published_at.ToLocalTime().Year == 2020)).Select(x => x.Profile.Full_name);
        }

        public static IEnumerable<string> BornIn1986()
        {
            return jArray.Where(x => x.Profile.Birthday.ToLocalTime().Year == 1986).Select(x => x.Profile.Full_name);
        }

        public static IEnumerable<string> ContainTips()
        {
            return jArray.SelectMany(x => x.Articles.Where(x => x.Title.ToLower().Contains("tips")).Select(x => x.Title));
        }

        public static IEnumerable<string> BeforeAugust2019()
        {
            return jArray.SelectMany(x => x.Articles.Where(x => x.Published_at.ToLocalTime().Year < 2020)
            .Where(x => x.Published_at.ToLocalTime().Month < 08).Select(x => x.Title));
        }
    }
}
