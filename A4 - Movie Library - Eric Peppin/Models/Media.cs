namespace A4___Movie_Library___Eric_Peppin
{
    public abstract class Media
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public abstract void Display(string file);
    }
}