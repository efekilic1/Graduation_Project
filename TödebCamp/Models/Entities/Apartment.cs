using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Apartment
    {
        // dairenin propertyleri

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public int BlockNo { get; set; }
        public string HouseType { get; set; }
        public int ApartmentNo { get; set; }
        public bool Full { get; set; }
        public bool HomeOwner { get; set; }


    }

    
    
}