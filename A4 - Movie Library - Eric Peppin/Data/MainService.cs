using System;
using System.Collections.Generic;
using A4___Movie_Library___Eric_Peppin.Models;
using Microsoft.Extensions.Logging;

namespace A4___Movie_Library___Eric_Peppin.Data
{
    public class MainService : IMainService
    {
        private readonly char _exitKey = 'X';
        private readonly List<char> _validChars = new List<char> { '1', '2', '3' };
       //private List<Movie> _movieList = new List<Movie>();
        private readonly string _movieFile = $"{Environment.CurrentDirectory}/Files/MoviesShort.csv";
        private readonly string _showFile = $"{Environment.CurrentDirectory}/Files/shows.csv";
        private readonly string _videoFile = $"{Environment.CurrentDirectory}/Files/videos.csv";
        private readonly IFileService _fileService;
        public MainService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void Invoke()
        {
            var returnKey = _exitKey;
            do
            {
            Console.WriteLine("1. List Movies");
            Console.WriteLine("2. List Shows");
            Console.WriteLine("3. List Videos");
            //Console.WriteLine("2. Add Movie");
            returnKey = GetMenuSelection();
            if (returnKey == '3')
                {
                    Console.WriteLine();
                    Media video = new Video();
                    video.Display(_videoFile);
                }
                else if (returnKey == '2')
                {
                    Console.WriteLine();
                    Media show = new Show();
                    show.Display(_showFile);
                }
                else if (returnKey == '1')
                {
                    Console.WriteLine();
                    Media movie = new Movie();
                    movie.Display(_movieFile);
                }
            } while (returnKey != _exitKey);
        }

        public char GetMenuSelection()
        {
            Console.Write($"Select ({_validChars[0]},{_validChars[1]},{_validChars[2]},{_exitKey})>");
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