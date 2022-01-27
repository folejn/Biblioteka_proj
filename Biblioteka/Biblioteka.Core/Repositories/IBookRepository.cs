using Biblioteka.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Core.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> BrowseAllAsync();
        Task<IEnumerable<Book>> BrowseAllByFilterAsync(string authorName, string title);
        Task<IEnumerable<Book>> BrowseAllByFilterAsync(string title);
        Task<Book> GetAsync(int id);
        Task DelAsync(Book s);
        Task UpdateAsync(Book s);
        Task AddAsync(Book s);
    }
}
