using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace JsonDataChallenge
{
    public class NumberOne
    {
        public NumberOne()
        {
        }
    }

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

    public class Methods
    {
        static string json1Path = @"/Users/training/Projects/JsonDataChallenge/JsonDataChallenge/Database/Data1.json";


        public static string NoPhone()
        {
            var json = File.ReadAllText(json1Path);
            var jArray = JsonConvert.DeserializeObject<List<UserArticles>>(json);
            List<string> result = new List<string>();

            foreach (var i in jArray)
            {
                if (i.Profile.Phones.Count == 0)
                {
                    result.Add(i.Profile.Full_name);
                }
            }
            return String.Join(',', result);
        }

        public static string HasArticles()
        {
            var json = File.ReadAllText(json1Path);
            var jArray = JsonConvert.DeserializeObject<List<UserArticles>>(json);
            List<string> result = new List<string>();

            foreach (var i in jArray)
            {
                foreach (var y in i.Articles)
                {
                    if (y.Id != 0)
                    {
                        result.Add(i.Profile.Full_name);
                    }
                }
            }
            return String.Join(',', result);
        }

        public static string HasAnnis()
        {
            var json = File.ReadAllText(json1Path);
            var jArray = JsonConvert.DeserializeObject<List<UserArticles>>(json);
            List<string> result = new List<string>();

            foreach (var i in jArray)
            {
                var x = i.Profile.Full_name.ToLower();
                if (x.Contains("annis"))
                {
                    result.Add(i.Profile.Full_name);
                }
            }
            return String.Join(',', result);
        }

        public static string Has2020()
        {
            var json = File.ReadAllText(json1Path);
            var jArray = JsonConvert.DeserializeObject<List<UserArticles>>(json);
            List<string> result = new List<string>();

            foreach (var i in jArray)
            {
                foreach (var y in i.Articles)
                {
                    {
                        var x = y.Published_at.ToLocalTime();
                        if (x.Year == 2020)
                        {
                            result.Add(i.Profile.Full_name);
                        }
                    }
                }
            }
            var result2 = result.Distinct();
            return String.Join(',', result2);
        }

        public static string BornIn1986()
        {
            var json = File.ReadAllText(json1Path);
            var jArray = JsonConvert.DeserializeObject<List<UserArticles>>(json);
            List<string> result = new List<string>();

            foreach (var i in jArray)
            {
                var y = i.Profile.Birthday.ToLocalTime();
                if (y.Year == 1986)
                {
                    result.Add(i.Profile.Full_name);
                }
            }
            return String.Join(',', result);
        }

        public static string ContainTips()
        {
            var json = File.ReadAllText(json1Path);
            var jArray = JsonConvert.DeserializeObject<List<UserArticles>>(json);
            List<string> result = new List<string>();

            foreach (var i in jArray)
            {
                foreach (var y in i.Articles)
                {
                    {
                        var x = y.Title.ToLower();
                        if (x.Contains("tips"))
                        {
                            result.Add(y.Title);
                        }
                    }
                }
            }
            var result2 = result.Distinct();
            return String.Join(',', result2);
        }

        public static string BeforeAugust2019()
        {
            var json = File.ReadAllText(json1Path);
            var jArray = JsonConvert.DeserializeObject<List<UserArticles>>(json);
            List<string> result = new List<string>();

            foreach (var i in jArray)
            {
                foreach (var y in i.Articles)
                {
                    {
                        var x = y.Published_at.ToLocalTime();
                        if (x.Year < 2020 && x.Month < 08)
                        {
                            result.Add(y.Title);
                        }
                    }
                }
            }
            var result2 = result.Distinct();
            return String.Join(',', result2);
        }

    }

}
