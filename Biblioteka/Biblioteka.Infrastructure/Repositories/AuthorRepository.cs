using Biblioteka.Core.Domain;
using Biblioteka.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {

        private AppDbContext _appDbContext;

        public AuthorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Author t)
        {
            try
            {
                _appDbContext.Author.Add(t);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Author>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Author);
        }

        public async Task<IEnumerable<Author>> BrowseAllByFilterAsync(string lastName)
        {
            return await Task.FromResult(_appDbContext.Author.Where(x => x.Lastname.Contains(lastName)));
        }

        public async Task DelAsync(Author s)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Author.FirstOrDefault(x => x.Id == s.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                await Task.FromException(ex);
            }
        }

        public async Task<Author> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Author.FirstOrDefault(s => s.Id == id));
        }

        public async Task UpdateAsync(Author s)
        {
            try
            {
                var z = _appDbContext.Author.FirstOrDefault(x => x.Id == s.Id);

                z.Name = s.Name;
                z.Lastname = s.Lastname;
                z.BirthDate = s.BirthDate;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
