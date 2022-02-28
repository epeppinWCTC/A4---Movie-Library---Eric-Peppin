using System;
using System.Collections.Generic;
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
            Console.WriteLine("1. List Movies");
            Console.WriteLine("2. List Shows");
            Console.WriteLine("3. List Videos");
            //Console.WriteLine("2. Add Movie");
            var returnKey = GetMenuSelection();
            do
            {
                if (returnKey == '3')
                {
                    _fileService.Read(_videoFile);
                    _fileService.DisplayItems();
                }
                else if (returnKey == '2')
                {
                    _fileService.Read(_showFile);
                    _fileService.DisplayItems();
                }
                else if (returnKey == '1')
                {
                    _fileService.Read(_movieFile);
                    _fileService.DisplayItems();
                }
            } while (returnKey != _exitKey);
        }

        public char GetMenuSelection()
        {
            Console.Write($"Select ({_validChars[0]}, {_validChars[1]}, {_exitKey})>");
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