using BooksCenterService.Interfaces;
using BooksCenterService.Models;

namespace BooksCenterService
{
    public interface IAuthorService
    {
        bool AddAuthor(Author author);
        bool DeleteAuthor(int id);
    }

    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public bool AddAuthor(Author author)
        {
            return _authorRepository.AddAuthor(author);
        }

        public bool DeleteAuthor(int id)
        {
            return _authorRepository.DeleteAuthor(id);
        }
    }
}
