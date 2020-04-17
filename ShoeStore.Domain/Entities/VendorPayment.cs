namespace ShoeStore.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VendorPayment")]
    public partial class VendorPayment
    {
        [Key]
        public int PaymentId { get; set; }

        public int? VendorId { get; set; }

        public decimal? GrandTotal { get; set; }

        public decimal? Paid { get; set; }

        public decimal? Due { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
