using System;
namespace EFCore5.Domain
{
    public class Resident
  {
    public int PersonId { get; set; }
    public int AddressId { get; set; }
    public DateTime MovedInDate { get; private set; }
  }

}