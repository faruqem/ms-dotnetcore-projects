using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // The DatabaseGenerated attribute allows the app to specify the primary key rather than having the database generate it.
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } // The Enrollments property is defined as ICollection<Enrollment> because there may be multiple related Enrollment entities. You can use other collection types, such as List<Enrollment> or HashSet<Enrollment>. When ICollection<Enrollment> is used, EF Core creates a HashSet<Enrollment> collection by default.
    }
}