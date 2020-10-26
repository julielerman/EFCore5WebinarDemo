using System.Collections.Generic;
namespace EFCore5.Domain
{
    public class Address
  {
   
    public int Id { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public List<Person> Residents { get;  } = new List<Person>();
    public List<WildlifeSighting> WildlifeSightings { get; } = new List<WildlifeSighting>();
  }

}