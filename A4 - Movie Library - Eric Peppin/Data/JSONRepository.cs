using System;
using System.IO;
using A4___Movie_Library___Eric_Peppin.Models;
using Newtonsoft.Json;

namespace A4___Movie_Library___Eric_Peppin.Data
{
    public class JSONRepository : IRepository
    {
        
        public void Read(string json)
        {
            Movie? m = JsonConvert.DeserializeObject<Movie>(json);
            Console.WriteLine(m.Id);
            Console.WriteLine(m.Title);
            Console.WriteLine(m.Genres);
        }
        

        public string Write()
        {
            Movie movie = new Movie();
            movie.Id = 1;
            movie.Title = "Snow White";
            movie.Genres = "Adventure|Romance";
            
            string json = JsonConvert.SerializeObject(movie);
            return json;
        }

        public void DisplayItems()
        {
            throw new System.NotImplementedException();
        }
    }
}