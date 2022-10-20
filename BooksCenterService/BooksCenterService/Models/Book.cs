namespace BooksCenterService.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public float Price { get; set; }
        public bool isAvailable { get; set; }
    }
}
