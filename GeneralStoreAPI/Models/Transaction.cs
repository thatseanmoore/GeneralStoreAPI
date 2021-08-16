using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GeneralStoreAPI.Models
{
    public class Transaction
    {
        [Key]
        public int ID { get; set; }
        [Required,ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        [Required,ForeignKey(nameof(Product))]
        public virtual Customer Customer { get; set; }
        [Required,ForeignKey(nameof(Product))]
        public string SKU { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public int ItemCount { get; set; }
        [Required]
        public DateTime DateOfTransaction { get; set; }
        public static implicit operator Transaction(Customer v)
        {
            throw new NotImplementedException();
        }
    }
}