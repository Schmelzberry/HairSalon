namespace HairSalon.Models
{
    public class Client 
    { 
      public string Name { get; set; }
      public int ClientId { get; set; }
      public string HairLength { get; set; }

      // foreign key relating to Stylist table
      // public int StylistId { get; set; }

      // Reference Navigation Property - establish 1-many relationship
      // public Stylist Stylist { get; set; }

    }
}
