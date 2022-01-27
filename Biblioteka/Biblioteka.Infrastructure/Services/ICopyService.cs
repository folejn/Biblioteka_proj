using Biblioteka.Infrastructure.Commands;
using Biblioteka.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Infrastructure.Services
{
    public interface ICopyService
    {
        Task<IEnumerable<CopyDTO>> BrowseAll();
        Task<IEnumerable<CopyDTO>> BrowseAllByFilterAsync(string title);
        Task<CopyDTO> GetAsync(int id);
        Task DelAsync(int id);
        Task UpdateAsync(int id, UpdateCopy t);
        Task AddAsync(CreateCopy t);
    }
}
