using ShoeStore.Domain.Concrete;
using ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeStore.Domain.Abstract
{

    public interface IProductRepos
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Category> Categories { get; }
    }
            
}
