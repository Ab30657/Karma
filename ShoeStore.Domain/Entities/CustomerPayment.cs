namespace ShoeStore.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerPayment")]
    public partial class CustomerPayment
    {
        [Key]
        public int PaymentId { get; set; }

        public int? CustomerId { get; set; }

        public decimal? GrandTotal { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
