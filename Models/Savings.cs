#pragma warning disable CS8618
using System;
using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Models
{
    public class Savings
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
