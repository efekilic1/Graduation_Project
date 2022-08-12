using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public BillType Type { get; set; }
        public Month Month { get; set; }
        public string Year { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; } 
    }
}
