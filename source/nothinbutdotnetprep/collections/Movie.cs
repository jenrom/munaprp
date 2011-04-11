using System;
using nothinbutdotnetprep.infrastructure;

namespace nothinbutdotnetprep.collections
{
    public class Movie
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public override string ToString()
        {
            return title + ": " + date_published;
        }

        public static Condition<Movie> is_in_genre(Genre genre)
        {
            return new IsInGenre(genre).matches;
        }

        public static Criteria<Movie> is_not_published_by_pixar
        {
            get { return is_published_by(ProductionStudio.Pixar); }
        }

        public static Criteria<Movie> is_published_by(ProductionStudio studio)
        {
            return new IsPublishedBy(studio);
        }

        public static Criteria<Movie> is_published_by_pixar_or_disney
        {
            get
            {
                return is_published_by(ProductionStudio.Pixar)
                    .or(is_published_by(ProductionStudio.Disney));
            }
        }

        public static Criteria<Movie> is_published_by_pixar
        {
            get { return is_published_by(ProductionStudio.Pixar);}
        }
    }
}