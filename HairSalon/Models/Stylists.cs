using System.Collections.Generic;

namespace HairSalon.Models
{
    public class Stylist
    {   
        
        public int StylistsId { get; set; }
        public string Name { get; set; }
        public int HoursPerWeek { get; set; }
        
        public List<Client> Clients { get; set; }
    }
}
