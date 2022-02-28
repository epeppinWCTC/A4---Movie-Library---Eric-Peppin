using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace A4___Movie_Library___Eric_Peppin.Data
{

    public class FileService : IFileService
    {



        private readonly string _movieFile = $"{Environment.CurrentDirectory}/Files/MoviesShort.csv";
        private readonly string _showFile = $"{Environment.CurrentDirectory}/Files/shows.csv";
        private readonly string _videoFile = $"{Environment.CurrentDirectory}/Files/videos.csv";
        List<UInt64> MovieIds = new List<UInt64>();
        List<string?> MovieTitles = new List<string?>();
        List<string> MovieGenres = new List<string>();
        private readonly ILogger<IFileService> _logger;

        public FileService(ILogger<IFileService> logger)
        {
            _logger = logger;

            if (!File.Exists(_movieFile))
            {
                _logger.LogError("File Not Found");
            }

        }



        public void Write(string file)
        {
            
            Read(file);
            Console.WriteLine("Enter the movie title");
            // input title
            string? movieTitle = Console.ReadLine();
            // check for duplicate title
            List<string> lowerCaseMovieTitles = MovieTitles.ConvertAll(t => t.ToLower());
            if (lowerCaseMovieTitles.Contains(movieTitle.ToLower()))
            {
                Console.WriteLine("That movie has already been entered");
                _logger.LogInformation("Duplicate movie title {Title}", movieTitle);
            }
            else
            {
                UInt64 movieId;
                // generate movie id - use max value in MovieIds + 1
                if (MovieIds.Count > 0)
                {
                    movieId = MovieIds.Max() + 1;
                }
                else
                {
                    movieId = 1;
                }
                

                // input genres
                List<string> genres = new List<string>();
                string genre;
                do
                {
                    // ask user to enter genre
                    Console.WriteLine("Enter genre (or done to quit)");
                    // input genre
                    genre = Console.ReadLine();
                    // if user enters "done"
                    // or does not enter a genre do not add it to list
                    if (genre != "done" && genre.Length > 0)
                    {
                        genres.Add(genre);
                    }
                } while (genre != "done");

                // specify if no genres are entered
                if (genres.Count == 0)
                {
                    genres.Add("(no genres listed)");
                }

                // use "|" as delimeter for genres
                string genresString = string.Join("|", genres);
                // if there is a comma(,) in the title, wrap it in quotes
                movieTitle = movieTitle.IndexOf(',') != -1 ? $"\"{movieTitle}\"" : movieTitle;
                // display movie id, title, genres
                Console.WriteLine($"{movieId},{movieTitle},{genresString}");
                // create file from data
                StreamWriter sw = new StreamWriter(_movieFile, true);
                sw.WriteLine($"{movieId},{movieTitle},{genresString}");
                sw.Close();
                // add movie details to Lists
                MovieIds.Add(movieId);
                MovieTitles.Add(movieTitle);
                MovieGenres.Add(genresString);
                // log transaction
                _logger.LogInformation("Movie id {Id} added", movieId);
            }
        }

        public void DisplayItems()
        {

            
            for (int i = 0; i < MovieIds.Count; i++)
            {
                
                // display movie details
                Console.WriteLine($"Id: {MovieIds[i]}");
                Console.WriteLine($"Title: {MovieTitles[i]}");
                Console.WriteLine($"Genre(s): {MovieGenres[i]}");
                Console.WriteLine();
            }
        }
        public void Read(string file)
        {
            StreamReader sr = new StreamReader(file);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                int idx = line.IndexOf('"');
                if (idx == -1)
                {
                    string?[] movieDetails = line.Split(',');
                    
                    MovieIds.Add(UInt64.Parse(movieDetails[0]));
                    MovieTitles.Add(movieDetails[1]);
                    MovieGenres.Add(movieDetails[2].Replace("|", ", "));
                }
                else
                {
                    MovieIds.Add(UInt64.Parse(line.Substring(0, idx - 1)));
                    line = line.Substring(idx + 1);
                    idx = line.IndexOf('"');
                    MovieTitles.Add(line.Substring(0, idx));
                    line = line.Substring(idx + 2);
                    MovieGenres.Add(line.Replace("|", ", "));
                }
            }

            sr.Close();
            //List<String> movieList = new List<string>();

            

        }


    }
}
