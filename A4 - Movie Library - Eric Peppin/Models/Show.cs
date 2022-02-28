using System;

namespace A4___Movie_Library___Eric_Peppin
{
    public class Show : Media
    {
        public int Episode { get; set; }
        public int Season { get; set; }
        public string[]? Writers { get; set; }

        public override string Display()
        {
            throw new NotImplementedException();
        }
    }
}