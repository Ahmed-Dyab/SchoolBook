namespace schoolbook.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public int State { get; set; }
        public DateTime OperationData { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
