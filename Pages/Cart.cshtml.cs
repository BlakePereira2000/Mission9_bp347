using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Infrastructure;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages
{
    public class CartModel : PageModel
    {
        // creating a repository to transfer data
        private IBookStoreRepository repo { get; set; }

        public CartModel (IBookStoreRepository temp)
        {
            repo = temp;
        }
        //
        public Basket basket { get; set; }
        public void OnGet()
        {
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }
        // creating a post request so that information can be passed to through the form
        public IActionResult onPost(int bookId)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage();
        }
    }
}
