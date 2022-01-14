using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models.DTOs {
    public class CountryDTO: CountryDTOCreate {
        public int id { get; set; }
        public IList<HotelDTO> hotels { get; set; }
    }

    public class CountryDTOCreate {
        [Required]
        [StringLength(maximumLength: 50)]
        public string name { get; set; }
        [Required]
        [StringLength(maximumLength: 2)]
        public string shortName { get; set; }
    }
}