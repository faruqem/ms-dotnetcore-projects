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
    public class DetailsModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public DetailsModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);
            Student = await _context.Students
                .Include(s => s.Enrollments) //The Include and ThenInclude methods cause the context to load the Student.Enrollments navigation property, and within each enrollment the Enrollment.Course navigation property. 
                .ThenInclude(e => e.Course)
                .AsNoTracking() // The AsNoTracking method improves performance in scenarios where the entities returned are not updated in the current context.
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

/*
The generated code uses FirstOrDefaultAsync to read one entity. This method returns null if nothing is found; 
otherwise, it returns the first row found that satisfies the query filter criteria. 
FirstOrDefaultAsync is generally a better choice than the following alternatives:

SingleOrDefaultAsync - Throws an exception if there's more than one entity that satisfies the query filter. To determine if more than one row could be returned by the query, SingleOrDefaultAsync tries to fetch multiple rows. This extra work is unnecessary if the query can only return one entity, as when it searches on a unique key.
FindAsync - Finds an entity with the primary key (PK). If an entity with the PK is being tracked by the context, it's returned without a request to the database. This method is optimized to look up a single entity, but you can't call Include with FindAsync. So if related data is needed, FirstOrDefaultAsync is the better choice.
*/

/*
Route data vs. query string
---------------------------
The URL for the Details page is https://localhost:<port>/Students/Details?id=1. 
The entity's primary key value is in the query string. Some developers prefer to pass the key value in 
route data: https://localhost:<port>/Students/Details/1
*/