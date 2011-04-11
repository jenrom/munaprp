using System;
using System.Collections.Generic;

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
            foreach (var movie in movies)
                yield return movie;
        }


        public void add(Movie movie)
        {
            foreach (var movieInList in movies) 
                if (movieInList.title == movie.title)
                    return;

            movies.Add(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return Find(m => m.production_studio == ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return
                Find(
                    m => m.production_studio == ProductionStudio.Pixar || m.production_studio == ProductionStudio.Disney);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return Find(m => m.production_studio != ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return Find(m => m.date_published.Year > year);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            return Find(m => m.date_published.Year >= startingYear && m.date_published.Year <= endingYear);
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return Find(m => m.genre == Genre.kids);
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return Find(m => m.genre == Genre.action);
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
            Movie[] sorted = new Movie[movies.Count];
            movies.CopyTo(sorted, 0);
            Array.Sort(sorted, comparer);
            return sorted;
        }

        IEnumerable<Movie> Find(Func<Movie,bool> pred)
        {
            foreach (var movie in movies)
                if (pred(movie))
                    yield return movie;
        }
    }
}