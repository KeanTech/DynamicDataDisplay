using System;
using System.Collections;
using System.Collections.Generic;

namespace ComponentShowCase.Containers
{
    public class DynamicTypeContainer<T>
    {
        private List<T> _data;
        public List<T> Data { get => _data; set => _data = value; }

        /// <summary>
        /// Initialize a new Data List  
        /// </summary>
        public DynamicTypeContainer()
        {
            _data = new();
        }

        /// <summary>
        /// Returns a list of strings 
        /// List of all property names
        /// </summary>
        /// <returns></returns>
        public List<object> GetTypeProperties()
        {
            var props = typeof(T).GetProperties();
            List<object> propertyNames = new();
            foreach (var item in props)
            {
                propertyNames.Add(item.Name);
            }

            return propertyNames;
        }

        /// <summary>
        /// Checks the object to see if its a list
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool IsList(object o)
        {
            if (o == null) return false;
            return o is IList &&
                   o.GetType().IsGenericType &&
                   o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        }

        /// <summary>
        /// dataIndex selects the the object in the Data List
        /// it also needs the property name
        /// Use the GetTypeProperties to get property names
        /// </summary>
        /// <param name="dataIndex"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public object GetPropertyValue(int dataIndex, string propertyName)
        {
            // Gets the property value
            object objectValues = Data[dataIndex].GetType().GetProperty(propertyName).GetValue(Data[dataIndex]);
            // returns the value
            return objectValues;
        }

        /// <summary>
        /// Adds a new T element to the Data List
        /// </summary>
        /// <param name="obj"></param>
        public void AddToList(T obj)
        {
            _data.Add(obj);
        }

        /// <summary>
        /// Removes the given object from the Data List
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="ArgumentException"></exception>
        public void RemoveElement(T obj)
        {
            if (_data.Contains(obj))
            {
                _data.Remove(obj);
                return;
            }
            throw new ArgumentException("Nothing to remove");
        }
    }
}
