using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduManage.BusinessObjects.Entities
{
    public class Student
    {
        public required int StudentId { get; set; }
        [MaxLength(255)]
        public required string FirstName { get; set; }
        [MaxLength(255)]
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [EmailAddress]
        [MaxLength(255)]
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        [MaxLength(255)]
        public string? Password { get; set; }

        // Navigation property
        public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}
