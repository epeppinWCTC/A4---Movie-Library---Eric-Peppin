using System;
using System.Collections.Generic;
using A4___Movie_Library___Eric_Peppin.Models;
using Microsoft.Extensions.Logging;

namespace A4___Movie_Library___Eric_Peppin.Data
{
    public class MainService : IMainService
    {
        private readonly char _exitKey = 'X';
        private readonly List<char> _validChars = new List<char> { '1'};
       //private List<Movie> _movieList = new List<Movie>();
        private readonly string _movieFile = $"{Environment.CurrentDirectory}/Files/MoviesShort.csv";
        private readonly string _showFile = $"{Environment.CurrentDirectory}/Files/shows.csv";
        private readonly string _videoFile = $"{Environment.CurrentDirectory}/Files/videos.csv";
        private readonly ILogger<IRepository> _fileService;
        public MainService(ILogger<IRepository>? fileService)
        {
            _fileService = fileService;
        }

        public void Invoke()
        {
            var returnKey = _exitKey;
            var movie ="";
           do
           {
                Console.WriteLine("1. Serialize/Deserialize JSON");
                //Console.WriteLine("2. Deserialize JSON");
                returnKey = GetMenuSelection();
                var json = new JSONRepository();
                if (returnKey == _exitKey)
                {
                    Console.WriteLine("Thanks for using the Movie Library!");
                }
                else if (returnKey == '1')
                {
                    movie = json.Write();
                    Console.WriteLine();
                    json.Read(movie);
                    
                    // fileHandler.Write(_movieFile);
                }
                else if (returnKey == '1')
                {
                    Console.WriteLine("This does nothing");
                    // fileHandler.Read(_movieFile);
                }
            } while (returnKey != _exitKey);
        }

        public char GetMenuSelection()
        {
            Console.Write($"Select ({_validChars[0]},{_exitKey})>");
            var key = Console.ReadKey().KeyChar;
            while (Equals(!_validChars.Contains(key)))
            {
                if (key == _exitKey || char.ToLower(key) == char.ToLower(_exitKey))
                {
                    break;
                }

                Console.WriteLine($"Invalid, Please select {_validChars[0]}, {_validChars[1]}, {_exitKey}> ");
                key = Console.ReadKey().KeyChar;
            }
            return key;
        }

    }
}