using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exceptions
{
    public class ProductNotFoundException:Exception
    {
        public ProductNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
