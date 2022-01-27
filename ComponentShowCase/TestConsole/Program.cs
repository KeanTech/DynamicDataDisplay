using ComponentShowCase.Containers;
using ComponentShowCase.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DynamicTypeContainer<Car> typeContainer = new();

            typeContainer = new();
            typeContainer.Data = new()
            {
                new Car()
                {
                    Id = 1,
                    Model = "BMW",
                    Price = 800000
                },
                new Car()
                {
                    Id = 1,
                    Model = "Audi",
                    Price = 955600
                }
            };

            var properties = typeContainer.GetTypeProperties();
            
            for (int i = 0; i < typeContainer.Data.Count; i++)
            {

                foreach (var item in typeContainer.GetTypeProperties())
                {

                    var value = typeContainer.GetPropertyValue(i, item);
                    var type = value.GetType().Name;
                    var assembly = value.GetType().BaseType;
                    if(typeContainer.IsList(value))
                    {
                        foreach (var listObj in ((List<object>)value))
                        {
                            Console.WriteLine(listObj);
                        }
                    }
                    Console.WriteLine(value);
                }

            }


       
        }
    }
}
