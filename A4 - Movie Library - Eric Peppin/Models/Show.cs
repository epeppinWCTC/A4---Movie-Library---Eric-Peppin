using System;
using System.IO;
using A4___Movie_Library___Eric_Peppin.Data;

namespace A4___Movie_Library___Eric_Peppin.Models
{
    public class Show : Media
    {
        public int Episode { get; set; }
        public int Season { get; set; }
        public string[]? Writers { get; set; }
        
        public override void Display(string file)
        {
            StreamReader sr = new StreamReader(file);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                Console.WriteLine(line);
            }
            sr.Close();
        }
    }
}