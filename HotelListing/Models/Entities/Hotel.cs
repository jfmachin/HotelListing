using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Models.Entities {
    public class Hotel {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public double rating { get; set; }
        
        [ForeignKey(nameof(Country))]
        public int countryId { get; set; }
        public Country country { get; set; }
    }
}
