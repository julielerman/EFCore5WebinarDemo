using System;
namespace EFCore5.Domain
{
    public class WildlifeSighting
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; }
    public int AddressId { get; set; }
  }

}