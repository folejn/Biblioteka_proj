using Biblioteka.Core.Domain;
using Biblioteka.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Infrastructure.Repositories
{
    public class BookshelfRepository : IBookshelfRepository
    {
        public Task AddAsync(Bookshelf s)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bookshelf>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bookshelf>> BrowseAllByFilterAsync(int floor)
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Bookshelf s)
        {
            throw new NotImplementedException();
        }

        public Task<Bookshelf> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Bookshelf s)
        {
            throw new NotImplementedException();
        }
    }
}
