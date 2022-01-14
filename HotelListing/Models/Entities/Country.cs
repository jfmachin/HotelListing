namespace HotelListing.Models.Entities {
    public class Country {
        public int id { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public virtual IList<Hotel> hotels { get; set; }
    }
}
