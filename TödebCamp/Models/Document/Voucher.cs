using System.ComponentModel.DataAnnotations.Schema;
using Models.Document.Base;


namespace Models.Document
{ 

    public class Voucher : DocumentBaseEntity
    {
        // Faturanın Propertyleri 
        
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public int BillId { get; set; }
        [ForeignKey("BillId")]
        public decimal Amount { get; set; }

    }
}

