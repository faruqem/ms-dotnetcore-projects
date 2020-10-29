using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly SchoolContext _context;
        public IndexModel(SchoolContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        //public IList<Student> Students { get; set; }
        public PaginatedList<Student> Students { get; set; }

        //public async Task OnGetAsync(string sortOrder)
        //public async Task OnGetAsync(string sortOrder, string searchString)
        public async Task OnGetAsync(string sortOrder,string currentFilter, string searchString, int? pageIndex)
        {
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Student> studentsIQ = from s in _context.Students
                                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s => s.LastName.Contains(searchString)
                                    || s.FirstMidName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    studentsIQ = studentsIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.LastName);
                    break;
            }

            //Students = await studentsIQ.AsNoTracking().ToListAsync();
            int pageSize = 3; //A real app would use Configuration to set the page size value.
            Students = await PaginatedList<Student>.CreateAsync(studentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
        /*
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Students.ToListAsync();
        }
        */
    }
}

/*
When an IQueryable is created or modified, no query is sent to the database. 
The query isn't executed until the IQueryable object is converted into a collection. 
IQueryable are converted to a collection by calling a method such as ToListAsync. 
Therefore, the IQueryable code results in a single query that's not executed 
until the following statement:

Students = await studentsIQ.AsNoTracking().ToListAsync();
*/

/*
IQueryable vs. IEnumerable
The code calls the Where method on an IQueryable object, and 
the filter is processed on the server. In some scenarios, the app might be calling the 
Where method as an extension method on an in-memory collection. 
For example, suppose _context.Students changes from EF Core DbSet to a repository 
method that returns an IEnumerable collection. The result would normally be the same but 
in some cases may be different.

For example, the .NET Framework implementation of Contains performs a case-sensitive comparison by default. In SQL Server, Contains case-sensitivity is determined by the collation setting of the SQL Server instance. SQL Server defaults to case-insensitive. SQLite defaults to case-sensitive. ToUpper could be called to make the test explicitly case-insensitive:

Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())`

The preceding code would ensure that the filter is case-insensitive even if the Where method is called on an IEnumerable or runs on SQLite.

When Contains is called on an IEnumerable collection, the .NET Core implementation is used. When Contains is called on an IQueryable object, the database implementation is used.

Calling Contains on an IQueryable is usually preferable for performance reasons. With IQueryable, the filtering is done by the database server. If an IEnumerable is created first, all the rows have to be returned from the database server.

There's a performance penalty for calling ToUpper. The ToUpper code adds a function in the WHERE clause of the TSQL SELECT statement. The added function prevents the optimizer from using an index. Given that SQL is installed as case-insensitive, it's best to avoid the ToUpper call when it's not needed.
*/

