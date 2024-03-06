using MovieRateApp.Models;

namespace MovieRateApp.Services
{
    public interface IMovieService
    {
        public ICollection<Movie> GetMovies ();
        public Movie Getmovie (string name);
        public bool Createmovie (Movie movie);
        public bool Save();
        public bool Updatemovie (Movie movie);
        public bool Deletemovie (Movie movie);
    }
}
