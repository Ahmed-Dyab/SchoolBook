namespace schoolbook.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Subject { get; set;}
        public int Semseter { get; set;}
      
        public string PublishYear { get; set;}
        public string SerialNumber { get; set;}
        public string StudyYear { get; set;}   
        public List<BookImage> BookImagess { get; set;}
        public int UserId { get; set;}
    }
}
