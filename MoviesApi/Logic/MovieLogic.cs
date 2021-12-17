using MoviesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Logic
{
    public class MovieLogic
    {
        private DbContext DbContext { get; }
        public MovieLogic(DbContext context)
        {
            this.DbContext = context;
        }

        public async Task<List<Metadata>> GetByMovieId(int movieId)
        {
            return DbContext.metaData.Where(x => x.MovieId == movieId)
                                           .GroupBy(x => x.Language)
                                           .Select(g => g.OrderByDescending(x => x.Id).First()).ToList();

        }

        public async Task<List<Movie>> GetAllStats()
        {
            List<Metadata> metadatas = DbContext.metaData.GroupBy(m => m.MovieId)
                   .Select(grp => grp.First())
                   .ToList();

            List<Stat> stats = DbContext.statData.GroupBy(x => x.MovieId)
                                                 .Select(x => new Stat() { MovieId = x.Key, WatchDurationMs = x.Sum(s => s.WatchDurationMs) })
                                                 .ToList();

            List<Movie> movieStats = new List<Movie>();

            foreach (Metadata movie in metadatas)
            {
               Movie newMovie = new Movie
                {
                    MovieId = movie.MovieId,
                    Title = movie.Title,
                    AverageWatchDurationS = stats.FirstOrDefault(x => x.MovieId == movie.MovieId).WatchDurationMs / 1000,
                    watches = DbContext.statData.Count(x => x.MovieId == movie.MovieId),
                    ReleaseYear = movie.ReleaseYear
                };

                movieStats.Add(newMovie);
            }

            return movieStats;
        }

        public async Task CreateMovie(Metadata newRecord)
        {
            List<Metadata> allMovies = DbContext.metaData;

            allMovies.Add(newRecord);
        }
    }
}
