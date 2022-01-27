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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository AuthorRepository)
        {
            _authorRepository = AuthorRepository;
        }

        public async Task AddAsync(CreateAuthor t)
        {
            await _authorRepository.AddAsync(Map(t));
        }

        public async Task<IEnumerable<AuthorDTO>> BrowseAll()
        {
            var Authors = await _authorRepository.BrowseAllAsync();
            return Authors.Select(x => Map(x));
        }

        public async Task<IEnumerable<AuthorDTO>> BrowseAllByFilterAsync(string lastName)
        {
            var Authors = await _authorRepository.BrowseAllByFilterAsync(lastName);
            return Authors.Select(x => Map(x));
        }

        public async Task DelAsync(int id)
        {
            var Author = _authorRepository.GetAsync(id).Result;
            await _authorRepository.DelAsync(Author);
        }

        public async Task<AuthorDTO> GetAsync(int id)
        {
            return await Task.FromResult(Map(_authorRepository.GetAsync(id).Result));
        }

        public async Task UpdateAsync(int id, UpdateAuthor t)
        {
            await _authorRepository.UpdateAsync(Map(t, id));
        }

        private AuthorDTO Map(Author t)
        {
            return new AuthorDTO()
            {
                Id = t.Id,
                Name = t.Name,
                Lastname = t.Lastname,
                BirthDate = t.BirthDate
            };
        }

        private Author Map(CreateAuthor t)
        {
            return new Author()
            {
                Name = t.Name,
                Lastname = t.Lastname,
                BirthDate = t.BirthDate
            };
        }

        private Author Map(UpdateAuthor t, int id)
        {
            return new Author()
            {
                Id = id,
                Name = t.Name,
                Lastname = t.Lastname,
                BirthDate = t.BirthDate
            };
        }
    }
}
