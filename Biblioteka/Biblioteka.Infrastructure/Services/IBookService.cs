using Biblioteka.Infrastructure.Commands;
using Biblioteka.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Infrastructure.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> BrowseAll();
        Task<IEnumerable<BookDTO>> BrowseAllByFilterAsync(string authorName, string title);
        Task<IEnumerable<BookDTO>> BrowseAllByFilterAsync(string title);
        Task<BookDTO> GetAsync(int id);
        Task DelAsync(int id);
        Task UpdateAsync(int id, UpdateBook s);
        Task AddAsync(CreateBook s);
    }
}
