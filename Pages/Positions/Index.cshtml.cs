using lab5.DB;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Positions
{
    public class IndexModel : PageModel
    {
        private readonly ProjectContext _db;

        public IEnumerable<Position> _positions { get; set; } = null!;
        public IndexModel(ProjectContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            _positions = _db.Positions.OrderBy(p => p.Name);
        }
    }
}
