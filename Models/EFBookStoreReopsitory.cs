using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//connecting with the Context file

namespace BookStore.Models
{
    public class EFBookStoreReopsitory : IBookStoreRepository
    {
        private BookstoreContext context { get; set; }

        public EFBookStoreReopsitory (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
