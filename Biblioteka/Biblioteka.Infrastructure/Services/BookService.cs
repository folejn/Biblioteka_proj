using Biblioteka.Core.Domain;
using Biblioteka.Core.Repositories;
using Biblioteka.Infrastructure.Commands;
using Biblioteka.Infrastructure.DTO;
using Biblioteka.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository BookRepository)
        {
            _bookRepository = BookRepository;
        }

        public async Task<IEnumerable<BookDTO>> BrowseAll()
        {
            var Books = await _bookRepository.BrowseAllAsync();
            return Books.Select(x => Map(x));
        }

        public async Task<IEnumerable<BookDTO>> BrowseAllByFilterAsync(string authorName, string title)
        {
            IEnumerable<Book> Books;

            if (authorName == null)
            {
                Books = await _bookRepository.BrowseAllByFilterAsync(title);
            }
            else
            {
                Books = await _bookRepository.BrowseAllByFilterAsync(authorName, title);
            }

            return Books.Select(x => Map(x));
        }

        public async Task<IEnumerable<BookDTO>> BrowseAllByFilterAsync(string title)
        {
            var Books = await _bookRepository.BrowseAllByFilterAsync(title);
            return Books.Select(x => Map(x));
        }

        public async Task<BookDTO> GetAsync(int id)
        {
            return await Task.FromResult(Map(_bookRepository.GetAsync(id).Result));
        }

        public async Task AddAsync(CreateBook s)
        {
            await _bookRepository.AddAsync(Map(s));
        }

        public async Task DelAsync(int id)
        {
            var Book = _bookRepository.GetAsync(id).Result;
            await _bookRepository.DelAsync(Book);
        }


        public async Task UpdateAsync(int id, UpdateBook s)
        {
            await _bookRepository.UpdateAsync(Map(s, id));
        }

        private BookDTO Map(Book s)
        {
            return new BookDTO()
            {
                Id = s.Id,
                Title = s.Title,
                IssueDate = s.IssueDate
            };
        }

        private Book Map(CreateBook s)
        {
            return new Book()
            {
                Title = s.Title,
                IssueDate = s.IssueDate
            };
        }

        private Book Map(UpdateBook s, int id)
        {
            return new Book()
            {
                Id = id,
                Title = s.Title,
                IssueDate = s.IssueDate
            };
        }
    }
}
