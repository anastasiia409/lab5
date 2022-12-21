using lab5.DB;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly ProjectContext _db;

        public IEnumerable<Employee> _employees { get; set; } = null!;
        public IndexModel(ProjectContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            _employees = _db.Employees.OrderBy(p => p.Name);
        }
    }
}
