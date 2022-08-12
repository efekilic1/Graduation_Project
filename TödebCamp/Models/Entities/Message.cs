using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Message
    {
        // Yöneticiye mesaj gönderebiliyoruz.
        // Yönetici de apartman sakinlerine yönelik duyuru yapabiliyor. 

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserRole ReaderRole { get; set; }
        public string Email { get; set; }
        public string MessageText { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime Date { get; set; } = DateTime.Now;


    }
}
