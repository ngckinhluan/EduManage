using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduManage.BusinessObjects.Entities
{
    public class Enrollment
    {
        public required int StudentId { get; set; }
        public required int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string? Grade { get; set; }

        // Navigation properties
        public virtual Student? Student { get; set; }
        public virtual Course? Course { get; set; }
    }
}
