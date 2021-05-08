using MovieGram.Data.Interfaces;

namespace MovieGram.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private MovieContext _context { get; }
        public IMovieRepository Movies { get; set; }

        public UnitOfWork(MovieContext context)
        {
            _context = context;
            Movies = new MovieRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
