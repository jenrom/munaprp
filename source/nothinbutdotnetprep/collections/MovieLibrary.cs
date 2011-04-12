using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            movies.Add(movie);
        }

        bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            return Sorted((x, y) => y.date_published.CompareTo(x.date_published));
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            return Sorted((x, y) => x.date_published.CompareTo(y.date_published));
        }

        IEnumerable<Movie> Sorted(Comparison<Movie> comparer)
        {
            var sorted = new Movie[movies.Count];
            movies.CopyTo(sorted, 0);
            Array.Sort(sorted, comparer);
            return sorted;
        }
    }
}