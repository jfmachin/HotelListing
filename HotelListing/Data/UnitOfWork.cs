using HotelListing.Models.Entities;

namespace HotelListing.Data {
    public class UnitOfWork : IUnitOfWork {
        private readonly AppDbContext context;
        private IRepository<Hotel> hotels;
        private IRepository<Country> countries;

        public IRepository<Country> CountryRepository => countries ??= new GenericRepository<Country>(context);
        public IRepository<Hotel> HotelRepository => hotels ??= new GenericRepository<Hotel>(context);

        public UnitOfWork(AppDbContext context) {
            this.context = context;
        }

        public void Dispose() {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task save() {
            await context.SaveChangesAsync();
        }
    }
}
