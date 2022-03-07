namespace A4___Movie_Library___Eric_Peppin.Data
{
    public interface IRepository
    {
        void Read(string item);
        string Write();
        void DisplayItems();
    }
}