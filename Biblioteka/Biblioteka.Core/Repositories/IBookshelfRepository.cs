using Biblioteka.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Core.Repositories
{
    public interface IBookshelfRepository
    {
        Task<IEnumerable<Bookshelf>> BrowseAllAsync();
        Task<IEnumerable<Bookshelf>> BrowseAllByFilterAsync(int floor);
        Task<Bookshelf> GetAsync(int id);
        Task DelAsync(Bookshelf s);
        Task UpdateAsync(Bookshelf s);
        Task AddAsync(Bookshelf s);
    }
}
