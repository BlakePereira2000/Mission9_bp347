using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public interface IPayRepository
    {
        IQueryable<Pay> Payments { get; }
        void SavePayment(Pay payment);
    }
}
