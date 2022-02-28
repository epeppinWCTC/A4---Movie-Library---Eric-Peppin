using System;

namespace A4___Movie_Library___Eric_Peppin
{
    public class Video : Media
    {
        public string? Format { get; set;}
        public int Length { get; set; }
        public int[]? Regions { get; set; }
        public override string Display()
        {
            throw new NotImplementedException();
        }
    }
}