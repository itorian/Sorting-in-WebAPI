using EmptyWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EmptyWebAPI.Controllers
{
    public class StudentController : ApiController
    {
        // Data source
        List<Student> db = new List<Student>();
        public StudentController()
        {
            db = new List<Student>
            {
                new Student { Id = 1, Name = "Abhimanyu K Vatsa", City = "Bokaro" },
                new Student { Id = 2, Name = "Deepak Kumar Gupta", City = "Bokaro" },
                new Student { Id = 3, Name = "Manish Kumar", City = "Muzaffarpur" },
                new Student { Id = 4, Name = "Rohit Ranjan", City = "Patna" },
                new Student { Id = 5, Name = "Shiv", City = "Motihari" },
                new Student { Id = 6, Name = "Rajesh Singh", City = "Dhanbad" },
                new Student { Id = 7, Name = "Staya", City = "Bokaro" },
                new Student { Id = 8, Name = "Samiran", City = "Chas" },
                new Student { Id = 9, Name = "Rajnish", City = "Bokaro" },
                new Student { Id = 10, Name = "Mahtab", City = "Dhanbad" },
            };
        }

        public IHttpActionResult Get(string sort = "id")
        {
            // Convert data source into IQueryable
            // ApplySort method needs IQueryable data source hence we need to convert it
            // Or we can create ApplySort to work on list itself
            var data = db.AsQueryable();

            // Apply sorting
            data = data.ApplySort(sort);

            // Return response
            return Ok(data);
        }

    }
}
