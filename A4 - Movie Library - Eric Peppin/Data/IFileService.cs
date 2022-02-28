namespace A4___Movie_Library___Eric_Peppin.Data
{
    public interface IFileService
    {
        void Read(string file);
        void Write(string file);
        void DisplayItems();
    }
}