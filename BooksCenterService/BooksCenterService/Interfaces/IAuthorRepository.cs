using BooksCenterService.Models;

namespace BooksCenterService.Interfaces
{
    public interface IAuthorRepository
    {
        bool AddAuthor(Author author);
        bool DeleteAuthor(int id);
    }
}
