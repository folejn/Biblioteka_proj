using Biblioteka.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Core.Repositories
{
    public interface IBookshelfInfoRepository
    {
        Task<IEnumerable<BookshelfInfo>> BrowseAllAsync();
        Task<BookshelfInfo> GetAsync(int id);
        Task DelAsync(BookshelfInfo s);
        Task UpdateAsync(BookshelfInfo s);
        Task AddAsync(BookshelfInfo s);
    }
}
