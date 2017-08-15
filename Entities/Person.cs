using Entities.Interfaces;

namespace Entities
{
    public class Person
    {
        public string Name { get; set; }
        public IAddress Address { get; set; }
    }
}