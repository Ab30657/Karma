using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeStore.Domain.Entities
{
    public class Bag
    {
        private List<BagLine> Lines = new List<BagLine>();

        public void AddItem(Product product, int quantity)
        {
            BagLine line = Lines.Where(x => x.Product.ProductId == product.ProductId).FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new BagLine()
                {
                    Product = product,
                    Quantity=quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveItem(int productId)
        {
            Lines.RemoveAll(x => x.Product.ProductId == productId);
        }

        public void Clear()
        {
            Lines.Clear();
        }

        public decimal ComputeTotalValue()
        {
            return Lines.Sum(x => x.Quantity * x.Product.Price);
        }

        public IEnumerable<BagLine> GetLines
        {
            get { return Lines; }
        }
    }

    public class BagLine
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
