using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModel.BookModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore_BackEnd.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAllHeaders")]
    public class BookController : Controller
    {
        private readonly IBookBusiness business;

        public BookController(IBookBusiness business)
        {
            this.business = business;
        }

        [HttpPost]
        public IActionResult AddBooks([FromBody] BookModel model)
        {
            try
            {
                var result = business.AddBook(model);
                if (result != null)
                {
                    return Ok(new { Status = true, Message = "Book Added Successfull", Data = result });
                }
                return BadRequest(new { Status = false, Message = "Error While Adding Book" });
            }
            catch (Exception e)
            {
                return NotFound(new { Status = false, Message = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            try
            {
                var result = business.GetBook();
                if (result != null)
                {
                    return Ok(new { Status = true, Message = "All Books Retrived Successfully", Data = result });
                }
                return BadRequest(new { Status = false, Message = "Error While Retriving Books!!!" });
            }
            catch(Exception e)
            {
                return NotFound(new { Status = false, Message = e.Message });
            }
        }
    }
}
