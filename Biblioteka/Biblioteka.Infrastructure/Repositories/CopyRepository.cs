using Biblioteka.Core.Domain;
using Biblioteka.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Infrastructure.Repositories
{
    public class CopyRepository : ICopyRepository
    {

        private AppDbContext _appDbContext;

        public CopyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Copy t)
        {
            try
            {
                _appDbContext.Copy.Add(t);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Copy>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Copy);
        }

        public async Task<IEnumerable<Copy>> BrowseAllByFilterAsync(string title)
        {
            return await Task.FromResult(_appDbContext.Copy.Where(x => x.Book.Title.Contains(title)));
        }

        public async Task DelAsync(Copy s)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Copy.FirstOrDefault(x => x.Id == s.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                await Task.FromException(ex);
            }
        }

        public async Task<Copy> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Copy.FirstOrDefault(s => s.Id == id));
        }

        public async Task UpdateAsync(Copy s)
        {
            try
            {
                var z = _appDbContext.Copy.FirstOrDefault(x => x.Id == s.Id);

                z.ReleaseDate = s.ReleaseDate;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
