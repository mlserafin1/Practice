using Contacts.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contacts
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(12)]
        public string Phone { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } //NAVIGATION PROPERTY
    }
}