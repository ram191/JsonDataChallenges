using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace JsonDataChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Number1
            //Console.WriteLine(Methods.HasArticles());
            //Console.WriteLine(Methods.HasAnnis());
            //Console.WriteLine(Methods.BornIn1986());
            //Console.WriteLine(Methods.Has2020());
            //Console.WriteLine(Methods.ContainTips());
            //Console.WriteLine(Methods.BeforeAugust2019());

            ////Number2
            //Console.WriteLine(MethodsTwo.FebPurchases());
            //Console.WriteLine(MethodsTwo.AriBoros());
            //Comsole.WriteLine(MethodsTwo.Irit());

            //Number3
            //MethodsThree.ItemsMeetingRoom();
            //MethodsThree.FindElectronics();
            //MethodsThree.FindFurniture();
            //MethodsThree.PurchasedAt();
            //MethodsThree.AllBrown();

        }
    }

    public class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public void Introduction()
        {
            Console.WriteLine($"{Name} is {Age} years old. He lives in {Address}");
        }

        public Human(string name, int age, string address)
        {
            this.Name = name;
            this.Age = age;
            this.Address = address;
        }
    }
}
