public class Movie
{
    public int Id { get; }
    public string Name { get; }
    public Genre Genre { get; set; } 
    public int Views { get; set; }

    public Movie(string name)
    {
        Id = NextMovieId++; 
        Name = name;
    }

    private static int NextMovieId = 1; 
}

public class Watchlist
{
    public int Id { get; }
    public Movie Movie { get; set; }
    public Watchlist(Movie movie)
    {
        Movie = movie;
    }
}

public class Genre
{
    public int Id { get; }
    public string Name { get; }
 

    public Genre(string name)
    {
        Id = NextGenreId++; 
        Name = name;
    }

    private static int NextGenreId = 1; 
}