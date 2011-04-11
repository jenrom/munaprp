using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        readonly IList<Movie> movies;

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
            this.movies.Add(movie);
        }

        bool already_contains(Movie movie)
        {
            return this.movies.Contains(movie);
        }

        static int CompareMoviesByTitleDescending(Movie x, Movie y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            return y.title.CompareTo(x.title);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (var m in this.movies)
            {
                if (m.production_studio == ProductionStudio.Pixar ||
                    m.production_studio == ProductionStudio.Disney)
                {
                    yield return m;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            foreach (var m in this.movies)
            {
                if (m.production_studio == ProductionStudio.Pixar)
                {
                    yield return m;
                }
            }
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            foreach (var m in this.movies)
            {
                if (m.production_studio != ProductionStudio.Pixar)
                {
                    yield return m;
                }
            }
        }

        static int CompareMoviesByTitleAscending(Movie x, Movie y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            return x.title.CompareTo(y.title);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                var res = new List<Movie>(movies);
                res.Sort(CompareMoviesByTitleDescending);
                return res;
            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            var startDateTime = new DateTime(startingYear, 1, 1);
            var endDateTime = new DateTime(endingYear, 12, 31);

            foreach (var m in this.movies)
            {
                if (m.date_published >= startDateTime && m.date_published <= endDateTime)
                {
                    yield return m;
                }
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get
            {
                var res = new List<Movie>(movies);
                res.Sort(CompareMoviesByTitleAscending);
                return res;
            }
        }

        static int CompareMoviesByMovieStudioRatingAndYearPublished(Movie x, Movie y)
        {
            var studios = new List<ProductionStudio>
            {
                ProductionStudio.MGM,
                ProductionStudio.Pixar,
                ProductionStudio.Dreamworks,
                ProductionStudio.Universal,
                ProductionStudio.Disney,
                ProductionStudio.Paramount
            };

            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            if (studios.IndexOf(x.production_studio) < studios.IndexOf(y.production_studio))
                return -1;
            if (studios.IndexOf(x.production_studio) > studios.IndexOf(y.production_studio))
                return 1;
            if (x.date_published < y.date_published)
                return -1;
            if (x.date_published > y.date_published)
                return 1;
            return 0;
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            var res = new List<Movie>(movies);
            res.Sort(CompareMoviesByMovieStudioRatingAndYearPublished);
            return res;
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            var dateTime = new DateTime(year, 12, 31);

            foreach (var m in this.movies)
            {
                if (m.date_published > dateTime)
                {
                    yield return m;
                }
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            foreach (var m in this.movies)
            {
                if (m.genre == Genre.kids)
                {
                    yield return m;
                }
            }
        }

        public IEnumerable<Movie> all_action_movies()
        {
            foreach (var m in this.movies)
            {
                if (m.genre == Genre.action)
                {
                    yield return m;
                }
            }
        }

        static int CompareMoviesByDatePublishedDescending(Movie x, Movie y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            if (x.date_published < y.date_published)
                return 1;
            if (x.date_published > y.date_published)
                return -1;
            return 0;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            var res = new List<Movie>(movies);
            res.Sort(CompareMoviesByDatePublishedDescending);
            return res;
        }

        static int CompareMoviesByDatePublishedAscending(Movie x, Movie y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            if (x.date_published < y.date_published)
                return -1;
            if (x.date_published > y.date_published)
                return 1;
            return 0;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            var res = new List<Movie>(movies);
            res.Sort(CompareMoviesByDatePublishedAscending);
            return res;
        }
    }
}