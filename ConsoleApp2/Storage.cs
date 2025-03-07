namespace ConsoleApp2
{
    public class Storage
    {
        private int _genreSize = 0;
        private List<Movie> _movie = new List<Movie>();
        private List<Genre> _genre = new List<Genre>();
        private List<Watchlist> _watchlist = new List<Watchlist>();
        public void PrintMovie()
        {
            Console.WriteLine(new string('-', 60)); 
            Console.WriteLine($"{"Name".PadRight(20)}{"Genre".PadRight(10)}{"Views"}");
            Console.WriteLine(new string('-', 60)); 

            foreach (var movie in _movie)
            {
                Console.WriteLine($"{movie.Name,(-20)} {movie.Genre,(-10)}{movie.Views,10}");
                Console.WriteLine(new string('-', 40)); 
            }
        }
        public void AddMovie()
        {
            Console.WriteLine("Enter Film name:");
            string name = Console.ReadLine();
            Movie newMovie = new Movie(name);
            _movie.Add(newMovie);
            Console.WriteLine("Movie added successfully!");
        }



        public void AddGenre()
        {
            Console.WriteLine("Enter Genre name:");
            string genreName = Console.ReadLine();
            Genre newGenre = new Genre(genreName);
            _genre.Add(newGenre);
            _genreSize++;
            Console.WriteLine("Genre added successfully!");
        }

        public void RemoveMovie()
        {
            Console.WriteLine("Enter Movie Id:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id format.");
                return;
            }

            for (int i = 0; i < _movie.Count; i++)
            {
                if (_movie[i].Id == id)
                {
                    for (int j = i; j < _movie.Count - 1; j++)
                    {
                        _movie[j] = _movie[j + 1];
                    }

                    _movie.RemoveAt(_movie.Count - 1);
                    Console.WriteLine("Movie removed successfully.");
                    return;
                }
                Console.WriteLine("Movie not found.");
            }
        }
        public void RemoveGenre()
        {
            Console.WriteLine("Enter Genre Id:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id format.");
                return;
            }

            for (int i = 0; i < _genre.Count; i++)
            {
                if (_genre[i].Id == id)
                {
                    for (int j = i; j < _genre.Count - 1; j++)
                    {
                        _genre[j] = _genre[j + 1];
                    }

                    _genre.RemoveAt(_genre.Count - 1);
                    Console.WriteLine("Genre removed successfully.");
                    return;
                }
            }
            Console.WriteLine("Genre not found.");
        }
        public void MostView()
        {
            if (_movie.Count > 0)
            {
                Movie mostViewedMovie = _movie[0];
                for (int i = 1; i < _movie.Count; i++)
                {
                    if (_movie[i].Views > mostViewedMovie.Views)
                    {
                        mostViewedMovie = _movie[i];
                    }
                }
                Console.WriteLine($"Most viewed movie is: {mostViewedMovie.Name}, Genre: {mostViewedMovie.Genre}, Views: {mostViewedMovie.Views}");
            }
            else
            {
                Console.WriteLine("No movies available.");
            }
        }

            public void AddToWatchlist()
            {
                Console.WriteLine("Enter Movie Id to add to watchlist:");
                if (!int.TryParse(Console.ReadLine(), out int movieId))
                {
                    Console.WriteLine("Invalid Id format.");
                    return;
                }

                Movie movieToAdd = null;
                for (int i = 0; i < _movie.Count; i++)
                {
                    if (_movie[i].Id == movieId)
                    {
                        movieToAdd = _movie[i];
                        break; 
                    }
                }

                if (movieToAdd != null)
                {
                    bool alreadyInWatchlist = false;
                    for (int i = 0; i < _watchlist.Count; i++)
                    {
                        if (_watchlist[i].Id == movieId)
                        {
                            alreadyInWatchlist = true;
                            break;
                        }
                    }

                    if (!alreadyInWatchlist)
                    {
                    _watchlist.Add(new Watchlist(movieToAdd));
                    Console.WriteLine($"Movie '{movieToAdd.Name}' added to watchlist.");
                    }
                    else
                    {
                        Console.WriteLine($"Movie '{movieToAdd.Name}' is already in the watchlist.");
                    }
                }
                else
                {
                    Console.WriteLine("Movie not found.");
                }
            }

        }
    }
