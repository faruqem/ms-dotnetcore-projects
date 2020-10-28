namespace ContosoUniversity.Models
{
    public enum Grade {
        A, B, C, D, F
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; } // By default, EF Core interprets a property that's named ID or classnameID as the primary key. For a production data model, choose one pattern and use it consistently. Using ID without classname makes it easier to implement some kinds of data model changes.
        public int CourseID { get; set; } //EF Core interprets a property as a foreign key if it's named <navigation property name><primary key property name>. For example,StudentID is the foreign key for the Student navigation property, since the Student entity's primary key is ID. Foreign key properties can also be named <primary key property name>. For example, CourseID since the Course entity's primary key is CourseID.
        public int StudentID { get; set; }  //The StudentID property is a foreign key, and the corresponding navigation property is Student. An Enrollment entity is associated with one Student entity, so the property contains a single Student entity.

        public Grade? Grade { get; set; } //The Grade property is an enum. The question mark after the Grade type declaration indicates that the Grade property is nullable. A grade that's null is different from a zero grade—null means a grade isn't known or hasn't been assigned yet

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}