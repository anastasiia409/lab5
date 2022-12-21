using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab5.DB;
using lab5.Models;

namespace lab5.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly ProjectContext _db;

        public IEnumerable<Project> _projects { get; set; } = null!;
        public IndexModel(ProjectContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            _projects = _db.Projects.OrderBy(p => p.Name);
        }
    }
}
