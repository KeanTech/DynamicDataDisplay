using System.Collections.Generic;

namespace ComponentShowCase.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public float Price { get; set; }

        public List<object> Features { get; set; }
    }
}
