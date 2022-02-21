using System;
using System.Collections.Generic;
using A4___Movie_Library___Eric_Peppin.Data;

namespace A4___Movie_Library___Eric_Peppin
{
    public class Menu
    {
        private readonly char _exitKey = 'X';
        private readonly List<char> _validChars = new List<char> { '1', '2' };
        private List<Movie> _movieList = new List<Movie>();
        public Menu()
        {
            DisplayMenu();
        }

        private void DisplayMenu()
        {
            Console.WriteLine("1. List Movies");
            Console.WriteLine("2. Add Movie");
            var returnKey = GetMenuSelection();
            var fileHandler = new FileRepository();
            if (returnKey == _exitKey)
            {
                Console.WriteLine("Thanks for using the Movie Library!");
            }
            else if (returnKey == '2')
            {
                fileHandler.Add();
            }
            else if (returnKey == '1')
            {
                fileHandler.Read();
                fileHandler.DisplayMovies();
            }



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