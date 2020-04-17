namespace ShoeStore.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerPurchaseLog")]
    public partial class CustomerPurchaseLog
    {
        [Key]
        public int PurchaseId { get; set; }

        public int? CustomerId { get; set; }

        public int? ProductId { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public decimal? Total { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }
    }
}
