using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class PayController : Controller
    {
        private IPayRepository repo { get; set; }
        private Basket basket { get; set; }
        public PayController(IPayRepository temp, Basket b)
        {
            // gives information about who is paying
            repo = temp;
            basket = b;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View( new Pay());
        }
        [HttpPost]
        public IActionResult Checkout(Pay payment)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, Your basket is empty");
            }
            if (ModelState.IsValid)
            {
                // if basket is valid then all in information form the basket will get sent to the payment 
                payment.Lines = basket.Items.ToArray();
                repo.SavePayment(payment);
                basket.ClearBasket();

                return RedirectToPage("/PaymentComplete");
            }
            else
            {
                return View();
            }
        }
    }
}
