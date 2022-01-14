using HotelListing.Models.Entities;

namespace HotelListing.Data {
    public interface IUnitOfWork: IDisposable {
        IRepository<Country> CountryRepository { get; }
        IRepository<Hotel> HotelRepository { get; }
        Task save();
    }
}
