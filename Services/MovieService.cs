using MovieRateApp.Data;
using MovieRateApp.Models;

namespace MovieRateApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDBcontext _db;

        public MovieService(AppDBcontext db)
        {
            _db = db;
        }

        public Movie Getmovie(string name)
        {
            return _db.Movies.Where(m => m.Title == name).FirstOrDefault();
        }

        public ICollection<Movie> GetMovies()
        {
            return _db.Movies.ToList();
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved >0 ? true : false;
        }

        public bool Createmovie(Movie movie)
        {
            _db.Add(movie);
            return Save();
        }

        public bool Updatemovie(Movie movie)
        {
            _db.Update(movie);
            return Save();
        }

        public bool Deletemovie(Movie movie)
        {
            _db.Remove(movie);
            return Save();
        }
    }
}
