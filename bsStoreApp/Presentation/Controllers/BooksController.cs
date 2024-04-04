using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    //Bu sınıf tüm isteklerin yanıt aldığı sınıftır.
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IServicesManager _manager;
        public BookController(IServicesManager manager)
        {
            _manager = manager;
        }
        #region httpRequests
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _manager.BookServices.GetAllBooks(false);
                return Ok(books);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult GetBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _manager
                .BookServices
                .GetBook(id, false);

                if (entity == null)
                    return NotFound();

                return Ok(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null) return BadRequest();
                _manager.BookServices.CreateOneBook(book);
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute] int id, [FromBody] Book book)
        {
            try
            {
                if (book is null) return BadRequest();
                _manager.BookServices.UpdateOneBook(id, book, true);
                return StatusCode(201, book); //204
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                _manager.BookServices.DeleteOneBook(id, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
