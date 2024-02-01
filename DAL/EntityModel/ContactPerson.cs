using System;
using System.Collections.Generic;

namespace DAL.EntityModel
{
    public partial class ContactPerson
    {
        public ContactPerson()
        {
            Distributors = new HashSet<Distributor>();
            Vendors = new HashSet<Vendor>();
        }

        public int ContactPersonId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Title { get; set; }
        public string Contact { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Distributor> Distributors { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}
