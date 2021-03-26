using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModel.BookModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAllHeaders")]
    public class CartController : Controller
    {
        private readonly ICartBusiness business;

        public CartController(ICartBusiness business)
        {
            this.business = business;    
        }

        [HttpPost]
        public IActionResult AddToCartBook([FromBody]CartModel model)
        {
            try
            {
                var result = business.AddToCart(model);
                if (result != null)
                {
                    return Ok(new { Status = true, Message = "Book Added To Cart Successfull", Data = result });
                }
                return BadRequest(new { Status = false, Message = "Error While AddToCart Book!!!" });
            }
            catch (Exception e)
            {
                return NotFound(new { Status = false, Message = e.Message });
            }
        }
        
        [HttpGet]
        public IActionResult GetCartBooks(int userId)
        {
            try
            {
                var result = business.GetCart(userId);
                if (result != null)
                {
                    return Ok(new { Status = true, Message = "Cart Book Retrived Successfull", Data = result });
                }
                return BadRequest(new { Status = false, Message = "Error while Retriving Books From Cart!!!" });
            }
            catch (Exception e)
            {
                return NotFound(new { Status = false, Message=e.Message });
            }
        }

        [HttpDelete]
        public IActionResult DeletCartItems(int cartId)
        {
            try
            {
                bool result = business.DeletCartItem(cartId);
                if (result)
                {
                    return Ok(new { Status = true, Message = "Item Removed From Cart Successfully.", Data = result });
                }
                return BadRequest(new { Status = false, Message = "Error while Removing Item From Cart!!!" });
            }
            catch (Exception e)
            {
                return NotFound(new { Status = false, Message = e.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateBookQuntity(CartModel model)
        { 
            try
            {
                var result = business.UpdateBookCount(model);
                if (result != null)
                {
                    return Ok(new { Status = true, Message = "Cart Quntity Updated Successfully...", Data = result});
                }
                return BadRequest(new { Status = false, Message = "Error While Updating Book Quntity!!!" });
            }
            catch(Exception e)
            {
                return NotFound(new { Status = false, Message = e.Message });
            }
        }
    }
}




