using Biblioteka.Core.Domain;
using Biblioteka.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Book s)
        {
            try
            {
                _appDbContext.Book.Add(s);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Book>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Book);
        }

        public async Task<IEnumerable<Book>> BrowseAllByFilterAsync(string authorName, string title)
        {
            return await Task.FromResult(_appDbContext.Book.Where(x => x.Authors.Where(a => a.Lastname.Contains(authorName)).Any() || x.Title.Contains(title)));
        }

        public async Task<IEnumerable<Book>> BrowseAllByFilterAsync(string title)
        {
            return await Task.FromResult(_appDbContext.Book.Where(x => x.Title.Contains(title)));
        }

        public async Task DelAsync(Book s)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Book.FirstOrDefault(x => x.Id == s.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                await Task.FromException(ex);
            }

        }

        public async Task<Book> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Book.FirstOrDefault(s => s.Id == id));
        }

        public async Task UpdateAsync(Book s)
        {
            try
            {
                var z = _appDbContext.Book.FirstOrDefault(x => x.Id == s.Id);

                z.Title = s.Title;
                z.IssueDate = s.IssueDate;


                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
