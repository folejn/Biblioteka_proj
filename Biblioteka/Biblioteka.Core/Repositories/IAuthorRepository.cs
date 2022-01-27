using Biblioteka.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Core.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> BrowseAllAsync();
        Task<IEnumerable<Author>> BrowseAllByFilterAsync(string lastName);
        Task<Author> GetAsync(int id);
        Task DelAsync(Author s);
        Task UpdateAsync(Author s);
        Task AddAsync(Author s);
    }
}
