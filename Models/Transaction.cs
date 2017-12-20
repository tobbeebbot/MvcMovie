using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [StringLength(60, MinimumLength = 3), Required]
        public string Item { get; set; }

        [RegularExpression(@"^[A-Ö]+[a-öA-Ö''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        [DataType(DataType.Currency)]
        public decimal Difference { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }




        internal void SetDate()
        {
            Date = DateTime.Now;
        }


        internal void CalcTotalFrom(Transaction oldTransaction)
        {
            decimal oldTotal = 0;
            if (oldTransaction != null)
            {
                oldTotal = oldTransaction.Total;
            }
            Total = oldTotal + Difference;
        }
    }
}
