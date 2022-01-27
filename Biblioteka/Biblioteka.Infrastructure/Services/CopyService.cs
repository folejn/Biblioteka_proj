using Biblioteka.Core.Domain;
using Biblioteka.Core.Repositories;
using Biblioteka.Infrastructure.Commands;
using Biblioteka.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Infrastructure.Services
{
    public class CopyService : ICopyService
    {
        private readonly ICopyRepository _copyRepository;

        public CopyService(ICopyRepository CopyRepository)
        {
            _copyRepository = CopyRepository;
        }

        public async Task AddAsync(CreateCopy t)
        {
            await _copyRepository.AddAsync(Map(t));
        }

        public async Task<IEnumerable<CopyDTO>> BrowseAll()
        {
            var Copys = await _copyRepository.BrowseAllAsync();
            return Copys.Select(x => Map(x));
        }

        public async Task<IEnumerable<CopyDTO>> BrowseAllByFilterAsync(string title)
        {
            var Copys = await _copyRepository.BrowseAllByFilterAsync(title);
            return Copys.Select(x => Map(x));
        }

        public async Task DelAsync(int id)
        {
            var Copy = _copyRepository.GetAsync(id).Result;
            await _copyRepository.DelAsync(Copy);
        }

        public async Task<CopyDTO> GetAsync(int id)
        {
            return await Task.FromResult(Map(_copyRepository.GetAsync(id).Result));
        }

        public async Task UpdateAsync(int id, UpdateCopy t)
        {
            await _copyRepository.UpdateAsync(Map(t, id));
        }

        private CopyDTO Map(Copy t)
        {
            return new CopyDTO()
            {
                Id = t.Id,
                ReleaseDate = t.ReleaseDate
            };
        }

        private Copy Map(CreateCopy t)
        {
            return new Copy()
            {
                ReleaseDate = t.ReleaseDate
            };
        }

        private Copy Map(UpdateCopy t, int id)
        {
            return new Copy()
            {
                Id = id,
                ReleaseDate = t.ReleaseDate
            };
        }
    }
}
