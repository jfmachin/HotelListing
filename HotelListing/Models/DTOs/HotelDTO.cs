using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models.DTOs {
    public class HotelDTO: HotelDTOCreate {
        public int id { get; set; }
        public CountryDTO country { get; set; }
    }
    
    public class HotelDTOCreate {
        [Required, StringLength(maximumLength: 150)]
        public string name { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string address { get; set; }

        [Required, Range(1, 5)]
        public double rating { get; set; }

        [Required]
        public int countryId { get; set; }
    }
}
