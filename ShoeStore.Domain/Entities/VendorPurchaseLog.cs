namespace ShoeStore.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VendorPurchaseLog")]
    public partial class VendorPurchaseLog
    {
        [Key]
        public int PurchaseId { get; set; }

        public int? VendorId { get; set; }

        public int? ProductId { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public decimal? GrandTotal { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public virtual Product Product { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
