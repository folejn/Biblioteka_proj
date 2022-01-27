using Biblioteka.Infrastructure.Commands;
using Biblioteka.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Infrastructure.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDTO>> BrowseAll();
        Task<IEnumerable<AuthorDTO>> BrowseAllByFilterAsync(string lastName);
        Task<AuthorDTO> GetAsync(int id);
        Task DelAsync(int id);
        Task UpdateAsync(int id, UpdateAuthor t);
        Task AddAsync(CreateAuthor t);
    }
}
