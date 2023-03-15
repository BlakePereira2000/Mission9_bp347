using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class EFPayRepository : IPayRepository
    {
        // allows access to the repository
        private BookstoreContext context;
        public EFPayRepository(BookstoreContext temp)
        {
            context = temp;
        }
        // get all the information from the line for each checkout and it get each books information too
        public IQueryable<Pay> Payments => context.Payments.Include(x=> x.Lines).ThenInclude(x=> x.Book);

        public void SavePayment(Pay payment)
        {
            context.AttachRange(payment.Lines.Select(x => x.Book));

            if (payment.PaymentId == 0)
            {
                context.Payments.Add(payment);
            }

            context.SaveChanges();
        }
    }
}
