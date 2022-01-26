using DynamicDisplay.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DynamicDisplay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Ben", 1);
            DynamicDisplayModel<Person> dynamicDisplayModel = new DynamicDisplayModel<Person>();

            PropertyInfo[] propertyInfo = dynamicDisplayModel.GetTypeProperties();

            foreach (var item in propertyInfo)
            {
                Console.WriteLine(item.Name);
            }

        }
    }
}
