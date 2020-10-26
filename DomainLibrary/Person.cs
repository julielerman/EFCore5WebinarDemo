using System.Collections.Generic;
namespace EFCore5.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Address> Addresses { get; } = new List<Address>();
    }

}