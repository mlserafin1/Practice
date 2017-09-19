using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Street { get; set; }
        [MaxLength(100)]
        public string Street2 { get; set; }
        [Required]
        [MaxLength(25)]
        public string City { get; set; }
        [Required]
        [MaxLength(2)]
        public string State { get; set; }
        [Required]
        [MaxLength(12)]
        public string Zip { get; set; }

        public virtual Contact Contact { get; set; } //entity will match up the name Contact with ContactId up above......NAVIGATION PROPERTY
    }
}
