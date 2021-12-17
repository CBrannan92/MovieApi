using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public long AverageWatchDurationS { get; set; }
        public int watches { get; set; }
        public int ReleaseYear { get; set; }
    }
}
