using Biblioteka.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Core.Repositories
{
    public interface ICopyRepository
    {
        Task<IEnumerable<Copy>> BrowseAllAsync();
        Task<IEnumerable<Copy>> BrowseAllByFilterAsync(string title);
        Task<Copy> GetAsync(int id);
        Task DelAsync(Copy s);
        Task UpdateAsync(Copy s);
        Task AddAsync(Copy s);
    }
}
