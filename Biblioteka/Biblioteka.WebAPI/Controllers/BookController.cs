using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Biblioteka.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteka.Infrastructure.DTO;
using Biblioteka.Infrastructure.Commands;

namespace Biblioteka.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService BookService)
        {
            _bookService = BookService;
        }

        // Book
        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var z = await _bookService.BrowseAll();
            return Json(z);
        }

        // localhost/Book/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var Book = await _bookService.GetAsync(id);
            return Json(Book);
        }

        //Book/filter?country=pol&name=jan
        [HttpGet("filter")]
        public async Task<IActionResult> BrowseBooks(string authorName, string title = null)
        {
            IEnumerable<BookDTO> z;

            if (title == null)
            {
                z = await _bookService.BrowseAllByFilterAsync(authorName);
            }
            else
            {
                z = await _bookService.BrowseAllByFilterAsync(authorName, title);
            }

            return Json(z);
        }

        // Book
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] CreateBook Book)
        {
            await _bookService.AddAsync(Book);
            return Created("", Book);
        }

        // Book/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> EditBook([FromBody] UpdateBook Book, int id)
        {
            await _bookService.UpdateAsync(id, Book);
            return NoContent();
        }

        // Book/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DelAsync(id);
            return NoContent();
        }
    }
}
