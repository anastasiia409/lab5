using lab5.DB;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lab5.Pages.EmployeeProjects
{
    public class IndexModel : PageModel
    {
        private readonly ProjectContext _db;

        public IEnumerable<EmployeeProject> _eprojects { get; set; } = null!;
        public IndexModel(ProjectContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            _eprojects = _db.EmployeeProjects.Include(prop => prop.Employee).Include(prop => prop.Project).Include(prop => prop.Position);
        }
    }
}
