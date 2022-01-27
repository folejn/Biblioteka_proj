using Biblioteka.Core.Domain;
using Biblioteka.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Infrastructure.Repositories
{
    public class BookshelfInfoRepository : IBookshelfInfoRepository
    {
        public Task AddAsync(BookshelfInfo s)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookshelfInfo>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(BookshelfInfo s)
        {
            throw new NotImplementedException();
        }

        public Task<BookshelfInfo> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BookshelfInfo s)
        {
            throw new NotImplementedException();
        }
    }
}
