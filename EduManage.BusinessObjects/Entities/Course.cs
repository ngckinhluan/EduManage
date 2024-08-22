using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduManage.BusinessObjects.Entities
{
    public class Course
    {
        public required int CourseId { get; set; }
        [MaxLength(255)]
        public required string CourseName { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public required int Credit { get; set; }
        [MaxLength(255)]
        public string? InstructorName { get; set; }

        // Navigation property
        public virtual ICollection<Enrollment>? Enrollments { get; set; }
        public virtual ICollection<LecturerCourse>? LecturerCourses { get; set; }
    }
}
