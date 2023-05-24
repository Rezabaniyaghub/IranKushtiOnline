using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class ClassRoom
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirhDate { get; set; }
        public string Country { get; set; }
        public AgeRange AgeRange { get; set; }
        public string PhoneNumber { get; set; }
        public int SchoolId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public virtual School School { get; set; }
    }
}
