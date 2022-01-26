using System;
using System.Collections.Generic;
using System.Reflection;

namespace DynamicDisplay.Models
{
    public class DynamicDisplayModel<T>
    {
        private List<T> _data;
        public List<T> Data { get => _data; set => _data = value; }

        public DynamicDisplayModel()
        { 
            _data = new();
        }

        public List<string> GetTypeProperties() 
        {
            var props = typeof(T).GetProperties();
            List<string> propertyNames = new();
            foreach (var item in props)
            {
                propertyNames.Add(item.Name);
            }

            return propertyNames;
        }

        public void AddToList(T obj) 
        { 
            _data.Add(obj);
        }

        public void RemoveElement(T obj) 
        {
            if (_data.Contains(obj))
            {
                _data.Remove(obj);
            }
            throw new ArgumentException("Nothing to remove");
        }
    }
}
