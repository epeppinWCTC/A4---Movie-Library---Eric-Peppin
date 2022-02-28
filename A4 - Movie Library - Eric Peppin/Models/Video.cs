using System;
using System.IO;

namespace A4___Movie_Library___Eric_Peppin
{
    public class Video : Media
    {
        public string? Format { get; set;}
        public int Length { get; set; }
        public int[]? Regions { get; set; }
        public override void Display(string file)
        {
            StreamReader sr = new StreamReader(file);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                Console.WriteLine(line);
            }sr.Close();
        }
    }
}